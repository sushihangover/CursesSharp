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

namespace CursesSharp
{
    public class Window : IDisposable
    {
        private IntPtr winptr;
        private bool ownsPtr;

        internal Window(IntPtr winptr, bool ownsPtr)
        {
            this.winptr = winptr;
            this.ownsPtr = ownsPtr;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (this.winptr != IntPtr.Zero && this.ownsPtr)
            {
                Curses.Verify(NativeMethods.wrap_delwin(this.winptr));
                this.winptr = IntPtr.Zero;
            }
        }

        #endregion


        public int AddCh(char ch)
        {
            return Curses.Verify(NativeMethods.wrap_waddch(this.winptr, (byte)ch));
        }

        public int AddCh(uint ch)
        {
            return Curses.Verify(NativeMethods.wrap_waddch(this.winptr, ch));
        }

        public int MvAddCh(int y, int x, char ch)
        {
            return Curses.Verify(NativeMethods.wrap_mvwaddch(this.winptr, y, x, (byte)ch));
        }

        public int MvAddCh(int y, int x, uint ch)
        {
            return Curses.Verify(NativeMethods.wrap_mvwaddch(this.winptr, y, x, ch));
        }

        public int EchoChar(char ch)
        {
            return Curses.Verify(NativeMethods.wrap_wechochar(this.winptr, (byte)ch));
        }

        public int EchoChar(uint ch)
        {
            return Curses.Verify(NativeMethods.wrap_wechochar(this.winptr, ch));
        }

        public int AddChStr(uint[] chstr)
        {
            return Curses.Verify(NativeMethods.wrap_waddchnstr(this.winptr, chstr, chstr.Length));
        }

        public int MvAddChStr(int y, int x, uint[] chstr)
        {
            return Curses.Verify(NativeMethods.wrap_mvwaddchnstr(this.winptr, y, x, chstr, chstr.Length));
        }

        public int AddStr(string str)
        {
            if (Curses.UseWideChar)
            {
                return Curses.Verify(NativeMethods.wrap_waddnwstr(this.winptr, str, str.Length));
            }
            else
            {
                return Curses.Verify(NativeMethods.wrap_waddnstr(this.winptr, str, str.Length));
            }
        }

        public int MvAddStr(int y, int x, string str)
        {
            if (Curses.UseWideChar)
            {
                return Curses.Verify(NativeMethods.wrap_mvwaddnwstr(this.winptr, y, x, str, str.Length));
            }
            else
            {
                return Curses.Verify(NativeMethods.wrap_mvwaddnstr(this.winptr, y, x, str, str.Length));
            }
        }

        public int AttrOff(uint attr)
        {
            return Curses.Verify(NativeMethods.wrap_wattroff(this.winptr, attr));
        }

        public int AttrOn(uint attr)
        {
            return Curses.Verify(NativeMethods.wrap_wattron(this.winptr, attr));
        }

        public int AttrSet(uint attr)
        {
            return Curses.Verify(NativeMethods.wrap_wattrset(this.winptr, attr));
        }

        public int Standend()
        {
            return Curses.Verify(NativeMethods.wrap_wstandend(this.winptr));
        }

        public int Standout()
        {
            return Curses.Verify(NativeMethods.wrap_wstandout(this.winptr));
        }

        public int ColorSet(short color_pair)
        {
            return Curses.Verify(NativeMethods.wrap_wcolor_set(this.winptr, color_pair));
        }

        public int AttrGet(out uint attrs, out short color_pair)
        {
            return Curses.Verify(NativeMethods.wrap_wattr_get(this.winptr, out attrs, out color_pair));
        }

        public int ChgAt(int n, uint attr, short color)
        {
            return Curses.Verify(NativeMethods.wrap_wchgat(this.winptr, n, attr, color));
        }

        public int MvChgAt(int y, int x, int n, uint attr, short color)
        {
            return Curses.Verify(NativeMethods.wrap_mvwchgat(this.winptr, y, x, n, attr, color));
        }

        public uint GetBkgd()
        {
            return NativeMethods.wrap_getbkgd(this.winptr);
        }

        public int Bkgd(uint ch)
        {
            return Curses.Verify(NativeMethods.wrap_wbkgd(this.winptr, ch));
        }

        public void BkgdSet(uint ch)
        {
            NativeMethods.wrap_wbkgdset(this.winptr, ch);
        }

        public int Border(uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            return Curses.Verify(NativeMethods.wrap_wborder(this.winptr, ls, rs, ts, bs, tl, tr, bl, br));
        }

        public int Box(uint verch, uint horch)
        {
            return Curses.Verify(NativeMethods.wrap_box(this.winptr, verch, horch));
        }

        public int HLine(uint ch, int n)
        {
            return Curses.Verify(NativeMethods.wrap_whline(this.winptr, ch, n));
        }

        public int VLine(uint ch, int n)
        {
            return Curses.Verify(NativeMethods.wrap_wvline(this.winptr, ch, n));
        }

        public int MvHLine(int y, int x, uint ch, int n)
        {
            return Curses.Verify(NativeMethods.wrap_mvwhline(this.winptr, y, x, ch, n));
        }

        public int MvVLine(int y, int x, uint ch, int n)
        {
            return Curses.Verify(NativeMethods.wrap_mvwvline(this.winptr, y, x, ch, n));
        }

