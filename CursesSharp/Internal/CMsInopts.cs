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

namespace CursesSharp.Internal
{
    internal static partial class CursesMethods
    {
        internal static void cbreak()
        {
            int ret = wrap_cbreak();
            InternalException.Verify(ret, "cbreak");
        }

        internal static void nocbreak()
        {
            int ret = wrap_nocbreak();
            InternalException.Verify(ret, "nocbreak");
        }

        internal static void echo()
        {
            int ret = wrap_echo();
            InternalException.Verify(ret, "echo");
        }

        internal static void noecho()
        {
            int ret = wrap_noecho();
            InternalException.Verify(ret, "noecho");
        }

        internal static void halfdelay(int tenths)
        {
            int ret = wrap_halfdelay(tenths);
            InternalException.Verify(ret, "halfdelay");
        }

        internal static void intrflush(IntPtr win, bool bf)
        {
            int ret = wrap_intrflush(win, bf);
            InternalException.Verify(ret, "intrflush");
        }

        internal static void keypad(IntPtr win, bool bf)
        {
            int ret = wrap_keypad(win, bf);
            InternalException.Verify(ret, "keypad");
        }

        internal static void meta(IntPtr win, bool bf)
        {
            int ret = wrap_meta(win, bf);
            InternalException.Verify(ret, "meta");
        }

        internal static void nl()
        {
            int ret = wrap_nl();
            InternalException.Verify(ret, "nl");
        }

        internal static void nonl()
        {
            int ret = wrap_nonl();
            InternalException.Verify(ret, "nonl");
        }

        internal static void nodelay(IntPtr win, bool bf)
        {
            int ret = wrap_nodelay(win, bf);
            InternalException.Verify(ret, "nodelay");
        }

        internal static void raw()
        {
            int ret = wrap_raw();
            InternalException.Verify(ret, "raw");
        }

        internal static void noraw()
        {
            int ret = wrap_noraw();
            InternalException.Verify(ret, "noraw");
        }

        internal static void qiflush()
        {
            wrap_qiflush();
        }

        internal static void noqiflush()
        {
            wrap_noqiflush();
        }

        internal static void notimeout(IntPtr win, bool bf)
        {
            int ret = wrap_notimeout(win, bf);
            InternalException.Verify(ret, "notimeout");
        }

        internal static void wtimeout(IntPtr win, int delay)
        {
            wrap_wtimeout(win, delay);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_cbreak();
        [DllImport("CursesWrapper")]
        private static extern int wrap_nocbreak();
        [DllImport("CursesWrapper")]
        private static extern int wrap_echo();
        [DllImport("CursesWrapper")]
        private static extern int wrap_noecho();
        [DllImport("CursesWrapper")]
        private static extern int wrap_halfdelay(int tenths);
        [DllImport("CursesWrapper")]
        private static extern int wrap_intrflush(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_keypad(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_meta(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_nl();
        [DllImport("CursesWrapper")]
        private static extern int wrap_nonl();
        [DllImport("CursesWrapper")]
        private static extern int wrap_nodelay(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_raw();
        [DllImport("CursesWrapper")]
        private static extern int wrap_noraw();
        [DllImport("CursesWrapper")]
        private static extern void wrap_qiflush();
        [DllImport("CursesWrapper")]
        private static extern void wrap_noqiflush();
        [DllImport("CursesWrapper")]
        private static extern int wrap_notimeout(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wtimeout(IntPtr win, int delay);
    }
}
