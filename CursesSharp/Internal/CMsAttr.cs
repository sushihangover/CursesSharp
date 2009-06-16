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
        internal static void wattroff(IntPtr win, uint attrs)
        {
            int ret = wrap_wattroff(win, attrs);
            InternalException.Verify(ret, "wattroff");
        }

        internal static void wattron(IntPtr win, uint attrs)
        {
            int ret = wrap_wattron(win, attrs);
            InternalException.Verify(ret, "wattron");
        }

        internal static void wattrset(IntPtr win, uint attrs)
        {
            int ret = wrap_wattrset(win, attrs);
            InternalException.Verify(ret, "wattrset");
        }

        internal static void wstandend(IntPtr win)
        {
            int ret = wrap_wstandend(win);
            InternalException.Verify(ret, "wstandend");
        }

        internal static void wstandout(IntPtr win)
        {
            int ret = wrap_wstandout(win);
            InternalException.Verify(ret, "wstandout");
        }

        internal static void wcolor_set(IntPtr win, short color_pair)
        {
            int ret = wrap_wcolor_set(win, color_pair);
            InternalException.Verify(ret, "wcolor_set");
        }

        internal static void wattr_get(IntPtr win, out uint attrs, out short color_pair)
        {
            int ret = wrap_wattr_get(win, out attrs, out color_pair);
            InternalException.Verify(ret, "wattr_get");
        }

        internal static void wchgat(IntPtr win, int n, uint attr, short color)
        {
            int ret = wrap_wchgat(win, n, attr, color);
            InternalException.Verify(ret, "wchgat");
        }

        internal static void mvwchgat(IntPtr win, int y, int x, int n, uint attr, short color)
        {
            int ret = wrap_mvwchgat(win, y, x, n, attr, color);
            InternalException.Verify(ret, "mvwchgat");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wattroff(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wattron(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wattrset(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wstandend(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wstandout(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wcolor_set(IntPtr win, short color_pair);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wattr_get(IntPtr win, out uint attrs, out short color_pair);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wchgat(IntPtr win, int n, uint attr, short color);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwchgat(IntPtr win, int y, int x, int n, uint attr, short color);
    }
}
