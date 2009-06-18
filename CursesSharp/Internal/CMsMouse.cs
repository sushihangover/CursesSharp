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
#if HAVE_CURSES_MOUSE
    [StructLayout(LayoutKind.Sequential)]
    internal struct WrapMEvent
    {
        internal int id;
        internal int x;
        internal int y;
        internal int z;
        internal uint bstate;
    };

    internal static partial class CursesMethods
    {
        internal static bool has_mouse()
        {
            return wrap_has_mouse();
        }

        internal static void getmouse(out WrapMEvent mevent)
        {
            int ret = wrap_getmouse(out mevent);
            InternalException.Verify(ret, "getmouse");
        }

        internal static void ungetmouse(ref WrapMEvent mevent)
        {
            int ret = wrap_ungetmouse(ref mevent);
            InternalException.Verify(ret, "ungetmouse");
        }

        internal static uint mousemask(uint mask, out uint oldmask)
        {
            return wrap_mousemask(mask, out oldmask);
        }

        internal static bool wenclose(IntPtr win, int y, int x)
        {
            return wrap_wenclose(win, y, x);
        }

        internal static bool wmouse_trafo(IntPtr win, ref int y, ref int x, bool to_screen)
        {
            return wrap_wmouse_trafo(win, ref y, ref x, to_screen);
        }

        internal static int mouseinterval(int wait)
        {
            return wrap_mouseinterval(wait);
        }

        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_has_mouse();
        [DllImport("CursesWrapper")]
        private static extern int wrap_getmouse(out WrapMEvent wrap_mevent);
        [DllImport("CursesWrapper")]
        private static extern int wrap_ungetmouse(ref WrapMEvent wrap_mevent);
        [DllImport("CursesWrapper")]
        private static extern uint wrap_mousemask(uint mask, out uint oldmask);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_wenclose(IntPtr win, int y, int x);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_wmouse_trafo(IntPtr win, ref int y, ref int x, Boolean to_screen);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mouseinterval(int wait);
    }
#endif
}
