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

namespace CursesSharp
{
    internal static class CursesMethods
    {
        #region addch.c
        internal static void waddch(IntPtr win, uint ch)
        {
            int ret = NativeMethods.wrap_waddch(win, ch);
            Verify(ret, "waddch");
        }

        internal static void mvwaddch(IntPtr win, int y, int x, uint ch)
        {
            int ret = NativeMethods.wrap_mvwaddch(win, y, x, ch);
            Verify(ret, "mvwaddch");
        }

        internal static void wechochar(IntPtr win, uint ch)
        {
            int ret = NativeMethods.wrap_wechochar(win, ch);
            Verify(ret, "wechochar");
        }
        #endregion

        #region addchstr.c
        internal static void waddchnstr(IntPtr win, uint[] chstr, int n)
        {
            int ret = NativeMethods.wrap_waddchnstr(win, chstr, n);
            Verify(ret, "waddchnstr");
        }

        internal static void mvwaddchnstr(IntPtr win, int y, int x, uint[] chstr, int n)
        {
            int ret = NativeMethods.wrap_mvwaddchnstr(win, y, x, chstr, n);
            Verify(ret, "mvwaddchnstr");
        }
        #endregion

        #region addstr.c
        internal static void waddnstr(IntPtr win, string str, int n)
        {
            int ret = NativeMethods.wrap_waddnstr(win, str, n);
            Verify(ret, "waddnstr");
        }

        internal static void mvwaddnstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = NativeMethods.wrap_mvwaddnstr(win, y, x, str, n);
            Verify(ret, "mvwaddnstr");
        }

        internal static void waddnwstr(IntPtr win, string str, int n)
        {
            int ret = NativeMethods.wrap_waddnwstr(win, str, n);
            Verify(ret, "waddnwstr");
        }

