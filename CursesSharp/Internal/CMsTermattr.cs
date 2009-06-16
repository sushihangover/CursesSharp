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
        internal static int baudrate()
        {
            int ret = wrap_baudrate();
            InternalException.Verify(ret, "baudrate");
            return ret;
        }

        internal static char erasechar()
        {
            return wrap_erasechar();
        }

        internal static char killchar()
        {
            return wrap_killchar();
        }

        internal static uint termattrs()
        {
            return wrap_termattrs();
        }

        internal static bool has_ic()
        {
            return wrap_has_ic();
        }

        internal static bool has_il()
        {
            return wrap_has_il();
        }

        internal static string termname()
        {
            IntPtr ret = wrap_termname();
            InternalException.Verify(ret, "termname");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static string longname()
        {
            IntPtr ret = wrap_longname();
            InternalException.Verify(ret, "longname");
            return Marshal.PtrToStringAnsi(ret);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_baudrate();
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern char wrap_erasechar();
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern char wrap_killchar();
        [DllImport("CursesWrapper")]
        private static extern uint wrap_termattrs();
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_has_ic();
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_has_il();
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_termname();
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_longname();
    }
}
