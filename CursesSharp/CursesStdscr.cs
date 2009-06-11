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
    public static partial class Curses
    {
        #region Shortcuts to stdscr

        public static int AddCh(char ch)
        {
            return StdScr.AddCh(ch);
        }

        public static int AddCh(uint ch)
        {
            return StdScr.AddCh(ch);
        }

        public static int MvAddCh(int y, int x, char ch)
        {
            return StdScr.MvAddCh(y, x, ch);
        }

        public static int MvAddCh(int y, int x, uint ch)
        {
            return StdScr.MvAddCh(y, x, ch);
        }

        public static int EchoChar(char ch)
        {
            return StdScr.EchoChar(ch);
        }

        public static int EchoChar(uint ch)
        {
            return StdScr.EchoChar(ch);
        }

        public static int AddChStr(uint[] chstr)
        {
            return StdScr.AddChStr(chstr);
        }

        public static int MvAddChStr(int y, int x, uint[] chstr)
        {
            return StdScr.MvAddChStr(y, x, chstr);
        }

        public static int AddStr(string str)
        {
            return StdScr.AddStr(str);
        }

        public static int MvAddStr(int y, int x, string str)
        {
            return StdScr.MvAddStr(y, x, str);
        }

        public static int AttrOff(uint attr)
        {
            return StdScr.AttrOff(attr);
        }

        public static int AttrOn(uint attr)
        {
            return StdScr.AttrOn(attr);
        }

        public static int AttrSet(uint attr)
        {
            return StdScr.AttrSet(attr);
        }

        public static int Standend()
        {
            return StdScr.Standend();
        }

        public static int Standout()
        {
            return StdScr.Standout();
        }

        public static int ColorSet(short color_pair)
        {
            return StdScr.ColorSet(color_pair);
        }

        public static int AttrGet(out uint attrs, out short color_pair)
        {
            return StdScr.AttrGet(out attrs, out color_pair);
        }

        public static int ChgAt(int n, uint attr, short color)
        {
            return StdScr.ChgAt(n, attr, color);
        }

        public static int MvChgAt(int y, int x, int n, uint attr, short color)
        {
            return StdScr.MvChgAt(y, x, n, attr, color);
        }

        public static uint GetBkgd()
        {
            return StdScr.GetBkgd();
        }

        public static int Bkgd(uint ch)
        {
            return StdScr.Bkgd(ch);
        }

        public static void BkgdSet(uint ch)
        {
            StdScr.BkgdSet(ch);
        }

        public static int Border(uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            return StdScr.Border(ls, rs, ts, bs, tl, tr, bl, br);
        }

        public static int Box(uint verch, uint horch)
        {
            return StdScr.Box(verch, horch);
        }

        public static int HLine(uint ch, int n)
        {
            return StdScr.HLine(ch, n);
        }

        public static int VLine(uint ch, int n)
        {
            return StdScr.VLine(ch, n);
        }

        public static int MvHLine(int y, int x, uint ch, int n)
        {
            return StdScr.MvHLine(y, x, ch, n);
        }

        public static int MvVLine(int y, int x, uint ch, int n)
        {
            return StdScr.MvVLine(y, x, ch, n);
        }

        public static int Clear()
        {
            return StdScr.Clear();
        }

        public static int Erase()
        {
            return StdScr.Erase();
        }

        public static int ClrToBot()
        {
            return StdScr.ClrToBot();
        }

        public static int ClrToEol()
        {
            return StdScr.ClrToEol();
        }

        public static int GetCh()
        {
            return StdScr.GetCh();
        }

        public static int MvGetCh(int y, int x)
        {
            return StdScr.MvGetCh(y, x);
        }

        public static bool IntrFlush
        {
            set { StdScr.IntrFlush = value; }
        }

        public static bool Keypad
        {
            set { StdScr.Keypad = value; }
        }

        public static bool Meta
        {
            set { StdScr.Meta = value; }
        }

        public static bool NoDelay
        {
            set { StdScr.NoDelay = value; }
        }

        public static bool NoTimeout
        {
            set { StdScr.NoTimeout = value; }
        }

        public static int Timeout
        {
            set { StdScr.Timeout = value; }
        }

        public static int Move(int y, int x)
        {
            return StdScr.Move(y, x);
        }

        public static bool ClearOk
        {
            set { StdScr.ClearOk = value; }
        }

        public static bool IdlOk
        {
            set { StdScr.IdlOk = value; }
        }

        public static bool IdcOk
        {
            set { StdScr.IdcOk = value; }
        }

        public static bool ImmedOk
        {
            set { StdScr.ImmedOk = value; }
        }

        public static bool LeaveOk
        {
            set { StdScr.LeaveOk = value; }
        }

        public static bool ScrollOk
        {
            set { StdScr.ScrollOk = value; }
        }

        public static int SetScrReg(int top, int bot)
        {
            return StdScr.SetScrReg(top, bot);
        }

        public static int Refresh()
        {
            return StdScr.Refresh();
        }

        public static int TouchWin()
        {
            return StdScr.TouchWin();
        }

        public static int TouchLine(int start, int count)
        {
            return StdScr.TouchLine(start, count);
        }

        public static int UntouchWin()
        {
            return StdScr.UntouchWin();
        }

        #endregion
    }
}
