using System;
using CursesSharp;

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
            Curses.InitScr();
            try
            {
                Main2();
            }
            finally
            {
                Curses.EndWin();
            }
        }

        private static Random rng;

        private static void Main2()
        {
            Curses.NoDelay = true;
            Curses.NoEcho();

            if (Curses.HasColors)
            {
                Curses.StartColor();
                for (short i = 1; i < 8; ++i)
                    Curses.InitPair(i, color_table[i], Defs.COLOR_BLACK);
            }

            rng = new Random();
            int flag = 0;
            while (Curses.GetCh() == -1)
            {
                int start, end, row, diff, direction;
                do
                {
                    start = rng.Next(Curses.Cols - 3);
                    end = rng.Next(Curses.Cols - 3);
                    start = (start < 2) ? 2 : start;
                    end = (end < 2) ? 2 : end;
                    direction = (start > end) ? -1 : 1;
                    diff = Math.Abs(start - end);
                } while (diff < 2 || diff >= Curses.Lines - 2);

                Curses.AttrSet(Defs.A_NORMAL);
                for (row = 1; row < diff; ++row)
                {
                    Curses.MvAddStr(Curses.Lines - row, row * direction + start, (direction < 0) ? "\\" : "/");
                    if (flag++ > 0)
                    {
                        MyRefresh();
                        Curses.Erase();
                        flag = 0;
                    }
                }

                if (flag++ > 0)
                {
                    MyRefresh();
                    flag = 0;
                }

                Explode(Curses.Lines - row, diff * direction + start);
                Curses.Erase();
                MyRefresh();
            }
        }

        private static void Explode(int row, int col)
        {
            Curses.Erase();
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
            if (x >= 0 && x < Curses.Cols && y >= 0 && y < Curses.Lines)
                Curses.MvAddStr(y, x, str);
        }

        private static void MyRefresh()
        {
            Curses.NapMs(DELAYSIZE);
            Curses.Move(Curses.Lines - 1, Curses.Cols - 1);
            Curses.Refresh();
        }

        private static void GetColor()
        {
            uint bold = (rng.Next(2) > 0) ? Defs.A_BOLD : Defs.A_NORMAL;            
            Curses.AttrSet(Defs.COLOR_PAIR((short)rng.Next(8)) | bold);
        }

    }
}
