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
        internal static void overlay(IntPtr src_w, IntPtr dst_w)
        {
            int ret = wrap_overlay(src_w, dst_w);
            InternalException.Verify(ret, "overlay");
        }

        internal static void overwrite(IntPtr src_w, IntPtr dst_w)
        {
            int ret = wrap_overwrite(src_w, dst_w);
            InternalException.Verify(ret, "overwrite");
        }

        internal static void copywin(IntPtr src_w, IntPtr dst_w, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, bool overlay)
        {
            int ret = wrap_copywin(src_w, dst_w, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
            InternalException.Verify(ret, "copywin");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_overlay(IntPtr src_w, IntPtr dst_w);
        [DllImport("CursesWrapper")]
        private static extern int wrap_overwrite(IntPtr src_w, IntPtr dst_w);
        [DllImport("CursesWrapper")]
        private static extern int wrap_copywin(IntPtr src_w, IntPtr dst_w, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, Boolean overlay);
    }
}
