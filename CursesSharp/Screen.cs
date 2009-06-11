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

        public static bool HasColors()
        {
            return NativeMethods.wrap_has_colors();
        }

        public static void InitPair(short color, short fg, short bg)
        {
            if (NativeMethods.wrap_init_pair(color, fg, bg) != 0)
                throw new CursesException("init_pair() failed.");
        }

        public static void Echo()
        {
            if (NativeMethods.wrap_echo() != 0)
                throw new CursesException("echo() failed.");
        }

        public static void NoEcho()
        {
            if (NativeMethods.wrap_noecho() != 0)
                throw new CursesException("noecho() failed.");
        }

        public static void Raw()
        {
            if (NativeMethods.wrap_raw() != 0)
                throw new CursesException("raw() failed.");
        }

        public static void NoRaw()
        {
            if (NativeMethods.wrap_noraw() != 0)
                throw new CursesException("noraw() failed.");
        }

        public static void NapMs(int ms)
        {
            if (NativeMethods.wrap_napms(ms) != 0)
                throw new CursesException("napms() failed.");
        }

        public static void TraceOn()
        {
            NativeMethods.wrap_traceon();
        }

        public static void TraceOff()
        {
            NativeMethods.wrap_traceoff();
        }
    }
}
