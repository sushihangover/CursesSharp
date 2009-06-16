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
        internal static void scroll(IntPtr win)
        {
            int ret = wrap_scroll(win);
            InternalException.Verify(ret, "scroll");
        }

        internal static void wscrl(IntPtr win, int n)
        {
            int ret = wrap_wscrl(win, n);
            InternalException.Verify(ret, "wscrl");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_scroll(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wscrl(IntPtr win, int n);
    }
}
