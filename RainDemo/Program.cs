/*
 * This is a test program for CursesSharp.
 * Based on rain.c demo from the PDCurses library 
 * (http://pdcurses.sourceforge.net/)
 */

using System;
using CursesSharp;

namespace RainDemo
{
    class Program
    {
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
            rng = new Random();
            if (Curses.HasColors)
            {
                Curses.StartColor();
                short bg = Defs.COLOR_BLACK;
                try
                {
                    Curses.UseDefaultColors();
                    bg = -1;
                }
                catch (CursesException) { }
                Curses.InitPair(1, Defs.COLOR_BLUE, bg);
                Curses.InitPair(2, Defs.COLOR_CYAN, bg);
            }
            Curses.Nl = true;
            Curses.Echo = false;
            Curses.CursSet(0);
            Curses.Timeout = 0;
            Curses.Keypad = true;

            int r = Curses.Lines - 4, c = Curses.Cols - 4;
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

                Curses.AddCh(y, x, '.');

                Curses.AddCh(ypos[j], xpos[j], 'o');

                j = NextJ(j);
                Curses.AddCh(ypos[j], xpos[j], 'O');

                j = NextJ(j);
                Curses.AddCh(ypos[j] - 1, xpos[j], '-');
                Curses.AddStr(ypos[j], xpos[j] - 1, "|.|");
                Curses.AddCh(ypos[j] + 1, xpos[j], '-');

                j = NextJ(j);
                Curses.AddCh(ypos[j] - 2, xpos[j], '-');
                Curses.AddStr(ypos[j] - 1, xpos[j] - 1, "/ \\");
                Curses.AddStr(ypos[j], xpos[j] - 2, "| O |");
                Curses.AddStr(ypos[j] + 1, xpos[j] - 1, "\\ /");
                Curses.AddCh(ypos[j] + 2, xpos[j], '-');

                j = NextJ(j);
                Curses.AddCh(ypos[j] - 2, xpos[j], ' ');
                Curses.AddStr(ypos[j] - 1, xpos[j] - 1, "   ");
                Curses.AddStr(ypos[j], xpos[j] - 2, "     ");
                Curses.AddStr(ypos[j] + 1, xpos[j] - 1, "   ");
                Curses.AddCh(ypos[j] + 2, xpos[j], ' ');

                xpos[j] = x;
                ypos[j] = y;

                switch (Curses.GetCh())
                {
                    case 'q':
                    case 'Q':
                        Curses.CursSet(1);
                        return;
                    case 's':
                        Curses.NoDelay = false;
                        break;
                    case ' ':
                        Curses.NoDelay = true;
                        break;
                    default: break;
                }
                Curses.NapMs(50);
            }
        }

        private static int NextJ(int j)
        {
            j = (j + 5 - 1) % 5;
            if (Curses.HasColors)
            {
                int z = rng.Next(3);
                uint color = Defs.COLOR_PAIR(z);
                if (z > 0)
                    color |= Defs.A_BOLD;
                Curses.AttrSet(color);
            }
            return j;
        }
    }
}
