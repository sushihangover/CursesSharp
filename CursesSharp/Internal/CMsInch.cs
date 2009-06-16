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
        internal static uint winch(IntPtr win)
        {
            uint ret = wrap_winch(win);
            InternalException.Verify((int)ret, "winch");
            return ret;
        }

        internal static uint mvwinch(IntPtr win, int y, int x)
        {
            uint ret = wrap_mvwinch(win, y, x);
            InternalException.Verify((int)ret, "mvwinch");
            return ret;
        }

        [DllImport("CursesWrapper")]
        internal static extern uint wrap_winch(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_mvwinch(IntPtr win, int y, int x);
    }
}
