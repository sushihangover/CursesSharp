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
        internal static void touchwin(IntPtr win)
        {
            int ret = wrap_touchwin(win);
            InternalException.Verify(ret, "touchwin");
        }

        internal static void touchline(IntPtr win, int start, int count)
        {
            int ret = wrap_touchline(win, start, count);
            InternalException.Verify(ret, "touchline");
        }

        internal static void untouchwin(IntPtr win)
        {
            int ret = wrap_untouchwin(win);
            InternalException.Verify(ret, "untouchwin");
        }

        internal static void wtouchln(IntPtr win, int y, int n, int changed)
        {
            int ret = wrap_wtouchln(win, y, n, changed);
            InternalException.Verify(ret, "wtouchln");
        }

        internal static bool is_linetouched(IntPtr win, int line)
        {
            return wrap_is_linetouched(win, line);
        }

        internal static bool is_wintouched(IntPtr win)
        {
            return wrap_is_wintouched(win);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_touchwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_touchline(IntPtr win, int start, int count);
        [DllImport("CursesWrapper")]
        private static extern int wrap_untouchwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wtouchln(IntPtr win, int y, int n, int changed);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_is_linetouched(IntPtr win, int line);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_is_wintouched(IntPtr win);
    }
}
