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
using System.Text;
using System.Runtime.InteropServices;

namespace CursesSharp.Internal
{
    internal static partial class CursesMethods
    {
        internal static int LINES()
        {
            return wrap_LINES();
        }

        internal static int COLS()
        {
            return wrap_COLS();
        }

        internal static int COLORS()
        {
            return wrap_COLORS();
        }

        internal static int COLOR_PAIRS()
        {
            return wrap_COLOR_PAIRS();
        }

        internal static int TABSIZE()
        {
            return wrap_TABSIZE();
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_LINES();
        [DllImport("CursesWrapper")]
        private static extern int wrap_COLS();
        [DllImport("CursesWrapper")]
        private static extern int wrap_COLORS();
        [DllImport("CursesWrapper")]
        private static extern int wrap_COLOR_PAIRS();
        [DllImport("CursesWrapper")]
        private static extern int wrap_TABSIZE();
    }
}
