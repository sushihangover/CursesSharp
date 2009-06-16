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
        internal static int wgetch(IntPtr win)
        {
            return wrap_wgetch(win);
        }

        internal static int mvwgetch(IntPtr win, int y, int x)
        {
            return wrap_mvwgetch(win, y, x);
        }

        internal static void ungetch(int ch)
        {
            int ret = wrap_ungetch(ch);
            InternalException.Verify(ret, "ungetch");
        }

        internal static void flushinp()
        {
            int ret = wrap_flushinp();
            InternalException.Verify(ret, "flushinp");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_wgetch(IntPtr win);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwgetch(IntPtr win, int y, int x);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_ungetch(int ch);
        [DllImport("CursesWrapper")]
        private static extern int wrap_flushinp();
    }
}
