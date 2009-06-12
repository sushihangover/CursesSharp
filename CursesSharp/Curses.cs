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
using System.Runtime.InteropServices;

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
            get { return NativeMethods.wrap_has_widechar(); }
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

            UseWideChar = useWideChar;

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

        public static void ResizeTerm(int nlines, int ncols)
        {
            Verify(NativeMethods.wrap_resize_term(nlines, ncols));
        }

        public static void Beep()
        {
            Verify(NativeMethods.wrap_beep());
        }

        public static void Flash()
        {
            Verify(NativeMethods.wrap_flash());
        }

        public static void StartColor()
        {
            Verify(NativeMethods.wrap_start_color());
        }

        public static void InitPair(short color, short fg, short bg)
        {
            Verify(NativeMethods.wrap_init_pair(color, fg, bg));
        }

        public static void InitColor(short color, short red, short green, short blue)
        {
            Verify(NativeMethods.wrap_init_color(color, red, green, blue));
        }

        public static void ColorContent(short color, out short red, out short green, out short blue)
        {
            Verify(NativeMethods.wrap_color_content(color, out red, out green, out blue));
        }

        public static void PairContent(short color, out short fg, out short bg)
        {
            Verify(NativeMethods.wrap_pair_content(color, out fg, out bg));
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

        public static void AssumeDefaultColors(int f, int b)
        {
            Verify(NativeMethods.wrap_assume_default_colors(f, b));
        }

        public static void UseDefaultColors()
        {
            Verify(NativeMethods.wrap_use_default_colors());
        }

        public static void UngetCh(int ch)
        {
            Verify(NativeMethods.wrap_ungetch(ch));
        }

        public static void FlushInp()
        {
            Verify(NativeMethods.wrap_flushinp());
        }

        public static void CBreak()
        {
            Verify(NativeMethods.wrap_cbreak());
        }

        public static void NoCBreak()
        {
            Verify(NativeMethods.wrap_nocbreak());
        }

        public static void Echo()
        {
            Verify(NativeMethods.wrap_echo());
        }

        public static void NoEcho()
        {
            Verify(NativeMethods.wrap_noecho());
        }

        public static void HalfDelay(int tenths)
        {
            Verify(NativeMethods.wrap_halfdelay(tenths));
        }

        public static void Nl()
        {
            Verify(NativeMethods.wrap_nl());
        }

        public static void NoNl()
        {
            Verify(NativeMethods.wrap_nonl());
        }

        public static void Raw()
        {
            Verify(NativeMethods.wrap_raw());
        }

        public static void NoRaw()
        {
            Verify(NativeMethods.wrap_noraw());
        }

        public static void QiFlush()
        {
            NativeMethods.wrap_qiflush();
        }

        public static void NoQiFlush()
        {
            NativeMethods.wrap_noqiflush();
        }

        public static void DefProgMode()
        {
            Verify(NativeMethods.wrap_def_prog_mode());
        }

        public static void DefShellMode()
        {
            Verify(NativeMethods.wrap_def_shell_mode());
        }

        public static void ResetProgMode()
        {
            Verify(NativeMethods.wrap_reset_prog_mode());
        }

        public static void ResetShellMode()
        {
            Verify(NativeMethods.wrap_reset_shell_mode());
        }

        public static void ResetTty()
        {
            Verify(NativeMethods.wrap_resetty());
        }

        public static void SaveTty()
        {
            Verify(NativeMethods.wrap_savetty());
        }

        public static void GetSYX(out int y, out int x)
        {
            NativeMethods.wrap_getsyx(out y, out x);
        }

        public static void SetSYX(int y, int x)
        {
            NativeMethods.wrap_setsyx(y, x);
        }

        public static void RipOffLine(int line, RipOffLineFun init)
        {
            RipOffLineFunInt initInt = delegate(IntPtr winptr, int ncols)
            {
                return init(new Window(winptr, false), ncols);
            };
            Verify(NativeMethods.wrap_ripoffline(line, initInt));
        }

        public static void NapMs(int ms)
        {
            Verify(NativeMethods.wrap_napms(ms));
        }

        public static int CursSet(int visibility)
        {
            return NativeMethods.wrap_curs_set(visibility);
        }

        public static string KeyName(int key)
        {
            IntPtr strPtr = NativeMethods.wrap_keyname(key);
            Verify(strPtr);
            return Marshal.PtrToStringAnsi(strPtr);
        }

        public static string KeyName(char key)
        {
            IntPtr strPtr = NativeMethods.wrap_key_name(key);
            Verify(strPtr);
            return Marshal.PtrToStringAnsi(strPtr);
        }

        public static bool HasKey(int key)
        {
            return NativeMethods.wrap_has_key(key);
        }

        public static void DoUpdate()
        {
            Verify(NativeMethods.wrap_doupdate());
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

        internal static void Verify(int result, string fname)
        {
            if (result != 0)
                throw new CursesException(fname + "() returned ERR");
        }

        internal static void Verify(int result)
        {
            if (result != 0)
                throw new CursesException("Function returned ERR");
        }

        internal static void Verify(IntPtr result, string fname)
        {
            if (result == IntPtr.Zero)
                throw new CursesException(fname + "() returned NULL");
        }

        internal static void Verify(IntPtr result)
        {
            if (result == IntPtr.Zero)
                throw new CursesException("Function returned NULL");
        }
    }
}