        public int Clear()
        {
            return Curses.Verify(NativeMethods.wrap_wclear(this.winptr));
        }

        public int Erase()
        {
            return Curses.Verify(NativeMethods.wrap_werase(this.winptr));
        }

        public int ClrToBot()
        {
            return Curses.Verify(NativeMethods.wrap_wclrtobot(this.winptr));
        }

        public int ClrToEol()
        {
            return Curses.Verify(NativeMethods.wrap_wclrtoeol(this.winptr));
        }

        public int GetCh()
        {
            return NativeMethods.wrap_wgetch(this.winptr);
        }

        public int MvGetCh(int y, int x)
        {
            return NativeMethods.wrap_mvwgetch(this.winptr, y, x);
        }

        public void GetYX(out int y, out int x)
        {
            NativeMethods.wrap_getyx(this.winptr, out y, out x);
        }

        public void GetParYX(out int y, out int x)
        {
            NativeMethods.wrap_getparyx(this.winptr, out y, out x);
        }

        public void GetBegYX(out int y, out int x)
        {
            NativeMethods.wrap_getbegyx(this.winptr, out y, out x);
        }

        public void GetMaxYX(out int y, out int x)
        {
            NativeMethods.wrap_getmaxyx(this.winptr, out y, out x);
        }

        public bool IntrFlush
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_intrflush(this.winptr, value));
            }
        }

        public bool Keypad
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_keypad(this.winptr, value));
            }
        }

        public bool Meta
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_meta(this.winptr, value));
            }
        }

        public bool NoDelay
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_nodelay(this.winptr, value));
            }
        }

        public bool NoTimeout
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_notimeout(this.winptr, value));
            }
        }

        public int Timeout
        {
            set
            {
                NativeMethods.wrap_wtimeout(this.winptr, value);
            }
        }

        public int Move(int y, int x)
        {
            return Curses.Verify(NativeMethods.wrap_wmove(this.winptr, y, x));
        }

        public bool ClearOk
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_clearok(this.winptr, value));
            }
        }

        public bool IdlOk
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_idlok(this.winptr, value));
            }
        }

        public bool IdcOk
        {
            set
            {
                NativeMethods.wrap_idcok(this.winptr, value);
            }
        }

        public bool ImmedOk
        {
            set
            {
                NativeMethods.wrap_immedok(this.winptr, value);
            }
        }

        public bool LeaveOk
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_leaveok(this.winptr, value));
            }
        }

        public bool ScrollOk
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_scrollok(this.winptr, value));
            }
        }

        public int SetScrReg(int top, int bot)
        {
            return Curses.Verify(NativeMethods.wrap_wsetscrreg(this.winptr, top, bot));
        }

        public int Refresh()
        {
            return Curses.Verify(NativeMethods.wrap_wrefresh(this.winptr));
        }

        public int WnOutRefresh()
        {
            return Curses.Verify(NativeMethods.wrap_wnoutrefresh(this.winptr));
        }

        public int RedrawWin()
        {
            return Curses.Verify(NativeMethods.wrap_redrawwin(this.winptr));
        }

        public int RedrawLn(int beg_line, int num_lines)
        {
            return Curses.Verify(NativeMethods.wrap_wredrawln(this.winptr, beg_line, num_lines));
        }

        public int TouchWin()
        {
            return Curses.Verify(NativeMethods.wrap_touchwin(this.winptr));
        }

        public int TouchLine(int start, int count)
        {
            return Curses.Verify(NativeMethods.wrap_touchline(this.winptr, start, count));
        }

        public int UntouchWin()
        {
            return Curses.Verify(NativeMethods.wrap_untouchwin(this.winptr));
        }

        public int TouchLn(int y, int n, int changed)
        {
            return Curses.Verify(NativeMethods.wrap_wtouchln(this.winptr, y, n, changed));
        }

        public bool IsLineTouched(int line)
        {
            return NativeMethods.wrap_is_linetouched(this.winptr, line);
        }

        public bool IsWinTouched()
        {
            return NativeMethods.wrap_is_wintouched(this.winptr);
        }

        public Window DerWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = Curses.Verify(NativeMethods.wrap_derwin(this.winptr, nlines, ncols, begy, begx));
            return new Window(newptr, true);
        }

        public Window SubWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = Curses.Verify(NativeMethods.wrap_subwin(this.winptr, nlines, ncols, begy, begx));
            return new Window(newptr, true);
        }

        public Window DupWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = Curses.Verify(NativeMethods.wrap_dupwin(this.winptr));
            return new Window(newptr, true);
        }

        public int MvWin(int y, int x)
        {
            return Curses.Verify(NativeMethods.wrap_mvwin(this.winptr, y, x));
        }

        public int MvDerWin(int pary, int parx)
        {
            return Curses.Verify(NativeMethods.wrap_mvderwin(this.winptr, pary, parx));
        }

        public bool SyncOk
        {
            set
            {
                Curses.Verify(NativeMethods.wrap_syncok(this.winptr, value));
            }
        }

        public void SyncUp()
        {
            NativeMethods.wrap_wsyncup(this.winptr);
        }

        public void SyncDown()
        {
            NativeMethods.wrap_wsyncdown(this.winptr);
        }

        public void CurSyncUp()
        {
            NativeMethods.wrap_wcursyncup(this.winptr);
        }
    }
}
