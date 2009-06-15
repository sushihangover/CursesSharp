using System;

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
