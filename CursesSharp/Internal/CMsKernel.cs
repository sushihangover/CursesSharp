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
    internal delegate int RipOffLineFunInt(IntPtr win, int cols);

    internal static partial class CursesMethods
    {
        internal static void def_prog_mode()
        {
            int ret = wrap_def_prog_mode();
            InternalException.Verify(ret, "def_prog_mode");
        }

        internal static void def_shell_mode()
        {
            int ret = wrap_def_shell_mode();
            InternalException.Verify(ret, "def_shell_mode");
        }

        internal static void reset_prog_mode()
        {
            int ret = wrap_reset_prog_mode();
            InternalException.Verify(ret, "reset_prog_mode");
        }

        internal static void reset_shell_mode()
        {
            int ret = wrap_reset_shell_mode();
            InternalException.Verify(ret, "reset_shell_mode");
        }

        internal static void resetty()
        {
            int ret = wrap_resetty();
            InternalException.Verify(ret, "resetty");
        }

        internal static void savetty()
        {
            int ret = wrap_savetty();
            InternalException.Verify(ret, "savetty");
        }

        internal static void getsyx(out int y, out int x)
        {
            wrap_getsyx(out y, out x);
        }

        internal static void setsyx(int y, int x)
        {
            wrap_setsyx(y, x);
        }

        internal static void ripoffline(int line, RipOffLineFunInt init)
        {
            int ret = wrap_ripoffline(line, init);
            InternalException.Verify(ret, "ripoffline");
        }

        internal static void napms(int ms)
        {
            int ret = wrap_napms(ms);
            InternalException.Verify(ret, "napms");
        }

        internal static int curs_set(int visibility)
        {
            return wrap_curs_set(visibility);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_def_prog_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_def_shell_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_reset_prog_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_reset_shell_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_resetty();
        [DllImport("CursesWrapper")]
        private static extern int wrap_savetty();
        [DllImport("CursesWrapper")]
        private static extern void wrap_getsyx(out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_setsyx(int y, int x);
        [DllImport("CursesWrapper")]
        private static extern int wrap_ripoffline(int line, RipOffLineFunInt init);
        [DllImport("CursesWrapper")]
        private static extern int wrap_napms(int ms);
        [DllImport("CursesWrapper")]
        private static extern int wrap_curs_set(int visibility);
    }
}
