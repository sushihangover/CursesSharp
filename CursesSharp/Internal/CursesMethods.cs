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
    internal delegate int RipOffLineFunInt(IntPtr win, int cols);

#if NCURSES_MOUSE_VERSION
    [StructLayout(LayoutKind.Sequential)]
    internal struct WrapMEvent
    {
        internal int id;
        internal int x;
        internal int y;
        internal int z;
        internal uint bstate;
    };
#endif

    internal static class CursesMethods
    {
        #region addch.c
        internal static void waddch(IntPtr win, uint ch)
        {
            int ret = wrap_waddch(win, ch);
            CursesException.Verify(ret, "waddch");
        }

        internal static void mvwaddch(IntPtr win, int y, int x, uint ch)
        {
            int ret = wrap_mvwaddch(win, y, x, ch);
            CursesException.Verify(ret, "mvwaddch");
        }

        internal static void wechochar(IntPtr win, uint ch)
        {
            int ret = wrap_wechochar(win, ch);
            CursesException.Verify(ret, "wechochar");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wechochar(IntPtr win, uint ch);
        [DllImport("CursesWrapper")]
        private static extern int wrap_waddch(IntPtr win, uint ch);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwaddch(IntPtr win, int y, int x, uint ch);
        #endregion

        #region addchstr.c
        internal static void waddchnstr(IntPtr win, uint[] chstr, int n)
        {
            int ret = wrap_waddchnstr(win, chstr, n);
            CursesException.Verify(ret, "waddchnstr");
        }

        internal static void mvwaddchnstr(IntPtr win, int y, int x, uint[] chstr, int n)
        {
            int ret = wrap_mvwaddchnstr(win, y, x, chstr, n);
            CursesException.Verify(ret, "mvwaddchnstr");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_waddchnstr(IntPtr win, uint[] chstr, int n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwaddchnstr(IntPtr win, int y, int x, uint[] chstr, int n);
        #endregion

        #region addstr.c
#if HAVE_USE_WIDECHAR
        internal static void waddnstr(IntPtr win, string str, int n)
        {
            int ret = wrap_waddnwstr(win, str, n);
            CursesException.Verify(ret, "waddnwstr");
        }

        internal static void mvwaddnstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = wrap_mvwaddnwstr(win, y, x, str, n);
            CursesException.Verify(ret, "mvwaddnwstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_waddnwstr(IntPtr win, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_mvwaddnwstr(IntPtr win, int y, int x, String str, int n);
#else
        internal static void waddnstr(IntPtr win, string str, int n)
        {
            int ret = wrap_waddnstr(win, str, n);
            CursesException.Verify(ret, "waddnstr");
        }

        internal static void mvwaddnstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = wrap_mvwaddnstr(win, y, x, str, n);
            CursesException.Verify(ret, "mvwaddnstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_waddnstr(IntPtr win, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwaddnstr(IntPtr win, int y, int x, String str, int n);
#endif
        #endregion

        #region attr.c
        internal static void wattroff(IntPtr win, uint attrs)
        {
            int ret = wrap_wattroff(win, attrs);
            CursesException.Verify(ret, "wattroff");
        }

        internal static void wattron(IntPtr win, uint attrs)
        {
            int ret = wrap_wattron(win, attrs);
            CursesException.Verify(ret, "wattron");
        }

        internal static void wattrset(IntPtr win, uint attrs)
        {
            int ret = wrap_wattrset(win, attrs);
            CursesException.Verify(ret, "wattrset");
        }

        internal static void wstandend(IntPtr win)
        {
            int ret = wrap_wstandend(win);
            CursesException.Verify(ret, "wstandend");
        }

        internal static void wstandout(IntPtr win)
        {
            int ret = wrap_wstandout(win);
            CursesException.Verify(ret, "wstandout");
        }

        internal static void wcolor_set(IntPtr win, short color_pair)
        {
            int ret = wrap_wcolor_set(win, color_pair);
            CursesException.Verify(ret, "wcolor_set");
        }

        internal static void wattr_get(IntPtr win, out uint attrs, out short color_pair)
        {
            int ret = wrap_wattr_get(win, out attrs, out color_pair);
            CursesException.Verify(ret, "wattr_get");
        }

        internal static void wchgat(IntPtr win, int n, uint attr, short color)
        {
            int ret = wrap_wchgat(win, n, attr, color);
            CursesException.Verify(ret, "wchgat");
        }

        internal static void mvwchgat(IntPtr win, int y, int x, int n, uint attr, short color)
        {
            int ret = wrap_mvwchgat(win, y, x, n, attr, color);
            CursesException.Verify(ret, "mvwchgat");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wattroff(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wattron(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wattrset(IntPtr win, uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wstandend(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wstandout(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wcolor_set(IntPtr win, short color_pair);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wattr_get(IntPtr win, out uint attrs, out short color_pair);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wchgat(IntPtr win, int n, uint attr, short color);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwchgat(IntPtr win, int y, int x, int n, uint attr, short color);
        #endregion

        #region beep.c
        internal static void beep()
        {
            int ret = wrap_beep();
            CursesException.Verify(ret, "beep");
        }

        internal static void flash()
        {
            int ret = wrap_flash();
            CursesException.Verify(ret, "flash");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_beep();
        [DllImport("CursesWrapper")]
        private static extern int wrap_flash();
        #endregion

        #region bkgd.c
        internal static uint getbkgd(IntPtr win)
        {
            return wrap_getbkgd(win);
        }

        internal static void wbkgd(IntPtr win, uint ch)
        {
            int ret = wrap_wbkgd(win, ch);
            CursesException.Verify(ret, "wbkgd");
        }

        internal static void wbkgdset(IntPtr win, uint ch)
        {
            wrap_wbkgdset(win, ch);
        }

        [DllImport("CursesWrapper")]
        private static extern uint wrap_getbkgd(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wbkgd(IntPtr win, uint ch);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wbkgdset(IntPtr win, uint ch);
        #endregion

        #region border.c
        internal static void wborder(IntPtr win, uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            int ret = wrap_wborder(win, ls, rs, ts, bs, tl, tr, bl, br);
            CursesException.Verify(ret, "wborder");
        }

        internal static void box(IntPtr win, uint verch, uint horch)
        {
            int ret = wrap_box(win, verch, horch);
            CursesException.Verify(ret, "box");
        }

        internal static void whline(IntPtr win, uint ch, int n)
        {
            int ret = wrap_whline(win, ch, n);
            CursesException.Verify(ret, "whline");
        }

        internal static void wvline(IntPtr win, uint ch, int n)
        {
            int ret = wrap_wvline(win, ch, n);
            CursesException.Verify(ret, "wvline");
        }

        internal static void mvwhline(IntPtr win, int y, int x, uint ch, int n)
        {
            int ret = wrap_mvwhline(win, y, x, ch, n);
            CursesException.Verify(ret, "mvwhline");
        }

        internal static void mvwvline(IntPtr win, int y, int x, uint ch, int n)
        {
            int ret = wrap_mvwvline(win, y, x, ch, n);
            CursesException.Verify(ret, "mvwvline");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wborder(IntPtr win, uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br);
        [DllImport("CursesWrapper")]
        private static extern int wrap_box(IntPtr win, uint verch, uint horch);
        [DllImport("CursesWrapper")]
        private static extern int wrap_whline(IntPtr win, uint ch, int n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wvline(IntPtr win, uint ch, int n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwhline(IntPtr win, int y, int x, uint ch, int n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwvline(IntPtr win, int y, int x, uint ch, int n);
        #endregion

        #region clear.c
        internal static void wclear(IntPtr win)
        {
            int ret = wrap_wclear(win);
            CursesException.Verify(ret, "wclear");
        }

        internal static void werase(IntPtr win)
        {
            int ret = wrap_werase(win);
            CursesException.Verify(ret, "werase");
        }

        internal static void wclrtobot(IntPtr win)
        {
            int ret = wrap_wclrtobot(win);
            CursesException.Verify(ret, "wclrtobot");
        }

        internal static void wclrtoeol(IntPtr win)
        {
            int ret = wrap_wclrtoeol(win);
            CursesException.Verify(ret, "wclrtoeol");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wclear(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_werase(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wclrtobot(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wclrtoeol(IntPtr win);
        #endregion

        #region color.c
        internal static uint COLOR_PAIR(int n)
        {
            return wrap_COLOR_PAIR(n);
        }

        internal static short PAIR_NUMBER(uint n)
        {
            return wrap_PAIR_NUMBER(n);
        }

        internal static void start_color()
        {
            int ret = wrap_start_color();
            CursesException.Verify(ret, "start_color");
        }

        internal static void init_pair(short color, short fg, short bg)
        {
            int ret = wrap_init_pair(color, fg, bg);
            CursesException.Verify(ret, "init_pair");
        }

        internal static void init_color(short color, short red, short green, short blue)
        {
            int ret = wrap_init_color(color, red, green, blue);
            CursesException.Verify(ret, "init_color");
        }

        internal static void color_content(short color, out short red, out short green, out short blue)
        {
            int ret = wrap_color_content(color, out red, out green, out blue);
            CursesException.Verify(ret, "color_content");
        }

        internal static void pair_content(short pair, out short fg, out short bg)
        {
            int ret = wrap_pair_content(pair, out fg, out bg);
            CursesException.Verify(ret, "pair_content");
        }

        internal static bool has_colors()
        {
            return wrap_has_colors();
        }

        internal static bool can_change_color()
        {
            return wrap_can_change_color();
        }

        internal static void assume_default_colors(int f, int b)
        {
            int ret = wrap_assume_default_colors(f, b);
            CursesException.Verify(ret, "assume_default_colors");
        }

        internal static void use_default_colors()
        {
            int ret = wrap_use_default_colors();
            CursesException.Verify(ret, "use_default_colors");
        }

        [DllImport("CursesWrapper")]
        private static extern uint wrap_COLOR_PAIR(int n);
        [DllImport("CursesWrapper")]
        private static extern short wrap_PAIR_NUMBER(uint n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_start_color();
        [DllImport("CursesWrapper")]
        private static extern int wrap_init_pair(short color, short fg, short bg);
        [DllImport("CursesWrapper")]
        private static extern int wrap_init_color(short color, short red, short green, short blue);
        [DllImport("CursesWrapper")]
        private static extern int wrap_color_content(short color, out short red, out short green, out short blue);
        [DllImport("CursesWrapper")]
        private static extern int wrap_pair_content(short pair, out short fg, out short bg);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_has_colors();
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_can_change_color();
        [DllImport("CursesWrapper")]
        private static extern int wrap_assume_default_colors(int f, int b);
        [DllImport("CursesWrapper")]
        private static extern int wrap_use_default_colors();
        #endregion

        #region debug.c
        internal static void traceon()
        {
            wrap_traceon();
        }

        internal static void traceoff()
        {
            wrap_traceoff();
        }

        [DllImport("CursesWrapper")]
        private static extern void wrap_traceon();
        [DllImport("CursesWrapper")]
        private static extern void wrap_traceoff();
        #endregion

        #region delch.c
        internal static void wdelch(IntPtr win)
        {
            int ret = wrap_wdelch(win);
            CursesException.Verify(ret, "wdelch");
        }

        internal static void mvwdelch(IntPtr win, int y, int x)
        {
            int ret = wrap_mvwdelch(win, y, x);
            CursesException.Verify(ret, "mvwdelch");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wdelch(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwdelch(IntPtr win, int y, int x);
        #endregion

        #region deleteln.c
        internal static void wdeleteln(IntPtr win)
        {
            int ret = wrap_wdeleteln(win);
            CursesException.Verify(ret, "wdeleteln");
        }

        internal static void winsdelln(IntPtr win, int n)
        {
            int ret = wrap_winsdelln(win, n);
            CursesException.Verify(ret, "winsdelln");
        }

        internal static void winsertln(IntPtr win)
        {
            int ret = wrap_winsertln(win);
            CursesException.Verify(ret, "winsertln");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wdeleteln(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_winsdelln(IntPtr win, int n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_winsertln(IntPtr win);
        #endregion

        #region getch.c
        internal static int wgetch(IntPtr win)
        {
            return wrap_wgetch(win);
        }

        internal static int mvwgetch(IntPtr win, int y, int x)
        {
            return wrap_mvwgetch(win, y, x);
        }

        internal static void ungetch(int ch)
        {
            int ret = wrap_ungetch(ch);
            CursesException.Verify(ret, "ungetch");
        }

        internal static void flushinp()
        {
            int ret = wrap_flushinp();
            CursesException.Verify(ret, "flushinp");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_wgetch(IntPtr win);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwgetch(IntPtr win, int y, int x);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_ungetch(int ch);
        [DllImport("CursesWrapper")]
        private static extern int wrap_flushinp();
        #endregion

        #region getstr.c
#if HAVE_USE_WIDECHAR
        internal static void wgetnstr(IntPtr win, StringBuilder wstr, int n)
        {
            int ret = wrap_wgetn_wstr(win, wstr, n);
            CursesException.Verify(ret, "wgetn_wstr");
        }

        internal static void mvwgetnstr(IntPtr win, int y, int x, StringBuilder wstr, int n)
        {
            int ret = wrap_mvwgetn_wstr(win, y, x, wstr, n);
            CursesException.Verify(ret, "mvwgetn_wstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_wgetn_wstr(IntPtr win, StringBuilder wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_mvwgetn_wstr(IntPtr win, int y, int x, StringBuilder wstr, int n);
#else
        internal static void wgetnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = wrap_wgetnstr(win, str, n);
            CursesException.Verify(ret, "wgetnstr");
        }

        internal static void mvwgetnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = wrap_mvwgetnstr(win, y, x, str, n);
            CursesException.Verify(ret, "mvwgetnstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_wgetnstr(IntPtr win, StringBuilder str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwgetnstr(IntPtr win, int y, int x, StringBuilder str, int n);
#endif
        #endregion

        #region getyx.c
        internal static void getyx(IntPtr win, out int y, out int x)
        {
            wrap_getyx(win, out y, out x);
        }

        internal static void getparyx(IntPtr win, out int y, out int x)
        {
            wrap_getparyx(win, out y, out x);
        }

        internal static void getbegyx(IntPtr win, out int y, out int x)
        {
            wrap_getbegyx(win, out y, out x);
        }

        internal static void getmaxyx(IntPtr win, out int y, out int x)
        {
            wrap_getmaxyx(win, out y, out x);
        }

        [DllImport("CursesWrapper")]
        private static extern void wrap_getyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_getparyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_getbegyx(IntPtr win, out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_getmaxyx(IntPtr win, out int y, out int x);
        #endregion

        #region inch.c
        internal static uint winch(IntPtr win)
        {
            uint ret = wrap_winch(win);
            CursesException.Verify((int)ret, "winch");
            return ret;
        }

        internal static uint mvwinch(IntPtr win, int y, int x)
        {
            uint ret = wrap_mvwinch(win, y, x);
            CursesException.Verify((int)ret, "mvwinch");
            return ret;
        }

        [DllImport("CursesWrapper")]
        internal static extern uint wrap_winch(IntPtr win);
        [DllImport("CursesWrapper")]
        internal static extern uint wrap_mvwinch(IntPtr win, int y, int x);
        #endregion

        #region inchstr.c
        internal static int winchnstr(IntPtr win, uint[] ch, int n)
        {
            int ret = wrap_winchnstr(win, ch, n);
            CursesException.Verify(ret, "winchnstr");
            return ret;
        }

        internal static int mvwinchnstr(IntPtr win, int y, int x, uint[] ch, int n)
        {
            int ret = wrap_mvwinchnstr(win, y, x, ch, n);
            CursesException.Verify(ret, "mvwinchnstr");
            return ret;
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_winchnstr(IntPtr win, uint[] ch, int n);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwinchnstr(IntPtr win, int y, int x, uint[] ch, int n);
        #endregion

        #region initscr.c
        internal static IntPtr initscr()
        {
            IntPtr ret = wrap_initscr();
            CursesException.Verify(ret, "initscr");
            return ret;
        }

        internal static void endwin()
        {
            int ret = wrap_endwin();
            CursesException.Verify(ret, "endwin");
        }

        internal static bool isendwin()
        {
            return wrap_isendwin();
        }

        internal static void resize_term(int nlines, int ncols)
        {
            int ret = wrap_resize_term(nlines, ncols);
            CursesException.Verify(ret, "resize_term");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_initscr();
        [DllImport("CursesWrapper")]
        private static extern int wrap_endwin();
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_isendwin();
        [DllImport("CursesWrapper")]
        private static extern int wrap_resize_term(int nlines, int ncols);
        #endregion

        #region inopts.c
        internal static void cbreak()
        {
            int ret = wrap_cbreak();
            CursesException.Verify(ret, "cbreak");
        }

        internal static void nocbreak()
        {
            int ret = wrap_nocbreak();
            CursesException.Verify(ret, "nocbreak");
        }

        internal static void echo()
        {
            int ret = wrap_echo();
            CursesException.Verify(ret, "echo");
        }

        internal static void noecho()
        {
            int ret = wrap_noecho();
            CursesException.Verify(ret, "noecho");
        }

        internal static void halfdelay(int tenths)
        {
            int ret = wrap_halfdelay(tenths);
            CursesException.Verify(ret, "halfdelay");
        }

        internal static void intrflush(IntPtr win, bool bf)
        {
            int ret = wrap_intrflush(win, bf);
            CursesException.Verify(ret, "intrflush");
        }

        internal static void keypad(IntPtr win, bool bf)
        {
            int ret = wrap_keypad(win, bf);
            CursesException.Verify(ret, "keypad");
        }

        internal static void meta(IntPtr win, bool bf)
        {
            int ret = wrap_meta(win, bf);
            CursesException.Verify(ret, "meta");
        }

        internal static void nl()
        {
            int ret = wrap_nl();
            CursesException.Verify(ret, "nl");
        }

        internal static void nonl()
        {
            int ret = wrap_nonl();
            CursesException.Verify(ret, "nonl");
        }

        internal static void nodelay(IntPtr win, bool bf)
        {
            int ret = wrap_nodelay(win, bf);
            CursesException.Verify(ret, "nodelay");
        }

        internal static void raw()
        {
            int ret = wrap_raw();
            CursesException.Verify(ret, "raw");
        }

        internal static void noraw()
        {
            int ret = wrap_noraw();
            CursesException.Verify(ret, "noraw");
        }

        internal static void qiflush()
        {
            wrap_qiflush();
        }

        internal static void noqiflush()
        {
            wrap_noqiflush();
        }

        internal static void notimeout(IntPtr win, bool bf)
        {
            int ret = wrap_notimeout(win, bf);
            CursesException.Verify(ret, "notimeout");
        }

        internal static void wtimeout(IntPtr win, int delay)
        {
            wrap_wtimeout(win, delay);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_cbreak();
        [DllImport("CursesWrapper")]
        private static extern int wrap_nocbreak();
        [DllImport("CursesWrapper")]
        private static extern int wrap_echo();
        [DllImport("CursesWrapper")]
        private static extern int wrap_noecho();
        [DllImport("CursesWrapper")]
        private static extern int wrap_halfdelay(int tenths);
        [DllImport("CursesWrapper")]
        private static extern int wrap_intrflush(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_keypad(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_meta(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_nl();
        [DllImport("CursesWrapper")]
        private static extern int wrap_nonl();
        [DllImport("CursesWrapper")]
        private static extern int wrap_nodelay(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_raw();
        [DllImport("CursesWrapper")]
        private static extern int wrap_noraw();
        [DllImport("CursesWrapper")]
        private static extern void wrap_qiflush();
        [DllImport("CursesWrapper")]
        private static extern void wrap_noqiflush();
        [DllImport("CursesWrapper")]
        private static extern int wrap_notimeout(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wtimeout(IntPtr win, int delay);
        #endregion

        #region insch.c
        internal static void winsch(IntPtr win, uint ch)
        {
            int ret = wrap_winsch(win, ch);
            CursesException.Verify(ret, "winsch");
        }

        internal static void mvwinsch(IntPtr win, int y, int x, uint ch)
        {
            int ret = wrap_mvwinsch(win, y, x, ch);
            CursesException.Verify(ret, "mvwinsch");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_winsch(IntPtr win, uint ch);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwinsch(IntPtr win, int y, int x, uint ch);
        #endregion

        #region insstr.c
#if HAVE_USE_WIDECHAR
        internal static void winsnstr(IntPtr win, string str, int n)
        {
            int ret = wrap_wins_nwstr(win, str, n);
            CursesException.Verify(ret, "wins_nwstr");
        }

        internal static void mvwinsnstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = wrap_mvwins_nwstr(win, y, x, str, n);
            CursesException.Verify(ret, "mvwins_nwstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_wins_nwstr(IntPtr win, String wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_mvwins_nwstr(IntPtr win, int y, int x, String wstr, int n);
#else
        internal static void winsnstr(IntPtr win, string str, int n)
        {
            int ret = wrap_winsnstr(win, str, n);
            CursesException.Verify(ret, "winsnstr");
        }

        internal static void mvwinsnstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = wrap_mvwinsnstr(win, y, x, str, n);
            CursesException.Verify(ret, "mvwinsnstr");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_winsnstr(IntPtr win, String str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwinsnstr(IntPtr win, int y, int x, String str, int n);
#endif
        #endregion

        #region instr.c
#if HAVE_USE_WIDECHAR
        internal static int winnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = wrap_winnwstr(win, str, n);
            CursesException.Verify(ret, "winnwstr");
            return ret;
        }

        internal static int mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = wrap_mvwinnwstr(win, y, x, str, n);
            CursesException.Verify(ret, "mvwinnwstr");
            return ret;
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_winnwstr(IntPtr win, StringBuilder wstr, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_mvwinnwstr(IntPtr win, int y, int x, StringBuilder wstr, int n);
#else
        internal static int winnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = wrap_winnstr(win, str, n);
            CursesException.Verify(ret, "winnstr");
            return ret;
        }

        internal static int mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = wrap_mvwinnstr(win, y, x, str, n);
            CursesException.Verify(ret, "mvwinnstr");
            return ret;
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_winnstr(IntPtr win, StringBuilder str, int n);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n);
#endif
        #endregion

        #region kernel.c
        internal static void def_prog_mode()
        {
            int ret = wrap_def_prog_mode();
            CursesException.Verify(ret, "def_prog_mode");
        }

        internal static void def_shell_mode()
        {
            int ret = wrap_def_shell_mode();
            CursesException.Verify(ret, "def_shell_mode");
        }

        internal static void reset_prog_mode()
        {
            int ret = wrap_reset_prog_mode();
            CursesException.Verify(ret, "reset_prog_mode");
        }

        internal static void reset_shell_mode()
        {
            int ret = wrap_reset_shell_mode();
            CursesException.Verify(ret, "reset_shell_mode");
        }

        internal static void resetty()
        {
            int ret = wrap_resetty();
            CursesException.Verify(ret, "resetty");
        }

        internal static void savetty()
        {
            int ret = wrap_savetty();
            CursesException.Verify(ret, "savetty");
        }

        internal static void getsyx(out int y, out int x)
        {
            wrap_getsyx(out y, out x);
        }

        internal static void setsyx(int y, int x)
        {
            wrap_setsyx(y, x);
        }

        internal static void ripoffline(int line, RipOffLineFunInt init)
        {
            int ret = wrap_ripoffline(line, init);
            CursesException.Verify(ret, "ripoffline");
        }

        internal static void napms(int ms)
        {
            int ret = wrap_napms(ms);
            CursesException.Verify(ret, "napms");
        }

        internal static int curs_set(int visibility)
        {
            return wrap_curs_set(visibility);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_def_prog_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_def_shell_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_reset_prog_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_reset_shell_mode();
        [DllImport("CursesWrapper")]
        private static extern int wrap_resetty();
        [DllImport("CursesWrapper")]
        private static extern int wrap_savetty();
        [DllImport("CursesWrapper")]
        private static extern void wrap_getsyx(out int y, out int x);
        [DllImport("CursesWrapper")]
        private static extern void wrap_setsyx(int y, int x);
        [DllImport("CursesWrapper")]
        private static extern int wrap_ripoffline(int line, RipOffLineFunInt init);
        [DllImport("CursesWrapper")]
        private static extern int wrap_napms(int ms);
        [DllImport("CursesWrapper")]
        private static extern int wrap_curs_set(int visibility);
        #endregion

        #region keyname.c
        internal static string keyname(int key)
        {
            IntPtr ret = wrap_keyname(key);
            CursesException.Verify(ret, "keyname");
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
        #endregion

        #region move.c
        internal static void wmove(IntPtr win, int y, int x)
        {
            int ret = wrap_wmove(win, y, x);
            CursesException.Verify(ret, "wmove");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wmove(IntPtr win, int y, int x);
        #endregion

        #region mouse.c
#if NCURSES_MOUSE_VERSION
        internal static bool has_mouse()
        {
            return wrap_has_mouse();
        }

        internal static void getmouse(out WrapMEvent mevent)
        {
            int ret = wrap_getmouse(out mevent);
            CursesException.Verify(ret, "getmouse");
        }

        internal static void ungetmouse(ref WrapMEvent mevent)
        {
            int ret = wrap_ungetmouse(ref mevent);
            CursesException.Verify(ret, "ungetmouse");
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
#endif
        #endregion

        #region outopts.c
        internal static void clearok(IntPtr win, bool bf)
        {
            int ret = wrap_clearok(win, bf);
            CursesException.Verify(ret, "clearok");
        }

        internal static void idlok(IntPtr win, bool bf)
        {
            int ret = wrap_idlok(win, bf);
            CursesException.Verify(ret, "idlok");
        }

        internal static void idcok(IntPtr win, bool bf)
        {
            wrap_idcok(win, bf);
        }

        internal static void immedok(IntPtr win, bool bf)
        {
            wrap_immedok(win, bf);
        }

        internal static void leaveok(IntPtr win, bool bf)
        {
            int ret = wrap_leaveok(win, bf);
            CursesException.Verify(ret, "leaveok");
        }

        internal static void wsetscrreg(IntPtr win, int top, int bot)
        {
            int ret = wrap_wsetscrreg(win, top, bot);
            CursesException.Verify(ret, "wsetscrreg");
        }

        internal static void scrollok(IntPtr win, bool bf)
        {
            int ret = wrap_scrollok(win, bf);
            CursesException.Verify(ret, "scrollok");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_clearok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_idlok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern void wrap_idcok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern void wrap_immedok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_leaveok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wsetscrreg(IntPtr win, int top, int bot);
        [DllImport("CursesWrapper")]
        private static extern int wrap_scrollok(IntPtr win, Boolean bf);
        #endregion

        #region overlay.c
        internal static void overlay(IntPtr src_w, IntPtr dst_w)
        {
            int ret = wrap_overlay(src_w, dst_w);
            CursesException.Verify(ret, "overlay");
        }

        internal static void overwrite(IntPtr src_w, IntPtr dst_w)
        {
            int ret = wrap_overwrite(src_w, dst_w);
            CursesException.Verify(ret, "overwrite");
        }

        internal static void copywin(IntPtr src_w, IntPtr dst_w, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, bool overlay)
        {
            int ret = wrap_copywin(src_w, dst_w, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
            CursesException.Verify(ret, "copywin");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_overlay(IntPtr src_w, IntPtr dst_w);
        [DllImport("CursesWrapper")]
        private static extern int wrap_overwrite(IntPtr src_w, IntPtr dst_w);
        [DllImport("CursesWrapper")]
        private static extern int wrap_copywin(IntPtr src_w, IntPtr dst_w, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, Boolean overlay);
        #endregion

        #region pad.c
        internal static IntPtr newpad(int nlines, int ncols)
        {
            IntPtr ret = wrap_newpad(nlines, ncols);
            CursesException.Verify(ret, "newpad");
            return ret;
        }

        internal static IntPtr subpad(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_subpad(orig, nlines, ncols, begy, begx);
            CursesException.Verify(ret, "subpad");
            return ret;
        }

        internal static void prefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            int ret = wrap_prefresh(win, py, px, sy1, sx1, sy2, sx2);
            CursesException.Verify(ret, "prefresh");
        }

        internal static void pnoutrefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            int ret = wrap_pnoutrefresh(win, py, px, sy1, sx1, sy2, sx2);
            CursesException.Verify(ret, "pnoutrefresh");
        }

        internal static void pechochar(IntPtr pad, uint ch)
        {
            int ret = wrap_pechochar(pad, ch);
            CursesException.Verify(ret, "pechochar");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_newpad(int nlines, int ncols);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_subpad(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern int wrap_prefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2);
        [DllImport("CursesWrapper")]
        private static extern int wrap_pnoutrefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2);
        [DllImport("CursesWrapper")]
        private static extern int wrap_pechochar(IntPtr pad, uint ch);
        #endregion

        #region panel.c
#if HAVE_PANEL_H
        internal static IntPtr new_panel(IntPtr win)
        {
            IntPtr ret = wrap_new_panel(win);
            CursesException.Verify(ret, "new_panel");
            return ret;
        }

        internal static void bottom_panel(IntPtr pan)
        {
            int ret = wrap_bottom_panel(pan);
            CursesException.Verify(ret, "bottom_panel");
        }

        internal static void top_panel(IntPtr pan)
        {
            int ret = wrap_top_panel(pan);
            CursesException.Verify(ret, "top_panel");
        }

        internal static void show_panel(IntPtr pan)
        {
            int ret = wrap_show_panel(pan);
            CursesException.Verify(ret, "show_panel");
        }

        internal static void update_panels()
        {
            wrap_update_panels();
        }

        internal static void hide_panel(IntPtr pan)
        {
            int ret = wrap_hide_panel(pan);
            CursesException.Verify(ret, "hide_panel");
        }

        internal static IntPtr panel_window(IntPtr pan)
        {
            IntPtr ret = wrap_panel_window(pan);
            CursesException.Verify(ret, "panel_window");
            return ret;
        }

        internal static void replace_panel(IntPtr pan, IntPtr win)
        {
            int ret = wrap_replace_panel(pan, win);
            CursesException.Verify(ret, "replace_panel");
        }

        internal static void move_panel(IntPtr pan, int starty, int startx)
        {
            int ret = wrap_move_panel(pan, starty, startx);
            CursesException.Verify(ret, "move_panel");
        }

        internal static bool panel_hidden(IntPtr pan)
        {
            int ret = wrap_panel_hidden(pan);
            CursesException.Verify(ret, "panel_hidden");
            return (ret != 0);
        }

        internal static IntPtr panel_above(IntPtr pan)
        {
            return wrap_panel_above(pan);
        }

        internal static IntPtr panel_below(IntPtr pan)
        {
            return wrap_panel_below(pan);
        }

        internal static void del_panel(IntPtr pan)
        {
            int ret = wrap_del_panel(pan);
            CursesException.Verify(ret, "del_panel");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_new_panel(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_bottom_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_top_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_show_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern void wrap_update_panels();
        [DllImport("CursesWrapper")]
        private static extern int wrap_hide_panel(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_panel_window(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_replace_panel(IntPtr pan, IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_move_panel(IntPtr pan, int starty, int startx);
        [DllImport("CursesWrapper")]
        private static extern int wrap_panel_hidden(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_panel_above(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_panel_below(IntPtr pan);
        [DllImport("CursesWrapper")]
        private static extern int wrap_del_panel(IntPtr pan);
#endif
        #endregion

        #region refresh.c
        internal static void wrefresh(IntPtr win)
        {
            int ret = wrap_wrefresh(win);
            CursesException.Verify(ret, "wrefresh");
        }

        internal static void wnoutrefresh(IntPtr win)
        {
            int ret = wrap_wnoutrefresh(win);
            CursesException.Verify(ret, "wnoutrefresh");
        }

        internal static void doupdate()
        {
            int ret = wrap_doupdate();
            CursesException.Verify(ret, "doupdate");
        }

        internal static void redrawwin(IntPtr win)
        {
            int ret = wrap_redrawwin(win);
            CursesException.Verify(ret, "redrawwin");
        }

        internal static void wredrawln(IntPtr win, int beg_line, int num_lines)
        {
            int ret = wrap_wredrawln(win, beg_line, num_lines);
            CursesException.Verify(ret, "wredrawln");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_wrefresh(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wnoutrefresh(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_doupdate();
        [DllImport("CursesWrapper")]
        private static extern int wrap_redrawwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wredrawln(IntPtr win, int beg_line, int num_lines);
        #endregion

        #region scr_dump.c
        internal static void scr_dump(string filename)
        {
            int ret = wrap_scr_dump(filename);
            CursesException.Verify(ret, "scr_dump");
        }

        internal static void scr_init(string filename)
        {
            int ret = wrap_scr_init(filename);
            CursesException.Verify(ret, "scr_init");
        }

        internal static void scr_restore(string filename)
        {
            int ret = wrap_scr_restore(filename);
            CursesException.Verify(ret, "scr_restore");
        }

        internal static void scr_set(string filename)
        {
            int ret = wrap_scr_set(filename);
            CursesException.Verify(ret, "scr_set");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_dump(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_init(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_restore(String filename);
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_scr_set(String filename);
        #endregion

        #region scroll.c
        internal static void scroll(IntPtr win)
        {
            int ret = wrap_scroll(win);
            CursesException.Verify(ret, "scroll");
        }

        internal static void wscrl(IntPtr win, int n)
        {
            int ret = wrap_wscrl(win, n);
            CursesException.Verify(ret, "wscrl");
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_scroll(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wscrl(IntPtr win, int n);
        #endregion

        #region slk.c
        internal static void slk_init(int fmt)
        {
            int ret = wrap_slk_init(fmt);
            CursesException.Verify(ret, "slk_init");
        }

        internal static void slk_refresh()
        {
            int ret = wrap_slk_refresh();
            CursesException.Verify(ret, "slk_refresh");
        }

        internal static void slk_noutrefresh()
        {
            int ret = wrap_slk_noutrefresh();
            CursesException.Verify(ret, "slk_noutrefresh");
        }

        internal static string slk_label(int labnum)
        {
            IntPtr ret = wrap_slk_label(labnum);
            CursesException.Verify(ret, "slk_label");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static void slk_clear()
        {
            int ret = wrap_slk_clear();
            CursesException.Verify(ret, "slk_clear");
        }

        internal static void slk_restore()
        {
            int ret = wrap_slk_restore();
            CursesException.Verify(ret, "slk_restore");
        }

        internal static void slk_touch()
        {
            int ret = wrap_slk_touch();
            CursesException.Verify(ret, "slk_touch");
        }

        internal static void slk_attron(uint attrs)
        {
            int ret = wrap_slk_attron(attrs);
            CursesException.Verify(ret, "slk_attron");
        }

        internal static void slk_attrset(uint attrs)
        {
            int ret = wrap_slk_attrset(attrs);
            CursesException.Verify(ret, "slk_attrset");
        }

        internal static void slk_attroff(uint attrs)
        {
            int ret = wrap_slk_attroff(attrs);
            CursesException.Verify(ret, "slk_attroff");
        }

        internal static void slk_color(short color_pair)
        {
            int ret = wrap_slk_color(color_pair);
            CursesException.Verify(ret, "slk_color");
        }

#if HAVE_USE_WIDECHAR
        internal static void slk_set(int labnum, string label, int justify)
        {
            int ret = wrap_slk_wset(labnum, label, justify);
            CursesException.Verify(ret, "slk_wset");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Unicode)]
        private static extern int wrap_slk_wset(int labnum, String label, int justify);
#else
        internal static void slk_set(int labnum, string label, int justify)        
        {
            int ret = wrap_slk_set(labnum, label, justify);
            CursesException.Verify(ret, "slk_set");
        }

        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern int wrap_slk_set(int labnum, String label, int justify);
#endif
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_init(int fmt);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_refresh();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_noutrefresh();
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_slk_label(int labnum);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_clear();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_restore();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_touch();
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_attron(uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_attrset(uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_attroff(uint attrs);
        [DllImport("CursesWrapper")]
        private static extern int wrap_slk_color(short color_pair);
        #endregion

        #region termattr.c
        internal static int baudrate()
        {
            int ret = wrap_baudrate();
            CursesException.Verify(ret, "baudrate");
            return ret;
        }

        internal static char erasechar()
        {
            return wrap_erasechar();
        }

        internal static char killchar()
        {
            return wrap_killchar();
        }

        internal static uint termattrs()
        {
            return wrap_termattrs();
        }

        internal static bool has_ic()
        {
            return wrap_has_ic();
        }

        internal static bool has_il()
        {
            return wrap_has_il();
        }

        internal static string termname()
        {
            IntPtr ret = wrap_termname();
            CursesException.Verify(ret, "termname");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static string longname()
        {
            IntPtr ret = wrap_longname();
            CursesException.Verify(ret, "longname");
            return Marshal.PtrToStringAnsi(ret);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_baudrate();
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern char wrap_erasechar();
        [DllImport("CursesWrapper", CharSet = CharSet.Ansi)]
        private static extern char wrap_killchar();
        [DllImport("CursesWrapper")]
        private static extern uint wrap_termattrs();
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_has_ic();
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_has_il();
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_termname();
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_longname();
        #endregion

        #region touch.c
        internal static void touchwin(IntPtr win)
        {
            int ret = wrap_touchwin(win);
            CursesException.Verify(ret, "touchwin");
        }

        internal static void touchline(IntPtr win, int start, int count)
        {
            int ret = wrap_touchline(win, start, count);
            CursesException.Verify(ret, "touchline");
        }

        internal static void untouchwin(IntPtr win)
        {
            int ret = wrap_untouchwin(win);
            CursesException.Verify(ret, "untouchwin");
        }

        internal static void wtouchln(IntPtr win, int y, int n, int changed)
        {
            int ret = wrap_wtouchln(win, y, n, changed);
            CursesException.Verify(ret, "wtouchln");
        }

        internal static bool is_linetouched(IntPtr win, int line)
        {
            return wrap_is_linetouched(win, line);
        }

        internal static bool is_wintouched(IntPtr win)
        {
            return wrap_is_wintouched(win);
        }

        [DllImport("CursesWrapper")]
        private static extern int wrap_touchwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_touchline(IntPtr win, int start, int count);
        [DllImport("CursesWrapper")]
        private static extern int wrap_untouchwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_wtouchln(IntPtr win, int y, int n, int changed);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_is_linetouched(IntPtr win, int line);
        [DllImport("CursesWrapper")]
        private static extern Boolean wrap_is_wintouched(IntPtr win);
        #endregion

        #region util.c
        internal static string unctrl(uint c)
        {
            IntPtr ret = wrap_unctrl(c);
            CursesException.Verify(ret, "unctrl");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static void filter()
        {
            wrap_filter();
        }

        internal static void use_env(bool x)
        {
            wrap_use_env(x);
        }

        internal static void delay_output(int ms)
        {
            int ret = wrap_delay_output(ms);
            CursesException.Verify(ret, "delay_output");
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_unctrl(uint c);
        [DllImport("CursesWrapper")]
        private static extern void wrap_filter();
        [DllImport("CursesWrapper")]
        private static extern void wrap_use_env(Boolean x);
        [DllImport("CursesWrapper")]
        private static extern int wrap_delay_output(int ms);
        #endregion

        #region window.c
        internal static IntPtr newwin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_newwin(nlines, ncols, begy, begx);
            CursesException.Verify(ret, "newwin");
            return ret;
        }

        internal static IntPtr derwin(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_derwin(orig, nlines, ncols, begy, begx);
            CursesException.Verify(ret, "derwin");
            return ret;
        }

        internal static IntPtr subwin(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = wrap_subwin(orig, nlines, ncols, begy, begx);
            CursesException.Verify(ret, "subwin");
            return ret;
        }

        internal static IntPtr dupwin(IntPtr win)
        {
            IntPtr ret = wrap_dupwin(win);
            CursesException.Verify(ret, "dupwin");
            return ret;
        }

        internal static void delwin(IntPtr win)
        {
            int ret = wrap_delwin(win);
            CursesException.Verify(ret, "delwin");
        }

        internal static void mvwin(IntPtr win, int y, int x)
        {
            int ret = wrap_mvwin(win, y, x);
            CursesException.Verify(ret, "mvwin");
        }

        internal static void mvderwin(IntPtr win, int pary, int parx)
        {
            int ret = wrap_mvderwin(win, pary, parx);
            CursesException.Verify(ret, "mvderwin");
        }

        internal static void syncok(IntPtr win, bool bf)
        {
            int ret = wrap_syncok(win, bf);
            CursesException.Verify(ret, "syncok");
        }

        internal static void wsyncup(IntPtr win)
        {
            wrap_wsyncup(win);
        }

        internal static void wcursyncup(IntPtr win)
        {
            wrap_wcursyncup(win);
        }

        internal static void wsyncdown(IntPtr win)
        {
            wrap_wsyncdown(win);
        }

        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_newwin(int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_derwin(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_subwin(IntPtr orig, int nlines, int ncols, int begy, int begx);
        [DllImport("CursesWrapper")]
        private static extern IntPtr wrap_dupwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_delwin(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvwin(IntPtr win, int y, int x);
        [DllImport("CursesWrapper")]
        private static extern int wrap_mvderwin(IntPtr win, int pary, int parx);
        [DllImport("CursesWrapper")]
        private static extern int wrap_syncok(IntPtr win, Boolean bf);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wsyncup(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wcursyncup(IntPtr win);
        [DllImport("CursesWrapper")]
        private static extern void wrap_wsyncdown(IntPtr win);
        #endregion

        #region wrapper.c
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
        #endregion
    }
}
