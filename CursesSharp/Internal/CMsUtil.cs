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
        internal static string unctrl(uint c)
        {
            IntPtr ret = wrap_unctrl(c);
            InternalException.Verify(ret, "unctrl");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static void filter()
        {
            wrap_filter();
        }

        internal static void use_env(bool x)
        {
            wrap_use_env(x);
        }

        internal static void delay_output(int ms)
        {
            int ret = wrap_delay_output(ms);
            InternalException.Verify(ret, "delay_output");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_unctrl(uint c);
        [DllImport("CursesWrapper")]
        private static extern void wrap_filter();
        [DllImport("CursesWrapper")]
        private static extern void wrap_use_env(Boolean x);
        [DllImport("CursesWrapper")]
        private static extern int wrap_delay_output(int ms);
    }
}
