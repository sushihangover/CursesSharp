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
        internal static void scr_dump(string filename)
        {
            int ret = wrap_scr_dump(filename);
            InternalException.Verify(ret, "scr_dump");
        }

        internal static void scr_init(string filename)
        {
            int ret = wrap_scr_init(filename);
            InternalException.Verify(ret, "scr_init");
        }

        internal static void scr_restore(string filename)
        {
            int ret = wrap_scr_restore(filename);
            InternalException.Verify(ret, "scr_restore");
        }

        internal static void scr_set(string filename)
        {
            int ret = wrap_scr_set(filename);
            InternalException.Verify(ret, "scr_set");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_dump(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_init(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_restore(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_set(String filename);
    }
}
