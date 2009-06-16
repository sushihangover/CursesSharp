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
        internal static int winchnstr(IntPtr win, uint[] ch, int n)
        {
            int ret = wrap_winchnstr(win, ch, n);
            InternalException.Verify(ret, "winchnstr");
            return ret;
        }

        internal static int mvwinchnstr(IntPtr win, int y, int x, uint[] ch, int n)
        {
            int ret = wrap_mvwinchnstr(win, y, x, ch, n);
            InternalException.Verify(ret, "mvwinchnstr");
            return ret;
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_winchnstr(IntPtr win, uint[] ch, int n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwinchnstr(IntPtr win, int y, int x, uint[] ch, int n);
    }
}
