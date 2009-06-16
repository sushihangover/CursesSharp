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
        internal static IntPtr newwin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_newwin(nlines, ncols, begy, begx);
            InternalException.Verify(ret, "newwin");
            return ret;
        }

        internal static IntPtr derwin(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_derwin(orig, nlines, ncols, begy, begx);
            InternalException.Verify(ret, "derwin");
            return ret;
        }

        internal static IntPtr subwin(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_subwin(orig, nlines, ncols, begy, begx);
            InternalException.Verify(ret, "subwin");
            return ret;
        }

        internal static IntPtr dupwin(IntPtr win)
        {
            IntPtr ret = wrap_dupwin(win);
            InternalException.Verify(ret, "dupwin");
            return ret;
        }

        internal static void delwin(IntPtr win)
        {
            int ret = wrap_delwin(win);
            InternalException.Verify(ret, "delwin");
        }

        internal static void mvwin(IntPtr win, int y, int x)
        {
            int ret = wrap_mvwin(win, y, x);
            InternalException.Verify(ret, "mvwin");
        }

        internal static void mvderwin(IntPtr win, int pary, int parx)
        {
            int ret = wrap_mvderwin(win, pary, parx);
            InternalException.Verify(ret, "mvderwin");
        }

        internal static void syncok(IntPtr win, bool bf)
        {
            int ret = wrap_syncok(win, bf);
            InternalException.Verify(ret, "syncok");
        }

        internal static void wsyncup(IntPtr win)
        {
            wrap_wsyncup(win);
        }

        internal static void wcursyncup(IntPtr win)
        {
            wrap_wcursyncup(win);
        }

        internal static void wsyncdown(IntPtr win)
        {
            wrap_wsyncdown(win);
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_newwin(int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_derwin(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_subwin(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_dupwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_delwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwin(IntPtr win, int y, int x);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvderwin(IntPtr win, int pary, int parx);
        [DllImport("CursesWrapper")]
        private static extern int wrap_syncok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wsyncup(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wcursyncup(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wsyncdown(IntPtr win);
    }
}
