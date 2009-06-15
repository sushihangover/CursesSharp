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
        internal static void getyx(IntPtr win, out int y, out int x)
        {
            wrap_getyx(win, out y, out x);
        }

        internal static void getparyx(IntPtr win, out int y, out int x)
        {
            wrap_getparyx(win, out y, out x);
        }

        internal static void getbegyx(IntPtr win, out int y, out int x)
        {
            wrap_getbegyx(win, out y, out x);
        }

        internal static void getmaxyx(IntPtr win, out int y, out int x)
        {
            wrap_getmaxyx(win, out y, out x);
        }

        [DllImport("CursesWrapper")]
        private static extern void wrap_getyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_getparyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_getbegyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_getmaxyx(IntPtr win, out int y, out int x);
    }
}
