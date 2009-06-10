using System;
using Curses;

namespace FireworkDemo
{
    class Program
    {
        private const int DELAYSIZE = 200;

        static void Main(string[] args)
        {
            IWindow stdscr = Screen.InitScr();
            try
            {
                Main2(stdscr);
            }
            finally
            {
                Screen.EndWin();
            }
        }

        private static void Main2(IWindow stdscr)
        {
            stdscr.NoDelay(true);
            Screen.NoEcho();

            if (Screen.HasColors())
            {
                Screen.StartColor();
                for (short i = 1; i < 8; ++i)
                    Screen.InitPair(i, 7, 0);
            }

            Random rng = new Random();
            int flag = 0;
            while (stdscr.GetCh() == -1)
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

                stdscr.AttrSet(0);
                for (row = 1; row < diff; ++row)
                {
                    stdscr.MvAddStr(Screen.Lines - row, row * direction + start, (direction < 0) ? "\\" : "/");
                    if (flag++ > 0)
                    {
                        MyRefresh(stdscr);
                        stdscr.Erase();
                        flag = 0;
                    }
                }

                if (flag++ > 0)
                {
                    MyRefresh(stdscr);
                    flag = 0;
                }

                Explode(rng, stdscr, Screen.Lines - row, diff * direction + start);
                stdscr.Erase();
                MyRefresh(stdscr);
            }
        }

        private static void Explode(Random rng, IWindow stdscr, int row, int col)
        {
            stdscr.Erase();
            AddStr(stdscr, row, col, "-");
            MyRefresh(stdscr);

            col--;

            GetColor(rng, stdscr);
            AddStr(stdscr, row - 1, col, " - ");
            AddStr(stdscr, row,     col, "-+-");
            AddStr(stdscr, row + 1, col, " - ");
            MyRefresh(stdscr);

            col--;

            GetColor(rng, stdscr);
            AddStr(stdscr, row - 2, col, " --- ");
            AddStr(stdscr, row - 1, col, "-+++-");
            AddStr(stdscr, row,     col, "-+#+-");
            AddStr(stdscr, row + 1, col, "-+++-");
            AddStr(stdscr, row + 2, col, " --- ");
            MyRefresh(stdscr);

            GetColor(rng, stdscr);
            AddStr(stdscr, row - 2, col, " +++ ");
            AddStr(stdscr, row - 1, col, "++#++");
            AddStr(stdscr, row,     col, "+# #+");
            AddStr(stdscr, row + 1, col, "++#++");
            AddStr(stdscr, row + 2, col, " +++ ");
            MyRefresh(stdscr);

            GetColor(rng, stdscr);
            AddStr(stdscr, row - 2, col, "  #  ");
            AddStr(stdscr, row - 1, col, "## ##");
            AddStr(stdscr, row,     col, "#   #");
            AddStr(stdscr, row + 1, col, "## ##");
            AddStr(stdscr, row + 2, col, "  #  ");
            MyRefresh(stdscr);

            GetColor(rng, stdscr);
            AddStr(stdscr, row - 2, col, " # # ");
            AddStr(stdscr, row - 1, col, "#   #");
            AddStr(stdscr, row,     col, "     ");
            AddStr(stdscr, row + 1, col, "#   #");
            AddStr(stdscr, row + 2, col, " # # ");
            MyRefresh(stdscr);
        }

        private static void AddStr(IWindow stdscr, int y, int x, string str)
        {
            if (x >= 0 && x < Screen.Cols && y >= 0 && y < Screen.Lines)
                stdscr.MvAddStr(y, x, str);
        }

        private static void MyRefresh(IWindow stdscr)
        {
            Screen.NapMs(DELAYSIZE);
            stdscr.Move(Screen.Lines - 1, Screen.Cols - 1);
            stdscr.Refresh();
        }

        private static void GetColor(Random rng, IWindow stdscr)
        {
            uint bold = (rng.Next(2) > 0) ? 0x00800000U : 0U;
            stdscr.AttrSet(Screen.COLOR_PAIR((short)rng.Next(8)) | bold);
        }

    }
}
