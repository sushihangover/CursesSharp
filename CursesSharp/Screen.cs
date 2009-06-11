using System;

namespace Curses
{
    public static class Screen
    {
        private static bool hasWideChar = false;
        private static StdWindow stdscr = null;

        public static bool HasWideChar
        {
            get { return hasWideChar; }
        }

        public static IWindow StdScr
        {
            get { return stdscr; }
        }

        public static int Lines
        {
            get { return NativeMethods.wrap_LINES(); }
        }

        public static int Cols
        {
            get { return NativeMethods.wrap_COLS(); }
        }

        public static int Colors
        {
            get { return NativeMethods.wrap_COLORS(); }
        }

        public static int TabSize
        {
            get { return NativeMethods.wrap_TABSIZE(); }
        }

        public static IWindow InitScr()
        {
            if (stdscr != null)
                throw new InvalidOperationException("Curses is already initialized.");

            hasWideChar = NativeMethods.wrap_has_widechar();

            IntPtr winptr = NativeMethods.wrap_initscr();
            if (winptr == IntPtr.Zero)
                throw new CursesException("initscr() failed.");

            stdscr = new StdWindow(winptr);
            return stdscr;
        }

        public static void EndWin()
        {
            if (stdscr == null)
                throw new InvalidOperationException("Curses is not initialized.");
            if (NativeMethods.wrap_endwin() != 0)
                throw new CursesException("endwin() failed.");
            stdscr = null;
        }

        public static void StartColor()
        {
            if (NativeMethods.wrap_start_color() != 0)
                throw new CursesException("start_color() failed.");
        }

        public static bool HasColors
        {
            get
            {
                return NativeMethods.wrap_has_colors();
            }
        }

        public static void InitPair(short color, short fg, short bg)
        {
            if (NativeMethods.wrap_init_pair(color, fg, bg) != 0)
                throw new CursesException("init_pair() failed.");
        }

        public static void UseDefaultColors()
        {
            if (NativeMethods.wrap_use_default_colors() != 0)
                throw new CursesException("use_default_colors() failed.");
        }

        public static bool Echo
        {
            set
            {
                if (value)
                {
                    if (NativeMethods.wrap_echo() != 0)
                        throw new CursesException("echo() failed.");
                }
                else
                {
                    if (NativeMethods.wrap_noecho() != 0)
                        throw new CursesException("noecho() failed.");
                }
            }
        }

        public static bool Nl
        {
            set
            {
                if (value)
                {
                    if (NativeMethods.wrap_nl() != 0)
                        throw new CursesException("nl() failed.");
                }
                else
                {
                    if (NativeMethods.wrap_nonl() != 0)
                        throw new CursesException("nonl() failed.");
                }
            }
        }

        public static bool Raw
        {
            set
            {
                if (value)
                {
                    if (NativeMethods.wrap_raw() != 0)
                        throw new CursesException("raw() failed.");
                }
                else
                {
                    if (NativeMethods.wrap_noraw() != 0)
                        throw new CursesException("noraw() failed.");
                }
            }
        }

        public static void NapMs(int ms)
        {
            if (NativeMethods.wrap_napms(ms) != 0)
                throw new CursesException("napms() failed.");
        }

        public static int CursSet(int visibility)
        {
            return NativeMethods.wrap_curs_set(visibility);
        }

        public static void TraceOn()
        {
            NativeMethods.wrap_traceon();
        }

        public static void TraceOff()
        {
            NativeMethods.wrap_traceoff();
        }

        #region StdScr shortcuts

        public static void AddCh(char ch)
        {
            StdScr.AddCh(ch);
        }

        public static void AddCh(uint ch)
        {
            StdScr.AddCh(ch);
        }

        public static void MvAddCh(int y, int x, char ch)
        {
            StdScr.MvAddCh(y, x, ch);
        }

        public static void MvAddCh(int y, int x, uint ch)
        {
            StdScr.MvAddCh(y, x, ch);
        }

        public static void AddStr(string str)
        {
            StdScr.AddStr(str);
        }

        public static void MvAddStr(int y, int x, string str)
        {
            StdScr.MvAddStr(y, x, str);
        }

        public static void AttrSet(uint attr)
        {
            StdScr.AttrSet(attr);
        }

        public static void Erase()
        {
            StdScr.Erase();
        }

        public static int GetCh()
        {
            return StdScr.GetCh();
        }

        public static bool Keypad
        {
            set { StdScr.Keypad = value; }
        }

        public static bool NoDelay
        {
            set { StdScr.NoDelay = value; }
        }

        public static int Timeout
        {
            set { StdScr.Timeout = value; }
        }

        public static void Move(int y, int x)
        {
            StdScr.Move(y, x);
        }

        public static void Refresh()
        {
            StdScr.Refresh();
        }

        #endregion
    }
}
