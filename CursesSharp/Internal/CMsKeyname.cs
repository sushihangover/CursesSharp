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
        internal static string keyname(int key)
        {
            IntPtr ret = wrap_keyname(key);
            InternalException.Verify(ret, "keyname");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static bool has_key(int key)
        {
            return wrap_has_key(key);
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_keyname(int key);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_has_key(int key);
    }
}
