using System;
using Curses;

namespace RainDemo
{
    class Program
    {
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
            rng = new Random();
            if (Screen.HasColors())
            {
                Screen.StartColor();
                short bg = Defs.COLOR_BLACK;
                try
                {
                    Screen.UseDefaultColors();
                    bg = -1;
                }
                catch (CursesException) { }
                Screen.InitPair(1, Defs.COLOR_BLUE, bg);
                Screen.InitPair(2, Defs.COLOR_CYAN, bg);
            }
            Screen.Nl();
            Screen.NoEcho();
            Screen.CursSet(0);
            Screen.StdScr.Timeout(0);
            Screen.StdScr.Keypad(true);

            int r = Screen.Lines - 4, c = Screen.Cols - 4;
            int[] xpos = new int[5];
            int[] ypos = new int[5];
            for (int j = 0; j < 5; ++j)
            {
                xpos[j] = rng.Next(c) + 2;
                ypos[j] = rng.Next(r) + 2;
            }

            for (int j = 0; ; )
            {
                int x = rng.Next(c) + 2;
                int y = rng.Next(r) + 2;

                Screen.StdScr.MvAddCh(y, x, '.');

                Screen.StdScr.MvAddCh(ypos[j], xpos[j], 'o');

                j = NextJ(j);
                Screen.StdScr.MvAddCh(ypos[j], xpos[j], 'O');

                j = NextJ(j);
                Screen.StdScr.MvAddCh(ypos[j] - 1, xpos[j], '-');
                Screen.StdScr.MvAddStr(ypos[j], xpos[j] - 1, "|.|");
                Screen.StdScr.MvAddCh(ypos[j] + 1, xpos[j], '-');

                j = NextJ(j);
                Screen.StdScr.MvAddCh(ypos[j] - 2, xpos[j], '-');
                Screen.StdScr.MvAddStr(ypos[j] - 1, xpos[j] - 1, "/ \\");
                Screen.StdScr.MvAddStr(ypos[j], xpos[j] - 2, "| O |");
                Screen.StdScr.MvAddStr(ypos[j] + 1, xpos[j] - 1, "\\ /");
                Screen.StdScr.MvAddCh(ypos[j] + 2, xpos[j], '-');

                j = NextJ(j);
                Screen.StdScr.MvAddCh(ypos[j] - 2, xpos[j], ' ');
                Screen.StdScr.MvAddStr(ypos[j] - 1, xpos[j] - 1, "   ");
                Screen.StdScr.MvAddStr(ypos[j], xpos[j] - 2, "     ");
                Screen.StdScr.MvAddStr(ypos[j] + 1, xpos[j] - 1, "   ");
                Screen.StdScr.MvAddCh(ypos[j] + 2, xpos[j], ' ');

                xpos[j] = x;
                ypos[j] = y;

                switch (Screen.StdScr.GetCh())
                {
                    case 'q':
                    case 'Q':
                        Screen.CursSet(1);
                        return;
                    case 's':
                        Screen.StdScr.NoDelay(false);
                        break;
                    case ' ':
                        Screen.StdScr.NoDelay(true);
                        break;
                    default: break;
                }
                Screen.NapMs(50);
            }
        }

        private static int NextJ(int j)
        {
            j = (j + 5 - 1) % 5;
            if (Screen.HasColors())
            {
                int z = rng.Next(3);
                uint color = Defs.COLOR_PAIR(z);
                if (z > 0)
                    color |= Defs.A_BOLD;
                Screen.StdScr.AttrSet(color);
            }
            return j;
        }
    }
}
