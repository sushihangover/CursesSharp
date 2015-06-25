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
using System.Diagnostics;
using System.Text;
using CursesSharp.Internal;

namespace CursesSharp
{
    /// <summary>
    /// Represents the greatest common factor between windows and pads.
    /// </summary>
    public abstract class WindowBase: IDisposable
    {
        internal const int DEFAULT_BUFSZ = 1023;

        private IntPtr winptr;
        private bool ownsPtr;

        protected internal WindowBase()
        {
            this.winptr = IntPtr.Zero;
            this.ownsPtr = false;
        }

        protected internal WindowBase(IntPtr winptr, bool ownsPtr)
        {
            this.winptr = winptr;
            this.ownsPtr = ownsPtr;
        }

        protected internal IntPtr Handle
        {
            get { return this.winptr; }
            set 
            {
                Debug.Assert(this.winptr == IntPtr.Zero);
                this.winptr = value;
                this.ownsPtr = true;
            }
        }

		public IntPtr PublicHandle
		{
			get { return this.winptr; }
		}

        #region IDisposable Members

        /// <summary>
        /// Destroys the window and releases resources used by the
        /// <see cref="WindowBase"/> object.
        /// </summary>
        public void Dispose()
        {
            this.DisposeImpl();
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// Disposes the window during finalization, if it hasn't been 
        /// disposed earlier.
        /// </summary>
        /// <remarks>
        /// A correct program should dispose all resources
        /// before they are garbage collected, so this method being executed
        /// is considered a bug. For this reason the destructor causes
        /// an assertion failure in debug mode.
        /// </remarks>
        ~WindowBase()
        {
#if DEBUG
            Debug.Assert(this.winptr == IntPtr.Zero, "Window not disposed");
#endif
            this.DisposeImpl();
        }

        private void DisposeImpl()
        {
            if (this.winptr != IntPtr.Zero && this.ownsPtr)
            {
                CursesMethods.delwin(this.winptr);
                this.winptr = IntPtr.Zero;
            }
        }

        #region Text attributes

        public uint Attr
        {
            get
            {
                uint attrs;
                short color_pair;
                CursesMethods.wattr_get(this.winptr, out attrs, out color_pair);
                return attrs;
            }
            set
            {
                CursesMethods.wattrset(this.winptr, value);
            }
        }

        public short Color
        {
            get
            {
                uint attrs;
                short color_pair;
                CursesMethods.wattr_get(this.winptr, out attrs, out color_pair);
                return color_pair;
            }
            set
            {
                CursesMethods.wcolor_set(this.winptr, value);
            }
        }

        public uint Background
        {
            get { return CursesMethods.getbkgd(this.winptr); }
            set { CursesMethods.wbkgd(this.winptr, value); }
        }

        #endregion

        #region Input options

        public bool FlushOnInterrupt
        {
            set
            {
                CursesMethods.intrflush(this.winptr, value);
            }
        }

        /// <summary>
        /// Represents the state of user's terminal keypad. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// If enabled (set to true), the user can press a function key
        /// (such as an arrow key) and <see cref="GetChar()"/> returns a single 
        /// value representing the function key, as in <see cref="Keys.LEFT"/>. 
        /// </para>
        /// <para>
        /// If disabled (set to false), curses does not treat function keys
        /// specially and the program has to interpret escape sequences
        /// itself.
        /// </para>
        /// <para>
        /// If the keypad in the terminal can be turned on (made do transmit)
        /// and off (made to work locally), turning on this option causes
        /// keypad to be turned on when <see cref="GetChar()"/> in called.
        /// </para>
        /// <para>
        /// The default value for this option is false.
        /// </para>
        /// </remarks>
        public bool Keypad
        {
            set
            {
                CursesMethods.keypad(this.winptr, value);
            }
        }

        /// <summary>
        /// Represents the status of returning extended key information
        /// by the terminal input.
        /// </summary>
        /// <remarks>
        /// Initially, whether the terminal returns 7 or 8 significant
        /// bits on input depends on the control mode of the tty driver.
        /// <para>
        /// To force 8 bits to be returned, set this property to true; this is
        /// equivalent, under POSIX, to setting the CS8 flag on the terminal.
        /// </para>
        /// <para>
        /// To force 7 bits to be returned, set this property to false; this is
        /// equivalent, under POSIX, to setting the CS7 flag on the terminal.
        /// </para>
        /// <para>
        /// If the terminfo capabilities smm (meta_on) and rmm (meta_off)
        /// are defined for the terminal, smm is sent to the terminal when
        /// this property is set to true and rmm is sent when this property
        /// is set to false.
        /// </para>
        /// </remarks>
        public bool Meta
        {
            set
            {
                CursesMethods.meta(this.winptr, value);
            }
        }

        /// <summary>
        /// Represents the status of blocking program execution by the method
        /// <see cref="GetChar()"/>.
        /// </summary>
        /// <remarks>
        /// Setting this property to true causes <see cref="GetChar()"/> to be
        /// a non-blocking call. If no input is ready, <see cref="GetChar()"/>
        /// returns -1.
        /// <para>
        /// If this property is set to false, <see cref="GetChar()"/> waits
        /// until a key is pressed.
        /// </para>
        /// </remarks>
        public bool Blocking
        {
            set
            {
                CursesMethods.nodelay(this.winptr, !value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ReadTimeout
        {
            set
            {
                CursesMethods.wtimeout(this.winptr, value);
            }
        }

        public bool DelayEscape
        {
            set
            {
                CursesMethods.notimeout(this.winptr, !value);
            }
        }

        #endregion

        #region Output options

        public bool ClearOnRefresh
        {
            set
            {
                CursesMethods.clearok(this.winptr, value);
            }
        }

        public bool UseHwInsDelLine
        {
            set
            {
                CursesMethods.idlok(this.winptr, value);
            }
        }

        public bool UseHwInsDelChar
        {
            set
            {
                CursesMethods.idcok(this.winptr, value);
            }
        }

        public bool ImmediateRefresh
        {
            set
            {
                CursesMethods.immedok(this.winptr, value);
            }
        }

        public bool CanLeaveCursor
        {
            set
            {
                CursesMethods.leaveok(this.winptr, value);
            }
        }

        public bool EnableScroll
        {
            set
            {
                CursesMethods.scrollok(this.winptr, value);
            }
        }

        public bool ImmediateSyncUp
        {
            set
            {
                CursesMethods.syncok(this.winptr, value);
            }
        }

        #endregion

        public void Add(char ch)
        {
            CursesMethods.waddch(this.winptr, (byte)ch);
        }

        public void Add(uint ch)
        {
            CursesMethods.waddch(this.winptr, ch);
        }

        public void Add(int y, int x, char ch)
        {
            CursesMethods.mvwaddch(this.winptr, y, x, (byte)ch);
        }

        public void Add(int y, int x, uint ch)
        {
            CursesMethods.mvwaddch(this.winptr, y, x, ch);
        }

        public void Add(uint[] chstr)
        {
            this.Add(chstr, chstr.Length);
        }

        public void Add(uint[] chstr, int n)
        {
            CursesMethods.waddchnstr(this.winptr, chstr, n);
        }

        public void Add(int y, int x, uint[] chstr)
        {
            this.Add(y, x, chstr, chstr.Length);
        }

        public void Add(int y, int x, uint[] chstr, int n)
        {
            CursesMethods.mvwaddchnstr(this.winptr, y, x, chstr, n);
        }

        public void Add(string str)
        {
            this.Add(str, str.Length);
        }

        public void Add(string str, int n)
        {

			CursesMethods.waddnstr(this.winptr, str, n);
        }

        public void Add(int y, int x, string str)
        {
            this.Add(y, x, str, str.Length);
        }

        public void Add(int y, int x, string str, int n)
        {
            CursesMethods.mvwaddnstr(this.winptr, y, x, str, n);
        }

        public virtual void EchoChar(char ch)
        {
            CursesMethods.wechochar(this.winptr, (byte)ch);
        }

        public virtual void EchoChar(uint ch)
        {
            CursesMethods.wechochar(this.winptr, ch);
        }

        public void Insert(char ch)
        {
            CursesMethods.winsch(this.winptr, (byte)ch);
        }

        public void Insert(uint ch)
        {
            CursesMethods.winsch(this.winptr, ch);
        }

        public void Insert(int y, int x, char ch)
        {
            CursesMethods.mvwinsch(this.winptr, y, x, (byte)ch);
        }

        public void Insert(int y, int x, uint ch)
        {
            CursesMethods.mvwinsch(this.winptr, y, x, ch);
        }

        public void Insert(string str)
        {
            this.Insert(str, str.Length);
        }

        public void Insert(string str, int n)
        {
            CursesMethods.winsnstr(this.winptr, str, n);
        }

        public void Insert(int y, int x, string str)
        {
            this.Insert(y, x, str, str.Length);
        }

        public void Insert(int y, int x, string str, int n)
        {
            CursesMethods.mvwinsnstr(this.winptr, y, x, str, n);
        }

        public void AttrOff(uint attr)
        {
            CursesMethods.wattroff(this.winptr, attr);
        }

        public void AttrOn(uint attr)
        {
            CursesMethods.wattron(this.winptr, attr);
        }

        public void Standend()
        {
            CursesMethods.wstandend(this.winptr);
        }

        public void Standout()
        {
            CursesMethods.wstandout(this.winptr);
        }

        public void ChangeAttr(int n, uint attr, short color)
        {
            CursesMethods.wchgat(this.winptr, n, attr, color);
        }

        public void ChangeAttr(int y, int x, int n, uint attr, short color)
        {
            CursesMethods.mvwchgat(this.winptr, y, x, n, attr, color);
        }

        public void FillBackground(uint ch)
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

        public uint ReadOutputChar()
        {
            return CursesMethods.winch(this.winptr);
        }

        public uint ReadOutputChar(int y, int x)
        {
            return CursesMethods.mvwinch(this.winptr, y, x);
        }

        public uint[] ReadOutputChars(int n)
        {
            uint[] buf = new uint[n + 1];
            int nOut = CursesMethods.winchnstr(this.winptr, buf, n);
            uint[] ret = new uint[nOut];
            Array.Copy(buf, ret, nOut);
            return ret;
        }

        public uint[] ReadOutputChars(int y, int x, int n)
        {
            uint[] buf = new uint[n + 1];
            int nOut = CursesMethods.mvwinchnstr(this.winptr, y, x, buf, n);
            uint[] ret = new uint[nOut];
            Array.Copy(buf, ret, nOut);
            return ret;
        }

        public string ReadOutputString(int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            int nOut = CursesMethods.winnstr(this.winptr, sb, n);
            return sb.ToString(0, nOut);
        }

        public string ReadOutputString(int y, int x, int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            int nOut = CursesMethods.mvwinnstr(this.winptr, y, x, sb, n);
            return sb.ToString(0, nOut);
        }

        public void Scroll()
        {
            CursesMethods.scroll(this.winptr);
        }

        public void Scroll(int n)
        {
            CursesMethods.wscrl(this.winptr, n);
        }

        public void SetScrollRegion(int top, int bot)
        {
            CursesMethods.wsetscrreg(this.winptr, top, bot);
        }

        public void Clear()
        {
            CursesMethods.wclear(this.winptr);
        }

        public int GetChar()
        {
            return CursesMethods.wgetch(this.winptr);
        }

        public int GetChar(int y, int x)
        {
            return CursesMethods.mvwgetch(this.winptr, y, x);
        }

        public string GetString()
        {
            return this.GetString(DEFAULT_BUFSZ);
        }

        public string GetString(int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            CursesMethods.wgetnstr(this.winptr, sb, n);
            return sb.ToString();
        }

        public string GetString(int y, int x)
        {
            return this.GetString(y, x, DEFAULT_BUFSZ);
        }

        public string GetString(int y, int x, int n)
        {
            StringBuilder sb = new StringBuilder(n + 1);
            CursesMethods.mvwgetnstr(this.winptr, y, x, sb, n);
            return sb.ToString();
        }

        public void Move(int y, int x)
        {
            CursesMethods.wmove(this.winptr, y, x);
        }

        public void GetCursorYX(out int y, out int x)
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


#if HAVE_CURSES_MOUSE
        public bool Enclose(int y, int x)
        {
            return CursesMethods.wenclose(this.winptr, y, x);
        }

        public bool MouseTrafo(ref int y, ref int x, bool to_screen)
        {
            return CursesMethods.wmouse_trafo(this.winptr, ref y, ref x, to_screen);
        }
#endif

        public void Overlay(WindowBase dstWin)
        {
            CursesMethods.overlay(this.winptr, dstWin.winptr);
        }

        public void Overwrite(WindowBase dstWin)
        {
            CursesMethods.overlay(this.winptr, dstWin.winptr);
        }

        public void Copy(WindowBase dstWin, int src_tr, int src_tc, int dst_tr, int dst_tc, int dst_br, int dst_bc, bool overlay)
        {
            CursesMethods.copywin(this.winptr, dstWin.winptr, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
        }

        public void ClearToBottom()
        {
            CursesMethods.wclrtobot(this.winptr);
        }

        public void ClearToEol()
        {
            CursesMethods.wclrtoeol(this.winptr);
        }

        public void Erase()
        {
            CursesMethods.werase(this.winptr);
        }

        public void Delete()
        {
            CursesMethods.wdelch(this.winptr);
        }

        public void Delete(int y, int x)
        {
            CursesMethods.mvwdelch(this.winptr, y, x);
        }

        public void DeleteLine()
        {
            CursesMethods.wdeleteln(this.winptr);
        }

        public void InsDelLine(int n)
        {
            CursesMethods.winsdelln(this.winptr, n);
        }

        public void InsertLine()
        {
            CursesMethods.winsertln(this.winptr);
        }

        public void Redraw()
        {
            CursesMethods.redrawwin(this.winptr);
        }

        public void Redraw(int beg_line, int num_lines)
        {
            CursesMethods.wredrawln(this.winptr, beg_line, num_lines);
        }

        public void Touch()
        {
            CursesMethods.touchwin(this.winptr);
        }

        public void Touch(int start, int count)
        {
            CursesMethods.touchline(this.winptr, start, count);
        }

        public void Touch(int y, int n, int changed)
        {
            CursesMethods.wtouchln(this.winptr, y, n, changed);
        }

        public void Untouch()
        {
            CursesMethods.untouchwin(this.winptr);
        }

        public bool IsTouched(int line)
        {
            return CursesMethods.is_linetouched(this.winptr, line);
        }

        public bool IsTouched()
        {
            return CursesMethods.is_wintouched(this.winptr);
        }

        public void MoveWindowScreen(int y, int x)
        {
            CursesMethods.mvwin(this.winptr, y, x);
        }

        public void MoveWindowParent(int pary, int parx)
        {
            CursesMethods.mvderwin(this.winptr, pary, parx);
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
