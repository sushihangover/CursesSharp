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


        public void AddCh(char ch)
        {
            Curses.Verify(NativeMethods.wrap_waddch(this.winptr, (byte)ch));
        }

        public void AddCh(uint ch)
        {
            Curses.Verify(NativeMethods.wrap_waddch(this.winptr, ch));
        }

        public void AddCh(int y, int x, char ch)
        {
            Curses.Verify(NativeMethods.wrap_mvwaddch(this.winptr, y, x, (byte)ch));
        }

        public void AddCh(int y, int x, uint ch)
        {
            Curses.Verify(NativeMethods.wrap_mvwaddch(this.winptr, y, x, ch));
        }

        public void EchoChar(char ch)
        {
            Curses.Verify(NativeMethods.wrap_wechochar(this.winptr, (byte)ch));
        }

        public void EchoChar(uint ch)
        {
            Curses.Verify(NativeMethods.wrap_wechochar(this.winptr, ch));
        }

        public void AddChStr(uint[] chstr)
        {
            this.AddChStr(chstr, chstr.Length);
        }

        public void AddChStr(uint[] chstr, int n)
        {
            Curses.Verify(NativeMethods.wrap_waddchnstr(this.winptr, chstr, n));
        }

        public void AddChStr(int y, int x, uint[] chstr)
        {
            this.AddChStr(y, x, chstr, chstr.Length);
        }

        public void AddChStr(int y, int x, uint[] chstr, int n)
        {
            Curses.Verify(NativeMethods.wrap_mvwaddchnstr(this.winptr, y, x, chstr, n));
        }

        public void AddStr(string str)
        {
            this.AddStr(str, str.Length);
        }

        public void AddStr(string str, int n)
        {
            if (Curses.UseWideChar)
            {
                Curses.Verify(NativeMethods.wrap_waddnwstr(this.winptr, str, n));
            }
            else
            {
                Curses.Verify(NativeMethods.wrap_waddnstr(this.winptr, str, n));
            }
        }

        public void AddStr(int y, int x, string str)
        {
            this.AddStr(y, x, str, str.Length);
        }

        public void AddStr(int y, int x, string str, int n)
        {
            if (Curses.UseWideChar)
            {
                Curses.Verify(NativeMethods.wrap_mvwaddnwstr(this.winptr, y, x, str, n));
            }
            else
            {
                Curses.Verify(NativeMethods.wrap_mvwaddnstr(this.winptr, y, x, str, n));
            }
        }

        public void AttrOff(uint attr)
        {
            Curses.Verify(NativeMethods.wrap_wattroff(this.winptr, attr));
        }

        public void AttrOn(uint attr)
        {
            Curses.Verify(NativeMethods.wrap_wattron(this.winptr, attr));
        }

        public void AttrSet(uint attr)
        {
            Curses.Verify(NativeMethods.wrap_wattrset(this.winptr, attr));
        }

        public void Standend()
        {
            Curses.Verify(NativeMethods.wrap_wstandend(this.winptr));
        }

        public void Standout()
        {
            Curses.Verify(NativeMethods.wrap_wstandout(this.winptr));
        }

        public void ColorSet(short color_pair)
        {
            Curses.Verify(NativeMethods.wrap_wcolor_set(this.winptr, color_pair));
        }

        public void AttrGet(out uint attrs, out short color_pair)
        {
            Curses.Verify(NativeMethods.wrap_wattr_get(this.winptr, out attrs, out color_pair));
        }

        public void ChgAt(int n, uint attr, short color)
        {
            Curses.Verify(NativeMethods.wrap_wchgat(this.winptr, n, attr, color));
        }

        public void ChgAt(int y, int x, int n, uint attr, short color)
        {
            Curses.Verify(NativeMethods.wrap_mvwchgat(this.winptr, y, x, n, attr, color));
        }

        public uint GetBkgd()
        {
            return NativeMethods.wrap_getbkgd(this.winptr);
        }

        public void Bkgd(uint ch)
        {
            Curses.Verify(NativeMethods.wrap_wbkgd(this.winptr, ch));
        }

        public void BkgdSet(uint ch)
        {
            NativeMethods.wrap_wbkgdset(this.winptr, ch);
        }

        public void Border(uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            Curses.Verify(NativeMethods.wrap_wborder(this.winptr, ls, rs, ts, bs, tl, tr, bl, br));
        }

        public void Box(uint verch, uint horch)
        {
            Curses.Verify(NativeMethods.wrap_box(this.winptr, verch, horch));
        }

        public void HLine(uint ch, int n)
        {
            Curses.Verify(NativeMethods.wrap_whline(this.winptr, ch, n));
        }

        public void VLine(uint ch, int n)
        {
            Curses.Verify(NativeMethods.wrap_wvline(this.winptr, ch, n));
        }

        public void HLine(int y, int x, uint ch, int n)
        {
            Curses.Verify(NativeMethods.wrap_mvwhline(this.winptr, y, x, ch, n));
        }

        public void VLine(int y, int x, uint ch, int n)
        {
            Curses.Verify(NativeMethods.wrap_mvwvline(this.winptr, y, x, ch, n));
        }

        public void Clear()
        {
            Curses.Verify(NativeMethods.wrap_wclear(this.winptr));
        }

        public void Erase()
        {
            Curses.Verify(NativeMethods.wrap_werase(this.winptr));
        }

        public void ClrToBot()
        {
            Curses.Verify(NativeMethods.wrap_wclrtobot(this.winptr));
        }

        public void ClrToEol()
        {
            Curses.Verify(NativeMethods.wrap_wclrtoeol(this.winptr));
        }

        public int GetCh()
        {
            return NativeMethods.wrap_wgetch(this.winptr);
        }

        public int GetCh(int y, int x)
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

        public void Move(int y, int x)
        {
            Curses.Verify(NativeMethods.wrap_wmove(this.winptr, y, x));
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

        public void SetScrReg(int top, int bot)
        {
            Curses.Verify(NativeMethods.wrap_wsetscrreg(this.winptr, top, bot));
        }

        public void Refresh()
        {
            Curses.Verify(NativeMethods.wrap_wrefresh(this.winptr));
        }

        public void WnOutRefresh()
        {
            Curses.Verify(NativeMethods.wrap_wnoutrefresh(this.winptr));
        }

        public void RedrawWin()
        {
            Curses.Verify(NativeMethods.wrap_redrawwin(this.winptr));
        }

        public void RedrawLn(int beg_line, int num_lines)
        {
            Curses.Verify(NativeMethods.wrap_wredrawln(this.winptr, beg_line, num_lines));
        }

        public void TouchWin()
        {
            Curses.Verify(NativeMethods.wrap_touchwin(this.winptr));
        }

        public void TouchLine(int start, int count)
        {
            Curses.Verify(NativeMethods.wrap_touchline(this.winptr, start, count));
        }

        public void UntouchWin()
        {
            Curses.Verify(NativeMethods.wrap_untouchwin(this.winptr));
        }

        public void TouchLn(int y, int n, int changed)
        {
            Curses.Verify(NativeMethods.wrap_wtouchln(this.winptr, y, n, changed));
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
            IntPtr newptr = NativeMethods.wrap_derwin(this.winptr, nlines, ncols, begy, begx);
            Curses.Verify(newptr);
            return new Window(newptr, true);
        }

        public Window SubWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = NativeMethods.wrap_subwin(this.winptr, nlines, ncols, begy, begx);
            Curses.Verify(newptr);
            return new Window(newptr, true);
        }

        public Window DupWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = NativeMethods.wrap_dupwin(this.winptr);
            Curses.Verify(newptr);
            return new Window(newptr, true);
        }

        public void MvWin(int y, int x)
        {
            Curses.Verify(NativeMethods.wrap_mvwin(this.winptr, y, x));
        }

        public void MvDerWin(int pary, int parx)
        {
            Curses.Verify(NativeMethods.wrap_mvderwin(this.winptr, pary, parx));
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
