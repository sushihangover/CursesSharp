using System;
using System.Runtime.InteropServices;

namespace Curses
{
    internal static class NativeMethods
    {
        /* addch.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_addch(uint ch);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_mvaddch(int y, int x, uint ch);
        /* addstr.c */
        [DllImport("CursesWrapper", CharSet=CharSet.Ansi)]
        internal static extern int wrap_addnstr(String str, int n);
        [DllImport("CursesWrapper", CharSet=CharSet.Ansi)]
        internal static extern int wrap_mvaddnstr(int y, int x, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_addnwstr(String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        internal static extern int wrap_mvaddnwstr(int y, int x, String str, int n);
        /* attr.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_attrset(uint attrs);
        /* clear.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_erase();
        /* color.c */
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_COLOR_PAIR(int n);
        [DllImport("CursesWrapper")]
        internal static extern short wrap_PAIR_NUMBER(uint n);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_start_color();
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_has_colors();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_init_pair(short color, short fg, short bg);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_use_default_colors();
        /* debug.c */
        [DllImport("CursesWrapper")]
        internal static extern void wrap_traceon();
        [DllImport("CursesWrapper")]
        internal static extern void wrap_traceoff();
        /* getch.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_getch();
        /* initscr.c */
        [DllImport("CursesWrapper")]
        internal static extern IntPtr wrap_initscr();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_endwin();
        /* inopts.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_echo();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_noecho();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_keypad(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_nl();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_nonl();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_nodelay(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_raw();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_noraw();
        [DllImport("CursesWrapper")]
        internal static extern void wrap_timeout(int delay);
        /* kernel.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_napms(int ms);
        [DllImport("CursesWrapper")]
        internal static extern int wrap_curs_set(int visibility);
        /* move.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_move(int y, int x);
        /* refresh.c */
        [DllImport("CursesWrapper")]
        internal static extern int wrap_refresh();
        /* wrapper.c */
        [DllImport("CursesWrapper")]
        internal static extern Boolean wrap_has_widechar();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_LINES();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_COLS();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_COLORS();
        [DllImport("CursesWrapper")]
        internal static extern int wrap_TABSIZE();

    }
}
