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
        internal static void slk_init(int fmt)
        {
            int ret = wrap_slk_init(fmt);
            InternalException.Verify(ret, "slk_init");
        }

        internal static void slk_refresh()
        {
            int ret = wrap_slk_refresh();
            InternalException.Verify(ret, "slk_refresh");
        }

        internal static void slk_noutrefresh()
        {
            int ret = wrap_slk_noutrefresh();
            InternalException.Verify(ret, "slk_noutrefresh");
        }

        internal static string slk_label(int labnum)
        {
            IntPtr ret = wrap_slk_label(labnum);
            InternalException.Verify(ret, "slk_label");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static void slk_clear()
        {
            int ret = wrap_slk_clear();
            InternalException.Verify(ret, "slk_clear");
        }

        internal static void slk_restore()
        {
            int ret = wrap_slk_restore();
            InternalException.Verify(ret, "slk_restore");
        }

        internal static void slk_touch()
        {
            int ret = wrap_slk_touch();
            InternalException.Verify(ret, "slk_touch");
        }

        internal static void slk_attron(uint attrs)
        {
            int ret = wrap_slk_attron(attrs);
            InternalException.Verify(ret, "slk_attron");
        }

        internal static void slk_attrset(uint attrs)
        {
            int ret = wrap_slk_attrset(attrs);
            InternalException.Verify(ret, "slk_attrset");
        }

        internal static void slk_attroff(uint attrs)
        {
            int ret = wrap_slk_attroff(attrs);
            InternalException.Verify(ret, "slk_attroff");
        }

        internal static void slk_color(short color_pair)
        {
            int ret = wrap_slk_color(color_pair);
            InternalException.Verify(ret, "slk_color");
        }

#if HAVE_USE_WIDECHAR
        internal static void slk_set(int labnum, string label, int justify)
        {
            int ret = wrap_slk_wset(labnum, label, justify);
            InternalException.Verify(ret, "slk_wset");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_slk_wset(int labnum, String label, int justify);
#else
        internal static void slk_set(int labnum, string label, int justify)        
        {
            int ret = wrap_slk_set(labnum, label, justify);
            InternalException.Verify(ret, "slk_set");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_slk_set(int labnum, String label, int justify);
#endif
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_init(int fmt);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_refresh();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_noutrefresh();
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_slk_label(int labnum);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_clear();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_restore();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_touch();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_attron(uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_attrset(uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_attroff(uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_color(short color_pair);
    }
}
