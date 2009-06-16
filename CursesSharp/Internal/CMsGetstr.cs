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
using System.Text;

namespace CursesSharp.Internal
{
    internal static partial class CursesMethods
    {
#if HAVE_USE_WIDECHAR
        internal static void wgetnstr(IntPtr win, StringBuilder wstr, int n)
        {
            int ret = wrap_wgetn_wstr(win, wstr, n);
            InternalException.Verify(ret, "wgetn_wstr");
        }

        internal static void mvwgetnstr(IntPtr win, int y, int x, StringBuilder wstr, int n)
        {
            int ret = wrap_mvwgetn_wstr(win, y, x, wstr, n);
            InternalException.Verify(ret, "mvwgetn_wstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_wgetn_wstr(IntPtr win, StringBuilder wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_mvwgetn_wstr(IntPtr win, int y, int x, StringBuilder wstr, int n);
#else
        internal static void wgetnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = wrap_wgetnstr(win, str, n);
            InternalException.Verify(ret, "wgetnstr");
        }

        internal static void mvwgetnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = wrap_mvwgetnstr(win, y, x, str, n);
            InternalException.Verify(ret, "mvwgetnstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_wgetnstr(IntPtr win, StringBuilder str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwgetnstr(IntPtr win, int y, int x, StringBuilder str, int n);
#endif
    }
}
