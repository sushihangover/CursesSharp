#region Copyright 2009 Robert Konklewski

/*
 * CursesSharp
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * www.gnu.org/licenses/>.
 * 
 */

#endregion

using System;

namespace CursesSharp
{
    /// <summary>
    /// A callback function type for use in RipOffLine method.
    /// </summary>
    /// <param name="win"></param>
    /// <param name="ncols"></param>
    /// <returns></returns>
    public delegate int RipOffLineFun(Window win, int ncols);

    /// <summary>
    /// Static interface to the curses library.
    /// </summary>
    public static partial class Curses
    {
        private static bool useWideChar = true;
        private static Window stdscr = null;

        /// <summary>
        /// Returns the status of wide character (UTF-16) support in 
        /// the curses library wrapper.
        /// </summary>
        public static bool HasWideChar
        {
            get { return CursesMethods.has_widechar(); }
        }

        public static bool UseWideChar
        {
            get { return useWideChar; }
            set { useWideChar = value && HasWideChar; }
        }

        public static Window StdScr
        {
            get { return stdscr; }
        }

        public static int Lines
        {
            get { return CursesMethods.LINES(); }
        }

        public static int Cols
        {
            get { return CursesMethods.COLS(); }
        }

        public static int Colors
        {
            get { return CursesMethods.COLORS(); }
        }

        public static int ColorPairs
        {
            get { return CursesMethods.COLOR_PAIRS(); }
        }

        public static int TabSize
        {
            get { return CursesMethods.TABSIZE(); }
        }

        public static Window InitScr()
        {
            if (stdscr != null)
                throw new InvalidOperationException("Curses is already initialized.");

            UseWideChar = useWideChar;

            IntPtr winptr = CursesMethods.initscr();
            stdscr = new Window(winptr, false);

            return stdscr;
        }

        public static void EndWin()
        {
            if (stdscr == null)
                throw new InvalidOperationException("Curses is not initialized.");
            CursesMethods.endwin();
            stdscr = null;
        }

        public static bool IsEndWin
        {
            get
            {
                return CursesMethods.isendwin();
            }
        }

        public static void ResizeTerm(int nlines, int ncols)
        {
            CursesMethods.resize_term(nlines, ncols);
        }

        public static void Beep()
        {
            CursesMethods.beep();
        }

        public static void Flash()
        {
            CursesMethods.flash();
        }

        public static void StartColor()
        {
            CursesMethods.start_color();
        }

        public static void InitPair(short color, short fg, short bg)
        {
            CursesMethods.init_pair(color, fg, bg);
        }

        public static void InitColor(short color, short red, short green, short blue)
        {
            CursesMethods.init_color(color, red, green, blue);
        }

        public static void ColorContent(short color, out short red, out short green, out short blue)
        {
            CursesMethods.color_content(color, out red, out green, out blue);
        }

        public static void PairContent(short color, out short fg, out short bg)
        {
            CursesMethods.pair_content(color, out fg, out bg);
        }

        public static bool HasColors
        {
            get
            {
                return CursesMethods.has_colors();
            }
        }

        public static bool CanChangeColor
        {
            get
            {
                return CursesMethods.can_change_color();
            }
        }

        public static void AssumeDefaultColors(int f, int b)
        {
            CursesMethods.assume_default_colors(f, b);
        }

        public static void UseDefaultColors()
        {
            CursesMethods.use_default_colors();
        }

        public static void UngetCh(int ch)
        {
            CursesMethods.ungetch(ch);
        }

        public static void FlushInp()
        {
            CursesMethods.flushinp();
        }

        public static bool CBreak
        {
            set
            {
                if (value)
                    CursesMethods.cbreak();
                else
                    CursesMethods.nocbreak();
            }
        }

        public static bool Echo
        {
            set
            {
                if (value)
                    CursesMethods.echo();
                else
                    CursesMethods.noecho();
            }
        }

        public static void HalfDelay(int tenths)
        {
            CursesMethods.halfdelay(tenths);
        }

        public static bool Nl
        {
            set
            {
                if (value)
                    CursesMethods.nl();
                else
                    CursesMethods.nonl();
            }
        }

        public static bool Raw
        {
            set
            {
                if (value)
                    CursesMethods.raw();
                else
                    CursesMethods.noraw();
            }
        }

        public static bool QiFlush
        {
            set
            {
                if (value)
                    CursesMethods.qiflush();
                else
                    CursesMethods.noqiflush();
            }
        }

        public static void DefProgMode()
        {
            CursesMethods.def_prog_mode();
        }

        public static void DefShellMode()
        {
            CursesMethods.def_shell_mode();
        }

        public static void ResetProgMode()
        {
            CursesMethods.reset_prog_mode();
        }

        public static void ResetShellMode()
        {
            CursesMethods.reset_shell_mode();
        }

        public static void ResetTty()
        {
            CursesMethods.resetty();
        }

        public static void SaveTty()
        {
            CursesMethods.savetty();
        }

        public static void GetSYX(out int y, out int x)
        {
            CursesMethods.getsyx(out y, out x);
        }

        public static void SetSYX(int y, int x)
        {
            CursesMethods.setsyx(y, x);
        }

        public static void RipOffLine(int line, RipOffLineFun init)
        {
            RipOffLineFunInt initInt = delegate(IntPtr winptr, int ncols)
            {
                return init(new Window(winptr, false), ncols);
            };
            CursesMethods.ripoffline(line, initInt);
        }

        public static void NapMs(int ms)
        {
            CursesMethods.napms(ms);
        }

        public static int CursSet(int visibility)
        {
            return CursesMethods.curs_set(visibility);
        }

        public static string KeyName(int key)
        {
            return CursesMethods.keyname(key);
        }

        public static string KeyName(char key)
        {
            return CursesMethods.key_name(key);
        }

        public static bool HasKey(int key)
        {
            return CursesMethods.has_key(key);
        }

        public static void DoUpdate()
        {
            CursesMethods.doupdate();
        }

        public static void TraceOn()
        {
            CursesMethods.traceon();
        }

        public static void TraceOff()
        {
            CursesMethods.traceoff();
        }

        public static Window NewWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr winptr = CursesMethods.newwin(nlines, ncols, begy, begx);
            return new Window(winptr, true);
        }
    }
}
