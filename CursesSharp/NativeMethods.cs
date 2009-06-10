using System;
using System.Runtime.InteropServices;

namespace Curses
{
    internal static class NativeMethods
    {
        /* addch.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_addch(uint ch);
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_mvaddch(int y, int x, uint ch);
        /* addstr.c */
        [DllImport("CursesWrapper.dll", CharSet=CharSet.Ansi)]
        internal static extern int wrap_addnstr(String str, int n);
        [DllImport("CursesWrapper.dll", CharSet=CharSet.Ansi)]
        internal static extern int wrap_mvaddnstr(int y, int x, String str, int n);
        [DllImport("CursesWrapper.dll", CharSet = CharSet.Unicode)]
        internal static extern int wrap_addnwstr(String str, int n);
        [DllImport("CursesWrapper.dll", CharSet = CharSet.Unicode)]
        internal static extern int wrap_mvaddnwstr(int y, int x, String str, int n);
        /* attr.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_attrset(uint attrs);
        /* clear.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_erase();
        /* color.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern uint wrap_COLOR_PAIR(short n);
        [DllImport("CursesWrapper.dll")]
        internal static extern short wrap_PAIR_NUMBER(uint n);
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_start_color();
        [DllImport("CursesWrapper.dll")]
        internal static extern Boolean wrap_has_colors();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_init_pair(short color, short fg, short bg);
        /* debug.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern void wrap_traceon();
        [DllImport("CursesWrapper.dll")]
        internal static extern void wrap_traceoff();
        /* getch.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_getch();
        /* initscr.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern IntPtr wrap_initscr();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_endwin();
        /* inopts.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_echo();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_noecho();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_keypad(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_nodelay(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_raw();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_noraw();
        /* kernel.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_napms(int ms);
        /* move.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_move(int y, int x);
        /* refresh.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_refresh();
        /* wrapper.c */
        [DllImport("CursesWrapper.dll")]
        internal static extern Boolean wrap_has_widechar();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_LINES();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_COLS();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_COLORS();
        [DllImport("CursesWrapper.dll")]
        internal static extern int wrap_TABSIZE();

    }
}
