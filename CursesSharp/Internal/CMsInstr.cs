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
        internal static int winnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = wrap_winnwstr(win, str, n);
            InternalException.Verify(ret, "winnwstr");
            return ret;
        }

        internal static int mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = wrap_mvwinnwstr(win, y, x, str, n);
            InternalException.Verify(ret, "mvwinnwstr");
            return ret;
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_winnwstr(IntPtr win, StringBuilder wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_mvwinnwstr(IntPtr win, int y, int x, StringBuilder wstr, int n);
#else
        internal static int winnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = wrap_winnstr(win, str, n);
            InternalException.Verify(ret, "winnstr");
            return ret;
        }

        internal static int mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = wrap_mvwinnstr(win, y, x, str, n);
            InternalException.Verify(ret, "mvwinnstr");
            return ret;
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_winnstr(IntPtr win, StringBuilder str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n);
#endif
    }
}