        internal static void mvwaddnwstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = NativeMethods.wrap_mvwaddnwstr(win, y, x, str, n);
            Verify(ret, "mvwaddnwstr");
        }
        #endregion

        #region attr.c
        internal static void wattroff(IntPtr win, uint attrs)
        {
            int ret = NativeMethods.wrap_wattroff(win, attrs);
            Verify(ret, "wattroff");
        }

        internal static void wattron(IntPtr win, uint attrs)
        {
            int ret = NativeMethods.wrap_wattron(win, attrs);
            Verify(ret, "wattron");
        }

        internal static void wattrset(IntPtr win, uint attrs)
        {
            int ret = NativeMethods.wrap_wattrset(win, attrs);
            Verify(ret, "wattrset");
        }

        internal static void wstandend(IntPtr win)
        {
            int ret = NativeMethods.wrap_wstandend(win);
            Verify(ret, "wstandend");
        }

        internal static void wstandout(IntPtr win)
        {
            int ret = NativeMethods.wrap_wstandout(win);
            Verify(ret, "wstandout");
        }

        internal static void wcolor_set(IntPtr win, short color_pair)
        {
            int ret = NativeMethods.wrap_wcolor_set(win, color_pair);
            Verify(ret, "wcolor_set");
        }

        internal static void wattr_get(IntPtr win, out uint attrs, out short color_pair)
        {
            int ret = NativeMethods.wrap_wattr_get(win, out attrs, out color_pair);
            Verify(ret, "wattr_get");
        }

        internal static void wchgat(IntPtr win, int n, uint attr, short color)
        {
            int ret = NativeMethods.wrap_wchgat(win, n, attr, color);
            Verify(ret, "wchgat");
        }

        internal static void mvwchgat(IntPtr win, int y, int x, int n, uint attr, short color)
        {
            int ret = NativeMethods.wrap_mvwchgat(win, y, x, n, attr, color);
            Verify(ret, "mvwchgat");
        }
        #endregion

        #region beep.c
        internal static void beep()
        {
            int ret = NativeMethods.wrap_beep();
            Verify(ret, "beep");
        }

        internal static void flash()
        {
            int ret = NativeMethods.wrap_flash();
            Verify(ret, "flash");
        }
        #endregion

        #region bkgd.c
        internal static uint getbkgd(IntPtr win)
        {
            return NativeMethods.wrap_getbkgd(win);
        }

        internal static void wbkgd(IntPtr win, uint ch)
        {
            int ret = NativeMethods.wrap_wbkgd(win, ch);
            Verify(ret, "wbkgd");
        }

        internal static void wbkgdset(IntPtr win, uint ch)
        {
            NativeMethods.wrap_wbkgdset(win, ch);
        }
        #endregion

        #region border.c
        internal static void wborder(IntPtr win, uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            int ret = NativeMethods.wrap_wborder(win, ls, rs, ts, bs, tl, tr, bl, br);
            Verify(ret, "wborder");
        }

        internal static void box(IntPtr win, uint verch, uint horch)
        {
            int ret = NativeMethods.wrap_box(win, verch, horch);
            Verify(ret, "box");
        }

        internal static void whline(IntPtr win, uint ch, int n)
        {
            int ret = NativeMethods.wrap_whline(win, ch, n);
            Verify(ret, "whline");
        }

        internal static void wvline(IntPtr win, uint ch, int n)
        {
            int ret = NativeMethods.wrap_wvline(win, ch, n);
            Verify(ret, "wvline");
        }

        internal static void mvwhline(IntPtr win, int y, int x, uint ch, int n)
        {
            int ret = NativeMethods.wrap_mvwhline(win, y, x, ch, n);
            Verify(ret, "mvwhline");
        }

        internal static void mvwvline(IntPtr win, int y, int x, uint ch, int n)
        {
            int ret = NativeMethods.wrap_mvwvline(win, y, x, ch, n);
            Verify(ret, "mvwvline");
        }
        #endregion

        #region clear.c
        internal static void wclear(IntPtr win)
        {
            int ret = NativeMethods.wrap_wclear(win);
            Verify(ret, "wclear");
        }

        internal static void werase(IntPtr win)
        {
            int ret = NativeMethods.wrap_werase(win);
            Verify(ret, "werase");
        }

        internal static void wclrtobot(IntPtr win)
        {
            int ret = NativeMethods.wrap_wclrtobot(win);
            Verify(ret, "wclrtobot");
        }

        internal static void wclrtoeol(IntPtr win)
        {
            int ret = NativeMethods.wrap_wclrtoeol(win);
            Verify(ret, "wclrtoeol");
        }
        #endregion

        #region color.c
        internal static uint COLOR_PAIR(int n)
        {
            return NativeMethods.wrap_COLOR_PAIR(n);
        }

        internal static short PAIR_NUMBER(uint n)
        {
            return NativeMethods.wrap_PAIR_NUMBER(n);
        }

        internal static void start_color()
        {
            int ret = NativeMethods.wrap_start_color();
            Verify(ret, "start_color");
        }

        internal static void init_pair(short color, short fg, short bg)
        {
            int ret = NativeMethods.wrap_init_pair(color, fg, bg);
            Verify(ret, "init_pair");
        }

        internal static void init_color(short color, short red, short green, short blue)
        {
            int ret = NativeMethods.wrap_init_color(color, red, green, blue);
            Verify(ret, "init_color");
        }

        internal static void color_content(short color, out short red, out short green, out short blue)
        {
            int ret = NativeMethods.wrap_color_content(color, out red, out green, out blue);
            Verify(ret, "color_content");
        }

        internal static void pair_content(short pair, out short fg, out short bg)
        {
            int ret = NativeMethods.wrap_pair_content(pair, out fg, out bg);
            Verify(ret, "pair_content");
        }

        internal static bool has_colors()
        {
            return NativeMethods.wrap_has_colors();
        }

        internal static bool can_change_color()
        {
            return NativeMethods.wrap_can_change_color();
        }

        internal static void assume_default_colors(int f, int b)
        {
            int ret = NativeMethods.wrap_assume_default_colors(f, b);
            Verify(ret, "assume_default_colors");
        }

        internal static void use_default_colors()
        {
            int ret = NativeMethods.wrap_use_default_colors();
            Verify(ret, "use_default_colors");
        }
        #endregion

        #region debug.c
        internal static void traceon()
        {
            NativeMethods.wrap_traceon();
        }

        internal static void traceoff()
        {
            NativeMethods.wrap_traceoff();
        }
        #endregion

        #region delch.c
        internal static void wdelch(IntPtr win)
        {
            int ret = NativeMethods.wrap_wdelch(win);
            Verify(ret, "wdelch");
        }

        internal static void mvwdelch(IntPtr win, int y, int x)
        {
            int ret = NativeMethods.wrap_mvwdelch(win, y, x);
            Verify(ret, "mvwdelch");
        }
        #endregion

        #region deleteln.c
        internal static void wdeleteln(IntPtr win)
        {
            int ret = NativeMethods.wrap_wdeleteln(win);
            Verify(ret, "wdeleteln");
        }

        internal static void winsdelln(IntPtr win, int n)
        {
            int ret = NativeMethods.wrap_winsdelln(win, n);
            Verify(ret, "winsdelln");
        }

        internal static void winsertln(IntPtr win)
        {
            int ret = NativeMethods.wrap_winsertln(win);
            Verify(ret, "winsertln");
        }
        #endregion

        #region getch.c
        internal static int wgetch(IntPtr win)
        {
            return NativeMethods.wrap_wgetch(win);
        }

        internal static int mvwgetch(IntPtr win, int y, int x)
        {
            return NativeMethods.wrap_mvwgetch(win, y, x);
        }

        internal static void ungetch(int ch)
        {
            int ret = NativeMethods.wrap_ungetch(ch);
            Verify(ret, "ungetch");
        }

        internal static void flushinp()
        {
            int ret = NativeMethods.wrap_flushinp();
            Verify(ret, "flushinp");
        }
        #endregion

        #region getstr.c
        internal static void wgetnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = NativeMethods.wrap_wgetnstr(win, str, n);
            Verify(ret, "wgetnstr");
        }

        internal static void mvwgetnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = NativeMethods.wrap_mvwgetnstr(win, y, x, str, n);
            Verify(ret, "mvwgetnstr");
        }

        internal static void wgetn_wstr(IntPtr win, StringBuilder wstr, int n)
        {
            int ret = NativeMethods.wrap_wgetnstr(win, wstr, n);
            Verify(ret, "wgetn_wstr");
        }

        internal static void mvwgetn_wstr(IntPtr win, int y, int x, StringBuilder wstr, int n)
        {
            int ret = NativeMethods.wrap_mvwgetnstr(win, y, x, wstr, n);
            Verify(ret, "mvwgetn_wstr");
        }
        #endregion

        #region getyx.c
        internal static void getyx(IntPtr win, out int y, out int x)
        {
            NativeMethods.wrap_getyx(win, out y, out x);
        }

        internal static void getparyx(IntPtr win, out int y, out int x)
        {
            NativeMethods.wrap_getparyx(win, out y, out x);
        }

        internal static void getbegyx(IntPtr win, out int y, out int x)
        {
            NativeMethods.wrap_getbegyx(win, out y, out x);
        }

        internal static void getmaxyx(IntPtr win, out int y, out int x)
        {
            NativeMethods.wrap_getmaxyx(win, out y, out x);
        }
        #endregion

        #region inch.c
        internal static uint winch(IntPtr win)
        {
            uint ret = NativeMethods.wrap_winch(win);
            Verify((int)ret, "winch");
            return ret;
        }

        internal static uint mvwinch(IntPtr win, int y, int x)
        {
            uint ret = NativeMethods.wrap_mvwinch(win, y, x);
            Verify((int)ret, "mvwinch");
            return ret;
        }
        #endregion

        #region inchstr.c
        internal static int winchnstr(IntPtr win, uint[] ch, int n)
        {
            int ret = NativeMethods.wrap_winchnstr(win, ch, n);
            Verify(ret, "winchnstr");
            return ret;
        }

        internal static int mvwinchnstr(IntPtr win, int y, int x, uint[] ch, int n)
        {
            int ret = NativeMethods.wrap_mvwinchnstr(win, y, x, ch, n);
            Verify(ret, "mvwinchnstr");
            return ret;
        }

        #endregion

        #region initscr.c
        internal static IntPtr initscr()
        {
            IntPtr ret = NativeMethods.wrap_initscr();
            Verify(ret, "initscr");
            return ret;
        }

        internal static void endwin()
        {
            int ret = NativeMethods.wrap_endwin();
            Verify(ret, "endwin");
        }

        internal static bool isendwin()
        {
            return NativeMethods.wrap_isendwin();
        }

        internal static void resize_term(int nlines, int ncols)
        {
            int ret = NativeMethods.wrap_resize_term(nlines, ncols);
            Verify(ret, "resize_term");
        }
        #endregion

        #region inopts.c
        internal static void cbreak()
        {
            int ret = NativeMethods.wrap_cbreak();
            Verify(ret, "cbreak");
        }

        internal static void nocbreak()
        {
            int ret = NativeMethods.wrap_nocbreak();
            Verify(ret, "nocbreak");
        }

        internal static void echo()
        {
            int ret = NativeMethods.wrap_echo();
            Verify(ret, "echo");
        }

        internal static void noecho()
        {
            int ret = NativeMethods.wrap_noecho();
            Verify(ret, "noecho");
        }

        internal static void halfdelay(int tenths)
        {
            int ret = NativeMethods.wrap_halfdelay(tenths);
            Verify(ret, "halfdelay");
        }

        internal static void intrflush(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_intrflush(win, bf);
            Verify(ret, "intrflush");
        }

        internal static void keypad(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_keypad(win, bf);
            Verify(ret, "keypad");
        }

        internal static void meta(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_meta(win, bf);
            Verify(ret, "meta");
        }

        internal static void nl()
        {
            int ret = NativeMethods.wrap_nl();
            Verify(ret, "nl");
        }

        internal static void nonl()
        {
            int ret = NativeMethods.wrap_nonl();
            Verify(ret, "nonl");
        }

        internal static void nodelay(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_nodelay(win, bf);
            Verify(ret, "nodelay");
        }

        internal static void raw()
        {
            int ret = NativeMethods.wrap_raw();
            Verify(ret, "raw");
        }

        internal static void noraw()
        {
            int ret = NativeMethods.wrap_noraw();
            Verify(ret, "noraw");
        }

        internal static void qiflush()
        {
            NativeMethods.wrap_qiflush();
        }

        internal static void noqiflush()
        {
            NativeMethods.wrap_noqiflush();
        }

        internal static void notimeout(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_notimeout(win, bf);
            Verify(ret, "notimeout");
        }

        internal static void wtimeout(IntPtr win, int delay)
        {
            NativeMethods.wrap_wtimeout(win, delay);
        }
        #endregion

        #region insch.c
        internal static void winsch(IntPtr win, uint ch)
        {
            int ret = NativeMethods.wrap_winsch(win, ch);
            Verify(ret, "winsch");
        }

        internal static void mvwinsch(IntPtr win, int y, int x, uint ch)
        {
            int ret = NativeMethods.wrap_mvwinsch(win, y, x, ch);
            Verify(ret, "mvwinsch");
        }
        #endregion

        #region insstr.c
        internal static void winsnstr(IntPtr win, string str, int n)
        {
            int ret = NativeMethods.wrap_winsnstr(win, str, n);
            Verify(ret, "winsnstr");
        }

        internal static void mvwinsnstr(IntPtr win, int y, int x, string str, int n)
        {
            int ret = NativeMethods.wrap_mvwinsnstr(win, y, x, str, n);
            Verify(ret, "mvwinsnstr");
        }

        internal static void wins_nwstr(IntPtr win, string wstr, int n)
        {
            int ret = NativeMethods.wrap_wins_nwstr(win, wstr, n);
            Verify(ret, "wins_nwstr");
        }

        internal static void mvwins_nwstr(IntPtr win, int y, int x, string wstr, int n)
        {
            int ret = NativeMethods.wrap_mvwins_nwstr(win, y, x, wstr, n);
            Verify(ret, "mvwins_nwstr");
        }
        #endregion

        #region instr.c
        internal static int winnstr(IntPtr win, StringBuilder str, int n)
        {
            int ret = NativeMethods.wrap_winnstr(win, str, n);
            Verify(ret, "winnstr");
            return ret;
        }

        internal static int mvwinnstr(IntPtr win, int y, int x, StringBuilder str, int n)
        {
            int ret = NativeMethods.wrap_mvwinnstr(win, y, x, str, n);
            Verify(ret, "mvwinnstr");
            return ret;
        }

        internal static int winnwstr(IntPtr win, StringBuilder wstr, int n)
        {
            int ret = NativeMethods.wrap_winnwstr(win, wstr, n);
            Verify(ret, "winnwstr");
            return ret;
        }

        internal static int mvwinnwstr(IntPtr win, int y, int x, StringBuilder wstr, int n)
        {
            int ret = NativeMethods.wrap_mvwinnwstr(win, y, x, wstr, n);
            Verify(ret, "mvwinnwstr");
            return ret;
        }

        #endregion

        #region kernel.c
        internal static void def_prog_mode()
        {
            int ret = NativeMethods.wrap_def_prog_mode();
            Verify(ret, "def_prog_mode");
        }

        internal static void def_shell_mode()
        {
            int ret = NativeMethods.wrap_def_shell_mode();
            Verify(ret, "def_shell_mode");
        }

        internal static void reset_prog_mode()
        {
            int ret = NativeMethods.wrap_reset_prog_mode();
            Verify(ret, "reset_prog_mode");
        }

        internal static void reset_shell_mode()
        {
            int ret = NativeMethods.wrap_reset_shell_mode();
            Verify(ret, "reset_shell_mode");
        }

        internal static void resetty()
        {
            int ret = NativeMethods.wrap_resetty();
            Verify(ret, "resetty");
        }

        internal static void savetty()
        {
            int ret = NativeMethods.wrap_savetty();
            Verify(ret, "savetty");
        }

        internal static void getsyx(out int y, out int x)
        {
            NativeMethods.wrap_getsyx(out y, out x);
        }

        internal static void setsyx(int y, int x)
        {
            NativeMethods.wrap_setsyx(y, x);
        }

        internal static void ripoffline(int line, RipOffLineFunInt init)
        {
            int ret = NativeMethods.wrap_ripoffline(line, init);
            Verify(ret, "ripoffline");
        }

        internal static void napms(int ms)
        {
            int ret = NativeMethods.wrap_napms(ms);
            Verify(ret, "napms");
        }

        internal static int curs_set(int visibility)
        {
            return NativeMethods.wrap_curs_set(visibility);
        }
        #endregion

        #region keyname.c
        internal static string keyname(int key)
        {
            IntPtr ret = NativeMethods.wrap_keyname(key);
            Verify(ret, "keyname");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static string key_name(char c)
        {
            IntPtr ret = NativeMethods.wrap_key_name(c);
            Verify(ret, "key_name");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static bool has_key(int key)
        {
            return NativeMethods.wrap_has_key(key);
        }
        #endregion

        #region move.c
        internal static void wmove(IntPtr win, int y, int x)
        {
            int ret = NativeMethods.wrap_wmove(win, y, x);
            Verify(ret, "wmove");
        }
        #endregion

        #region outopts.c
        internal static void clearok(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_clearok(win, bf);
            Verify(ret, "clearok");
        }

        internal static void idlok(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_idlok(win, bf);
            Verify(ret, "idlok");
        }

        internal static void idcok(IntPtr win, bool bf)
        {
            NativeMethods.wrap_idcok(win, bf);
        }

        internal static void immedok(IntPtr win, bool bf)
        {
            NativeMethods.wrap_immedok(win, bf);
        }

        internal static void leaveok(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_leaveok(win, bf);
            Verify(ret, "leaveok");
        }

        internal static void wsetscrreg(IntPtr win, int top, int bot)
        {
            int ret = NativeMethods.wrap_wsetscrreg(win, top, bot);
            Verify(ret, "wsetscrreg");
        }

        internal static void scrollok(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_scrollok(win, bf);
            Verify(ret, "scrollok");
        }
        #endregion

        #region overlay.c
        internal static void overlay(IntPtr src_w, IntPtr dst_w)
        {
            int ret = NativeMethods.wrap_overlay(src_w, dst_w);
            Verify(ret, "overlay");
        }

        internal static void overwrite(IntPtr src_w, IntPtr dst_w)
        {
            int ret = NativeMethods.wrap_overwrite(src_w, dst_w);
            Verify(ret, "overwrite");
        }

        internal static void copywin(IntPtr src_w, IntPtr dst_w, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, bool overlay)
        {
            int ret = NativeMethods.wrap_copywin(src_w, dst_w, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
            Verify(ret, "copywin");
        }
        #endregion

        #region pad.c
        internal static IntPtr newpad(int nlines, int ncols)
        {
            IntPtr ret = NativeMethods.wrap_newpad(nlines, ncols);
            Verify(ret, "newpad");
            return ret;
        }

        internal static IntPtr subpad(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = NativeMethods.wrap_subpad(orig, nlines, ncols, begy, begx);
            Verify(ret, "subpad");
            return ret;
        }

        internal static void prefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            int ret = NativeMethods.wrap_prefresh(win, py, px, sy1, sx1, sy2, sx2);
            Verify(ret, "prefresh");
        }

        internal static void pnoutrefresh(IntPtr win, int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            int ret = NativeMethods.wrap_pnoutrefresh(win, py, px, sy1, sx1, sy2, sx2);
            Verify(ret, "pnoutrefresh");
        }

        internal static void pechochar(IntPtr pad, uint ch)
        {
            int ret = NativeMethods.wrap_pechochar(pad, ch);
            Verify(ret, "pechochar");
        }
        #endregion

        #region refresh.c
        internal static void wrefresh(IntPtr win)
        {
            int ret = NativeMethods.wrap_wrefresh(win);
            Verify(ret, "wrefresh");
        }

        internal static void wnoutrefresh(IntPtr win)
        {
            int ret = NativeMethods.wrap_wnoutrefresh(win);
            Verify(ret, "wnoutrefresh");
        }

        internal static void doupdate()
        {
            int ret = NativeMethods.wrap_doupdate();
            Verify(ret, "doupdate");
        }

        internal static void redrawwin(IntPtr win)
        {
            int ret = NativeMethods.wrap_redrawwin(win);
            Verify(ret, "redrawwin");
        }

        internal static void wredrawln(IntPtr win, int beg_line, int num_lines)
        {
            int ret = NativeMethods.wrap_wredrawln(win, beg_line, num_lines);
            Verify(ret, "wredrawln");
        }
        #endregion

        #region scroll.c
        internal static void scroll(IntPtr win)
        {
            int ret = NativeMethods.wrap_scroll(win);
            Verify(ret, "scroll");
        }

        internal static void wscrl(IntPtr win, int n)
        {
            int ret = NativeMethods.wrap_wscrl(win, n);
            Verify(ret, "wscrl");
        }
        #endregion

        #region touch.c
        internal static void touchwin(IntPtr win)
        {
            int ret = NativeMethods.wrap_touchwin(win);
            Verify(ret, "touchwin");
        }

        internal static void touchline(IntPtr win, int start, int count)
        {
            int ret = NativeMethods.wrap_touchline(win, start, count);
            Verify(ret, "touchline");
        }

        internal static void untouchwin(IntPtr win)
        {
            int ret = NativeMethods.wrap_untouchwin(win);
            Verify(ret, "untouchwin");
        }

        internal static void wtouchln(IntPtr win, int y, int n, int changed)
        {
            int ret = NativeMethods.wrap_wtouchln(win, y, n, changed);
            Verify(ret, "wtouchln");
        }

        internal static bool is_linetouched(IntPtr win, int line)
        {
            return NativeMethods.wrap_is_linetouched(win, line);
        }

        internal static bool is_wintouched(IntPtr win)
        {
            return NativeMethods.wrap_is_wintouched(win);
        }
        #endregion

        #region util.c
        internal static string unctrl(uint c)
        {
            IntPtr ret = NativeMethods.wrap_unctrl(c);
            Verify(ret, "unctrl");
            return Marshal.PtrToStringAnsi(ret);
        }

        internal static void filter()
        {
            NativeMethods.wrap_filter();
        }

        internal static void use_env(bool x)
        {
            NativeMethods.wrap_use_env(x);
        }

        internal static void delay_output(int ms)
        {
            int ret = NativeMethods.wrap_delay_output(ms);
            Verify(ret, "delay_output");
        }
        #endregion

        #region window.c
        internal static IntPtr newwin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = NativeMethods.wrap_newwin(nlines, ncols, begy, begx);
            Verify(ret, "newwin");
            return ret;
        }

        internal static IntPtr derwin(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = NativeMethods.wrap_derwin(orig, nlines, ncols, begy, begx);
            Verify(ret, "derwin");
            return ret;
        }

        internal static IntPtr subwin(IntPtr orig, int nlines, int ncols, int begy, int begx)
        {
            IntPtr ret = NativeMethods.wrap_subwin(orig, nlines, ncols, begy, begx);
            Verify(ret, "subwin");
            return ret;
        }

        internal static IntPtr dupwin(IntPtr win)
        {
            IntPtr ret = NativeMethods.wrap_dupwin(win);
            Verify(ret, "dupwin");
            return ret;
        }

        internal static void delwin(IntPtr win)
        {
            int ret = NativeMethods.wrap_delwin(win);
            Verify(ret, "delwin");
        }

        internal static void mvwin(IntPtr win, int y, int x)
        {
            int ret = NativeMethods.wrap_mvwin(win, y, x);
            Verify(ret, "mvwin");
        }

        internal static void mvderwin(IntPtr win, int pary, int parx)
        {
            int ret = NativeMethods.wrap_mvderwin(win, pary, parx);
            Verify(ret, "mvderwin");
        }

        internal static void syncok(IntPtr win, bool bf)
        {
            int ret = NativeMethods.wrap_syncok(win, bf);
            Verify(ret, "syncok");
        }

        internal static void wsyncup(IntPtr win)
        {
            NativeMethods.wrap_wsyncup(win);
        }

        internal static void wcursyncup(IntPtr win)
        {
            NativeMethods.wrap_wcursyncup(win);
        }

        internal static void wsyncdown(IntPtr win)
        {
            NativeMethods.wrap_wsyncdown(win);
        }
        #endregion

        #region wrapper.c
        internal static bool has_widechar()
        {
            return NativeMethods.wrap_has_widechar();
        }

        internal static int LINES()
        {
            return NativeMethods.wrap_LINES();
        }

        internal static int COLS()
        {
            return NativeMethods.wrap_COLS();
        }

        internal static int COLORS()
        {
            return NativeMethods.wrap_COLORS();
        }

        internal static int COLOR_PAIRS()
        {
            return NativeMethods.wrap_COLOR_PAIRS();
        }

        internal static int TABSIZE()
        {
            return NativeMethods.wrap_TABSIZE();
        }
        #endregion

        #region Error checking
        internal static void Verify(int result, string fname)
        {
            if (result == -1)
                throw new CursesException(fname + "() returned ERR");
        }

        internal static void Verify(IntPtr result, string fname)
        {
            if (result == IntPtr.Zero)
                throw new CursesException(fname + "() returned NULL");
        }
        #endregion
    }
}
