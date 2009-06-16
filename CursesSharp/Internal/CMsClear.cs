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
        internal static void wclear(IntPtr win)
        {
            int ret = wrap_wclear(win);
            InternalException.Verify(ret, "wclear");
        }

        internal static void werase(IntPtr win)
        {
            int ret = wrap_werase(win);
            InternalException.Verify(ret, "werase");
        }

        internal static void wclrtobot(IntPtr win)
        {
            int ret = wrap_wclrtobot(win);
            InternalException.Verify(ret, "wclrtobot");
        }

        internal static void wclrtoeol(IntPtr win)
        {
            int ret = wrap_wclrtoeol(win);
            InternalException.Verify(ret, "wclrtoeol");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wclear(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_werase(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wclrtobot(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wclrtoeol(IntPtr win);
    }
}
