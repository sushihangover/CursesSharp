using System;
using Curses;

namespace FireworkDemo
{
    class Program
    {
        private const int DELAYSIZE = 200;

        private static short[] color_table = {
            Defs.COLOR_RED, Defs.COLOR_BLUE, Defs.COLOR_GREEN, Defs.COLOR_CYAN,
            Defs.COLOR_RED, Defs.COLOR_MAGENTA, Defs.COLOR_YELLOW, Defs.COLOR_WHITE
        };

        static void Main(string[] args)
        {
            Screen.InitScr();
            try
            {
                Main2();
            }
            finally
            {
                Screen.EndWin();
            }
        }

        private static Random rng;

        private static void Main2()
        {
            Screen.NoDelay = true;
            Screen.Echo = false;

            if (Screen.HasColors)
            {
                Screen.StartColor();
                for (short i = 1; i < 8; ++i)
                    Screen.InitPair(i, color_table[i], Defs.COLOR_BLACK);
            }

            rng = new Random();
            int flag = 0;
            while (Screen.GetCh() == -1)
            {
                int start, end, row, diff, direction;
                do
                {
                    start = rng.Next(Screen.Cols - 3);
                    end = rng.Next(Screen.Cols - 3);
                    start = (start < 2) ? 2 : start;
                    end = (end < 2) ? 2 : end;
                    direction = (start > end) ? -1 : 1;
                    diff = Math.Abs(start - end);
                } while (diff < 2 || diff >= Screen.Lines - 2);

                Screen.AttrSet(Defs.A_NORMAL);
                for (row = 1; row < diff; ++row)
                {
                    Screen.MvAddStr(Screen.Lines - row, row * direction + start, (direction < 0) ? "\\" : "/");
                    if (flag++ > 0)
                    {
                        MyRefresh();
                        Screen.Erase();
                        flag = 0;
                    }
                }

                if (flag++ > 0)
                {
                    MyRefresh();
                    flag = 0;
                }

                Explode(Screen.Lines - row, diff * direction + start);
                Screen.Erase();
                MyRefresh();
            }
        }

        private static void Explode(int row, int col)
        {
            Screen.Erase();
            AddStr(row, col, "-");
            MyRefresh();

            col--;

            GetColor();
            AddStr(row - 1, col, " - ");
            AddStr(row,     col, "-+-");
            AddStr(row + 1, col, " - ");
            MyRefresh();

            col--;

            GetColor();
            AddStr(row - 2, col, " --- ");
            AddStr(row - 1, col, "-+++-");
            AddStr(row,     col, "-+#+-");
            AddStr(row + 1, col, "-+++-");
            AddStr(row + 2, col, " --- ");
            MyRefresh();

            GetColor();
            AddStr(row - 2, col, " +++ ");
            AddStr(row - 1, col, "++#++");
            AddStr(row,     col, "+# #+");
            AddStr(row + 1, col, "++#++");
            AddStr(row + 2, col, " +++ ");
            MyRefresh();

            GetColor();
            AddStr(row - 2, col, "  #  ");
            AddStr(row - 1, col, "## ##");
            AddStr(row,     col, "#   #");
            AddStr(row + 1, col, "## ##");
            AddStr(row + 2, col, "  #  ");
            MyRefresh();

            GetColor();
            AddStr(row - 2, col, " # # ");
            AddStr(row - 1, col, "#   #");
            AddStr(row,     col, "     ");
            AddStr(row + 1, col, "#   #");
            AddStr(row + 2, col, " # # ");
            MyRefresh();
        }

        private static void AddStr(int y, int x, string str)
        {
            if (x >= 0 && x < Screen.Cols && y >= 0 && y < Screen.Lines)
                Screen.MvAddStr(y, x, str);
        }

        private static void MyRefresh()
        {
            Screen.NapMs(DELAYSIZE);
            Screen.Move(Screen.Lines - 1, Screen.Cols - 1);
            Screen.Refresh();
        }

        private static void GetColor()
        {
            uint bold = (rng.Next(2) > 0) ? Defs.A_BOLD : Defs.A_NORMAL;            
            Screen.AttrSet(Defs.COLOR_PAIR((short)rng.Next(8)) | bold);
        }

    }
}
