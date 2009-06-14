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

namespace CursesSharp
{
    public abstract class WindowBase: IDisposable
    {
        internal const int DEFAULT_BUFSZ = 1023;

        private IntPtr winptr;
        private bool ownsPtr;

        protected internal WindowBase(IntPtr winptr, bool ownsPtr)
        {
            this.winptr = winptr;
            this.ownsPtr = ownsPtr;
        }

        protected internal IntPtr Handle
        {
            get { return this.winptr; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (this.winptr != IntPtr.Zero && this.ownsPtr)
            {
                CursesMethods.delwin(this.winptr);
                this.winptr = IntPtr.Zero;
            }
        }

        #endregion

        public void AddCh(char ch)
        {
            CursesMethods.waddch(this.winptr, (byte)ch);
        }

        public void AddCh(uint ch)
        {
            CursesMethods.waddch(this.winptr, ch);
        }

        public void AddCh(int y, int x, char ch)
        {
            CursesMethods.mvwaddch(this.winptr, y, x, (byte)ch);
        }

        public void AddCh(int y, int x, uint ch)
        {
            CursesMethods.mvwaddch(this.winptr, y, x, ch);
        }

        public virtual void EchoChar(char ch)
        {
            CursesMethods.wechochar(this.winptr, (byte)ch);
        }

        public virtual void EchoChar(uint ch)
        {
            CursesMethods.wechochar(this.winptr, ch);
        }

        public void AddChStr(uint[] chstr)
        {
            this.AddChStr(chstr, chstr.Length);
        }

        public void AddChStr(uint[] chstr, int n)
        {
            CursesMethods.waddchnstr(this.winptr, chstr, n);
        }

        public void AddChStr(int y, int x, uint[] chstr)
        {
            this.AddChStr(y, x, chstr, chstr.Length);
        }

        public void AddChStr(int y, int x, uint[] chstr, int n)
        {
            CursesMethods.mvwaddchnstr(this.winptr, y, x, chstr, n);
        }

        public void AddStr(string str)
        {
            this.AddStr(str, str.Length);
        }

        public void AddStr(string str, int n)
        {
            if (Curses.UseWideChar)
            {
                CursesMethods.waddnwstr(this.winptr, str, n);
            }
            else
            {
                CursesMethods.waddnstr(this.winptr, str, n);
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
                CursesMethods.mvwaddnwstr(this.winptr, y, x, str, n);
            }
            else
            {
                CursesMethods.mvwaddnstr(this.winptr, y, x, str, n);
            }
        }

        public void AttrOff(uint attr)
        {
            CursesMethods.wattroff(this.winptr, attr);
        }

        public void AttrOn(uint attr)
        {
            CursesMethods.wattron(this.winptr, attr);
        }

        public void AttrSet(uint attr)
        {
            CursesMethods.wattrset(this.winptr, attr);
        }

        public void Standend()
        {
            CursesMethods.wstandend(this.winptr);
        }

        public void Standout()
        {
            CursesMethods.wstandout(this.winptr);
        }

        public void ColorSet(short color_pair)
        {
            CursesMethods.wcolor_set(this.winptr, color_pair);
        }

        public void AttrGet(out uint attrs, out short color_pair)
        {
            CursesMethods.wattr_get(this.winptr, out attrs, out color_pair);
        }

        public void ChgAt(int n, uint attr, short color)
        {
            CursesMethods.wchgat(this.winptr, n, attr, color);
        }

        public void ChgAt(int y, int x, int n, uint attr, short color)
        {
            CursesMethods.mvwchgat(this.winptr, y, x, n, attr, color);
        }

        public uint GetBkgd()
        {
            return CursesMethods.getbkgd(this.winptr);
        }

        public void Bkgd(uint ch)
        {
            CursesMethods.wbkgd(this.winptr, ch);
        }

        public void BkgdSet(uint ch)
        {
            CursesMethods.wbkgdset(this.winptr, ch);
        }

        public void Border(uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            CursesMethods.wborder(this.winptr, ls, rs, ts, bs, tl, tr, bl, br);
        }

        public void Box(uint verch, uint horch)
        {
            CursesMethods.box(this.winptr, verch, horch);
        }

        public void HLine(uint ch, int n)
        {
            CursesMethods.whline(this.winptr, ch, n);
        }

        public void VLine(uint ch, int n)
        {
            CursesMethods.wvline(this.winptr, ch, n);
        }

        public void HLine(int y, int x, uint ch, int n)
        {
            CursesMethods.mvwhline(this.winptr, y, x, ch, n);
        }

        public void VLine(int y, int x, uint ch, int n)
        {
            CursesMethods.mvwvline(this.winptr, y, x, ch, n);
        }

        public void Clear()
        {
            CursesMethods.wclear(this.winptr);
        }

        public void Erase()
        {
            CursesMethods.werase(this.winptr);
        }

        public void ClrToBot()
        {
            CursesMethods.wclrtobot(this.winptr);
        }

        public void ClrToEol()
        {
            CursesMethods.wclrtoeol(this.winptr);
        }

        public void DelCh()
        {
            CursesMethods.wdelch(this.winptr);
        }

        public void DelCh(int y, int x)
        {
            CursesMethods.mvwdelch(this.winptr, y, x);
        }

        public void DeleteLn()
        {
            CursesMethods.wdeleteln(this.winptr);
        }

        public void InsDelLn(int n)
        {
            CursesMethods.winsdelln(this.winptr, n);
        }

        public void InsertLn()
        {
            CursesMethods.winsertln(this.winptr);
        }

        public int GetCh()
        {
            return CursesMethods.wgetch(this.winptr);
        }

        public int GetCh(int y, int x)
        {
            return CursesMethods.mvwgetch(this.winptr, y, x);
        }

        public string GetStr()
        {
            return this.GetStr(DEFAULT_BUFSZ);
        }

        public string GetStr(int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            if (Curses.UseWideChar)
            {
                CursesMethods.wgetn_wstr(this.winptr, sb, n);
            }
            else
            {
                CursesMethods.wgetnstr(this.winptr, sb, n);
            }
            return sb.ToString();
        }

        public string GetStr(int y, int x)
        {
            return this.GetStr(y, x, DEFAULT_BUFSZ);
        }

        public string GetStr(int y, int x, int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            if (Curses.UseWideChar)
            {
                CursesMethods.mvwgetn_wstr(this.winptr, y, x, sb, n);
            }
            else
            {
                CursesMethods.mvwgetnstr(this.winptr, y, x, sb, n);
            }
            return sb.ToString();
        }

        public void GetYX(out int y, out int x)
        {
            CursesMethods.getyx(this.winptr, out y, out x);
        }

        public void GetParYX(out int y, out int x)
        {
            CursesMethods.getparyx(this.winptr, out y, out x);
        }

        public void GetBegYX(out int y, out int x)
        {
            CursesMethods.getbegyx(this.winptr, out y, out x);
        }

        public void GetMaxYX(out int y, out int x)
        {
            CursesMethods.getmaxyx(this.winptr, out y, out x);
        }

        public uint InCh()
        {
            return CursesMethods.winch(this.winptr);
        }

        public uint InCh(int y, int x)
        {
            return CursesMethods.mvwinch(this.winptr, y, x);
        }

        public uint[] InChStr(int n)
        {
            uint[] buf = new uint[n + 1];
            int nOut = CursesMethods.winchnstr(this.winptr, buf, n);
            uint[] ret = new uint[nOut];
            Array.Copy(buf, ret, nOut);
            return ret;
        }

        public uint[] InChStr(int y, int x, int n)
        {
            uint[] buf = new uint[n + 1];
            int nOut = CursesMethods.mvwinchnstr(this.winptr, y, x, buf, n);
            uint[] ret = new uint[nOut];
            Array.Copy(buf, ret, nOut);
            return ret;
        }

        public void InsCh(char ch)
        {
            CursesMethods.winsch(this.winptr, (byte)ch);
        }

        public void InsCh(uint ch)
        {
            CursesMethods.winsch(this.winptr, ch);
        }

        public void InsCh(int y, int x, char ch)
        {
            CursesMethods.mvwinsch(this.winptr, y, x, (byte)ch);
        }

        public void InsCh(int y, int x, uint ch)
        {
            CursesMethods.mvwinsch(this.winptr, y, x, ch);
        }

        public void InsStr(string str)
        {
            this.InsStr(str, str.Length);
        }

        public void InsStr(string str, int n)
        {
            if (Curses.UseWideChar)
            {
                CursesMethods.wins_nwstr(this.winptr, str, n);
            }
            else
            {
                CursesMethods.winsnstr(this.winptr, str, n);
            }
        }

        public void InsStr(int y, int x, string str)
        {
            this.InsStr(y, x, str, str.Length);
        }

        public void InsStr(int y, int x, string str, int n)
        {
            if (Curses.UseWideChar)
            {
                CursesMethods.mvwins_nwstr(this.winptr, y, x, str, n);
            }
            else
            {
                CursesMethods.mvwinsnstr(this.winptr, y, x, str, n);
            }
        }

        public string InStr(int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            int nOut = 0;
            if (Curses.UseWideChar)
            {
                nOut = CursesMethods.winnstr(this.winptr, sb, n);
            }
            else
            {
                nOut = CursesMethods.winnwstr(this.winptr, sb, n);
            }
            return sb.ToString(0, nOut);
        }

        public string InStr(int y, int x, int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            int nOut = 0;
            if (Curses.UseWideChar)
            {
                nOut = CursesMethods.mvwinnstr(this.winptr, y, x, sb, n);
            }
            else
            {
                nOut = CursesMethods.mvwinnwstr(this.winptr, y, x, sb, n);
            }
            return sb.ToString(0, nOut);
        }

        public bool IntrFlush
        {
            set
            {
                CursesMethods.intrflush(this.winptr, value);
            }
        }

        public bool Keypad
        {
            set
            {
                CursesMethods.keypad(this.winptr, value);
            }
        }

        public bool Meta
        {
            set
            {
                CursesMethods.meta(this.winptr, value);
            }
        }

        public bool NoDelay
        {
            set
            {
                CursesMethods.nodelay(this.winptr, value);
            }
        }

        public bool NoTimeout
        {
            set
            {
                CursesMethods.notimeout(this.winptr, value);
            }
        }

        public int Timeout
        {
            set
            {
                CursesMethods.wtimeout(this.winptr, value);
            }
        }

        public void Move(int y, int x)
        {
            CursesMethods.wmove(this.winptr, y, x);
        }

        public bool ClearOk
        {
            set
            {
                CursesMethods.clearok(this.winptr, value);
            }
        }

        public bool IdlOk
        {
            set
            {
                CursesMethods.idlok(this.winptr, value);
            }
        }

        public bool IdcOk
        {
            set
            {
                CursesMethods.idcok(this.winptr, value);
            }
        }

        public bool ImmedOk
        {
            set
            {
                CursesMethods.immedok(this.winptr, value);
            }
        }

        public bool LeaveOk
        {
            set
            {
                CursesMethods.leaveok(this.winptr, value);
            }
        }

        public bool ScrollOk
        {
            set
            {
                CursesMethods.scrollok(this.winptr, value);
            }
        }

        public void SetScrReg(int top, int bot)
        {
            CursesMethods.wsetscrreg(this.winptr, top, bot);
        }

        public void Overlay(WindowBase dstWin)
        {
            CursesMethods.overlay(this.winptr, dstWin.winptr);
        }

        public void Overwrite(WindowBase dstWin)
        {
            CursesMethods.overlay(this.winptr, dstWin.winptr);
        }

        public void CopyWin(WindowBase dstWin, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, bool overlay)
        {
            CursesMethods.copywin(this.winptr, dstWin.winptr, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
        }

        public void RedrawWin()
        {
            CursesMethods.redrawwin(this.winptr);
        }

        public void RedrawLn(int beg_line, int num_lines)
        {
            CursesMethods.wredrawln(this.winptr, beg_line, num_lines);
        }

        public void Scroll()
        {
            CursesMethods.scroll(this.winptr);
        }

        public void Scroll(int n)
        {
            CursesMethods.wscrl(this.winptr, n);
        }

        public void TouchWin()
        {
            CursesMethods.touchwin(this.winptr);
        }

        public void TouchLine(int start, int count)
        {
            CursesMethods.touchline(this.winptr, start, count);
        }

        public void TouchLine(int y, int n, int changed)
        {
            CursesMethods.wtouchln(this.winptr, y, n, changed);
        }

        public void UntouchWin()
        {
            CursesMethods.untouchwin(this.winptr);
        }

        public bool IsLineTouched(int line)
        {
            return CursesMethods.is_linetouched(this.winptr, line);
        }

        public bool IsWinTouched()
        {
            return CursesMethods.is_wintouched(this.winptr);
        }

        public void MvWin(int y, int x)
        {
            CursesMethods.mvwin(this.winptr, y, x);
        }

        public void MvDerWin(int pary, int parx)
        {
            CursesMethods.mvderwin(this.winptr, pary, parx);
        }

        public bool SyncOk
        {
            set
            {
                CursesMethods.syncok(this.winptr, value);
            }
        }

        public void SyncUp()
        {
            CursesMethods.wsyncup(this.winptr);
        }

        public void SyncDown()
        {
            CursesMethods.wsyncdown(this.winptr);
        }

        public void CurSyncUp()
        {
            CursesMethods.wcursyncup(this.winptr);
        }
    }
}
