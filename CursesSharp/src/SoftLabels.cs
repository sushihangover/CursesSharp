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
using CursesSharp.Internal;

namespace CursesSharp
{
    public enum SoftLabelJustify
    {
        Left = 0,
        Center = 1,
        Right = 2
    }

    public class SoftLabels
    {
        public static void Init(int fmt)
        {
            CursesMethods.slk_init(fmt);
        }

        public static void Refresh()
        {
            CursesMethods.slk_refresh();
        }

        public static void NoOutRefresh()
        {
            CursesMethods.slk_noutrefresh();
        }

        public static string GetLabel(int labnum)
        {
            return CursesMethods.slk_label(labnum);
        }

        public static void SetLabel(int labnum, string label, SoftLabelJustify justify)
        {
            CursesMethods.slk_set(labnum, label, (int)justify);
        }

        public static void Clear()
        {
            CursesMethods.slk_clear();
        }

        public static void Restore()
        {
            CursesMethods.slk_restore();
        }

        public static void Touch()
        {
            CursesMethods.slk_touch();
        }

        public static uint Attr
        {
            set { CursesMethods.slk_attrset(value); }
        }

        public static void AttrOn(uint attrs)
        {
            CursesMethods.slk_attron(attrs);
        }

        public static void AttrOff(uint attrs)
        {
            CursesMethods.slk_attroff(attrs);
        }

        public static short Color
        {
            set { CursesMethods.slk_color(value); }
        }
    }
}
