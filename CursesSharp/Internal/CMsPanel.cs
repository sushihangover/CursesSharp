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
#if HAVE_PANEL_H
    internal static partial class CursesMethods
    {
        internal static IntPtr new_panel(IntPtr win)
        {
            IntPtr ret = wrap_new_panel(win);
            CursesException.Verify(ret, "new_panel");
            return ret;
        }

        internal static void bottom_panel(IntPtr pan)
        {
            int ret = wrap_bottom_panel(pan);
            CursesException.Verify(ret, "bottom_panel");
        }

        internal static void top_panel(IntPtr pan)
        {
            int ret = wrap_top_panel(pan);
            CursesException.Verify(ret, "top_panel");
        }

        internal static void show_panel(IntPtr pan)
        {
            int ret = wrap_show_panel(pan);
            CursesException.Verify(ret, "show_panel");
        }

        internal static void update_panels()
        {
            wrap_update_panels();
        }

        internal static void hide_panel(IntPtr pan)
        {
            int ret = wrap_hide_panel(pan);
            CursesException.Verify(ret, "hide_panel");
        }

        internal static IntPtr panel_window(IntPtr pan)
        {
            IntPtr ret = wrap_panel_window(pan);
            CursesException.Verify(ret, "panel_window");
            return ret;
        }

        internal static void replace_panel(IntPtr pan, IntPtr win)
        {
            int ret = wrap_replace_panel(pan, win);
            CursesException.Verify(ret, "replace_panel");
        }

        internal static void move_panel(IntPtr pan, int starty, int startx)
        {
            int ret = wrap_move_panel(pan, starty, startx);
            CursesException.Verify(ret, "move_panel");
        }

        internal static bool panel_hidden(IntPtr pan)
        {
            int ret = wrap_panel_hidden(pan);
            CursesException.Verify(ret, "panel_hidden");
            return (ret != 0);
        }

        internal static IntPtr panel_above(IntPtr pan)
        {
            return wrap_panel_above(pan);
        }

        internal static IntPtr panel_below(IntPtr pan)
        {
            return wrap_panel_below(pan);
        }

        internal static void del_panel(IntPtr pan)
        {
            int ret = wrap_del_panel(pan);
            CursesException.Verify(ret, "del_panel");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_new_panel(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_bottom_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_top_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_show_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern void wrap_update_panels();
        [DllImport("CursesWrapper")]
        private static extern int wrap_hide_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_panel_window(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_replace_panel(IntPtr pan, IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_move_panel(IntPtr pan, int starty, int startx);
        [DllImport("CursesWrapper")]
        private static extern int wrap_panel_hidden(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_panel_above(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_panel_below(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_del_panel(IntPtr pan);
    }
#endif
}
