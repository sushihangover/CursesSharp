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
        internal static void waddnstr(IntPtr win, string str, int n)
        {
            int ret = wrap_waddnstr(win, str, n);
            InternalException.Verify(ret, "waddnstr");
        }

        internal static void mvwaddnstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = wrap_mvwaddnstr(win, y, x, str, n);
            InternalException.Verify(ret, "mvwaddnstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_waddnstr(IntPtr win, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_mvwaddnstr(IntPtr win, int y, int x, String str, int n);
    }
}
