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
        internal static IntPtr newpad(int nlines, int ncols)
        {
            IntPtr ret = wrap_newpad(nlines, ncols);
            InternalException.Verify(ret, "newpad");
            return ret;
        }

        internal static IntPtr subpad(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_subpad(orig, nlines, ncols, begy, begx);
            InternalException.Verify(ret, "subpad");
            return ret;
        }

        internal static void prefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            int ret = wrap_prefresh(win, py, px, sy1, sx1, sy2, sx2);
            InternalException.Verify(ret, "prefresh");
        }

        internal static void pnoutrefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            int ret = wrap_pnoutrefresh(win, py, px, sy1, sx1, sy2, sx2);
            InternalException.Verify(ret, "pnoutrefresh");
        }

        internal static void pechochar(IntPtr pad, uint ch)
        {
            int ret = wrap_pechochar(pad, ch);
            InternalException.Verify(ret, "pechochar");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_newpad(int nlines, int ncols);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_subpad(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern int wrap_prefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2);
        [DllImport("CursesWrapper")]
        private static extern int wrap_pnoutrefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2);
        [DllImport("CursesWrapper")]
        private static extern int wrap_pechochar(IntPtr pad, uint ch);
    }
}
