using System;
using System.Runtime.InteropServices;

namespace CursesSharp
{
    public delegate int RipOffLineFun(Window win, int ncols);

    public static partial class Curses
    {
        private static bool hasWideChar = false;
        private static bool checkErrors = true;
        private static Window stdscr = null;

        public static bool HasWideChar
        {
            get { return hasWideChar; }
        }

        public static bool CheckErrors
        {
            get { return checkErrors; }
            set { checkErrors = value; }
        }

        public static Window StdScr
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

        public static Window InitScr()
        {
            if (stdscr != null)
                throw new InvalidOperationException("Curses is already initialized.");

            hasWideChar = NativeMethods.wrap_has_widechar();

            IntPtr winptr = NativeMethods.wrap_initscr();
            if (winptr == IntPtr.Zero)
                throw new CursesException("initscr() failed.");

            stdscr = new Window(winptr, false);
            return stdscr;
        }

        public static void EndWin()
        {
            if (stdscr == null)
                throw new InvalidOperationException("Curses is not initialized.");
            Verify(NativeMethods.wrap_endwin());
            stdscr = null;
        }

        public static bool IsEndWin
        {
            get
            {
                return NativeMethods.wrap_isendwin();
            }
        }

        public static int ResizeTerm(int nlines, int ncols)
        {
            return Verify(NativeMethods.wrap_resize_term(nlines, ncols));
        }

        public static int Beep()
        {
            return Verify(NativeMethods.wrap_beep());
        }

        public static int Flash()
        {
            return Verify(NativeMethods.wrap_flash());
        }

        public static int StartColor()
        {
            return Verify(NativeMethods.wrap_start_color());
        }

        public static int InitPair(short color, short fg, short bg)
        {
            return Verify(NativeMethods.wrap_init_pair(color, fg, bg));
        }

        public static int InitColor(short color, short red, short green, short blue)
        {
            return Verify(NativeMethods.wrap_init_color(color, red, green, blue));
        }

        public static int ColorContent(short color, out short red, out short green, out short blue)
        {
            return Verify(NativeMethods.wrap_color_content(color, out red, out green, out blue));
        }

        public static int PairContent(short color, out short fg, out short bg)
        {
            return Verify(NativeMethods.wrap_pair_content(color, out fg, out bg));
        }

        public static bool HasColors
        {
            get
            {
                return NativeMethods.wrap_has_colors();
            }
        }

        public static bool CanChangeColor
        {
            get
            {
                return NativeMethods.wrap_can_change_color();
            }
        }

        public static int AssumeDefaultColors(int f, int b)
        {
            return Verify(NativeMethods.wrap_assume_default_colors(f, b));
        }

        public static int UseDefaultColors()
        {
            return Verify(NativeMethods.wrap_use_default_colors());
        }

        public static int UngetCh(int ch)
        {
            return Verify(NativeMethods.wrap_ungetch(ch));
        }

        public static int FlushInp()
        {
            return Verify(NativeMethods.wrap_flushinp());
        }

        public static int CBreak()
        {
            return Verify(NativeMethods.wrap_cbreak());
        }

        public static int NoCBreak()
        {
            return Verify(NativeMethods.wrap_nocbreak());
        }

        public static int Echo()
        {
            return Verify(NativeMethods.wrap_echo());
        }

        public static int NoEcho()
        {
            return Verify(NativeMethods.wrap_noecho());
        }

        public static int HalfDelay(int tenths)
        {
            return Verify(NativeMethods.wrap_halfdelay(tenths));
        }

        public static int Nl()
        {
            return Verify(NativeMethods.wrap_nl());
        }

        public static int NoNl()
        {
            return Verify(NativeMethods.wrap_nonl());
        }

        public static int Raw()
        {
            return Verify(NativeMethods.wrap_raw());
        }

        public static int NoRaw()
        {
            return Verify(NativeMethods.wrap_noraw());
        }

        public static void QiFlush()
        {
            NativeMethods.wrap_qiflush();
        }

        public static void NoQiFlush()
        {
            NativeMethods.wrap_noqiflush();
        }

        public static int DefProgMode()
        {
            return Verify(NativeMethods.wrap_def_prog_mode());
        }

        public static int DefShellMode()
        {
            return Verify(NativeMethods.wrap_def_shell_mode());
        }

        public static int ResetProgMode()
        {
            return Verify(NativeMethods.wrap_reset_prog_mode());
        }

        public static int ResetShellMode()
        {
            return Verify(NativeMethods.wrap_reset_shell_mode());
        }

        public static int ResetTty()
        {
            return Verify(NativeMethods.wrap_resetty());
        }

        public static int SaveTty()
        {
            return Verify(NativeMethods.wrap_savetty());
        }

        public static void GetSYX(out int y, out int x)
        {
            NativeMethods.wrap_getsyx(out y, out x);
        }

        public static void SetSYX(int y, int x)
        {
            NativeMethods.wrap_setsyx(y, x);
        }

        public static int RipOffLine(int line, RipOffLineFun init)
        {
            RipOffLineFunInt initInt = delegate(IntPtr winptr, int ncols)
            {
                return init(new Window(winptr, false), ncols);
            };
            return Verify(NativeMethods.wrap_ripoffline(line, initInt));
        }

        public static int NapMs(int ms)
        {
            return Verify(NativeMethods.wrap_napms(ms));
        }

        public static int CursSet(int visibility)
        {
            return NativeMethods.wrap_curs_set(visibility);
        }

        public static string KeyName(int key)
        {
            IntPtr strPtr = Verify(NativeMethods.wrap_keyname(key));
            return Marshal.PtrToStringAnsi(strPtr);
        }

        public static string KeyName(char key)
        {
            IntPtr strPtr = Verify(NativeMethods.wrap_key_name(key));
            return Marshal.PtrToStringAnsi(strPtr);
        }

        public static bool HasKey(int key)
        {
            return NativeMethods.wrap_has_key(key);
        }

        public static int DoUpdate()
        {
            return Verify(NativeMethods.wrap_doupdate());
        }

        public static void TraceOn()
        {
            NativeMethods.wrap_traceon();
        }

        public static void TraceOff()
        {
            NativeMethods.wrap_traceoff();
        }

        public static Window NewWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr winptr = NativeMethods.wrap_newwin(nlines, ncols, begy, begx);
            if (winptr == IntPtr.Zero)
                throw new CursesException("newwin() failed.");

            return new Window(winptr, true);
        }

        internal static int Verify(int result)
        {
            if (checkErrors && result != 0)
                throw new CursesException("Function failed.");
            return result;
        }

        internal static IntPtr Verify(IntPtr result)
        {
            if (checkErrors && result == IntPtr.Zero)
                throw new CursesException("Function failed.");
            return result;
        }
    }
}
