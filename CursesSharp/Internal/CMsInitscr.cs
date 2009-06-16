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
        internal static IntPtr initscr()
        {
            IntPtr ret = wrap_initscr();
            InternalException.Verify(ret, "initscr");
            return ret;
        }

        internal static void endwin()
        {
            int ret = wrap_endwin();
            InternalException.Verify(ret, "endwin");
        }

        internal static bool isendwin()
        {
            return wrap_isendwin();
        }

        internal static void resize_term(int nlines, int ncols)
        {
            int ret = wrap_resize_term(nlines, ncols);
            InternalException.Verify(ret, "resize_term");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_initscr();
        [DllImport("CursesWrapper")]
        private static extern int wrap_endwin();
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_isendwin();
        [DllImport("CursesWrapper")]
        private static extern int wrap_resize_term(int nlines, int ncols);
    }
}
