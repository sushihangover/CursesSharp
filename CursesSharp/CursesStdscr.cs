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

        public static void AddCh(char ch)
        {
            StdScr.AddCh(ch);
        }

        public static void AddCh(uint ch)
        {
            StdScr.AddCh(ch);
        }

        public static void AddCh(int y, int x, char ch)
        {
            StdScr.AddCh(y, x, ch);
        }

        public static void AddCh(int y, int x, uint ch)
        {
            StdScr.AddCh(y, x, ch);
        }

        public static void EchoChar(char ch)
        {
            StdScr.EchoChar(ch);
        }

        public static void EchoChar(uint ch)
        {
            StdScr.EchoChar(ch);
        }

        public static void AddChStr(uint[] chstr)
        {
            StdScr.AddChStr(chstr);
        }

        public static void AddChStr(int y, int x, uint[] chstr)
        {
            StdScr.AddChStr(y, x, chstr);
        }

        public static void AddStr(string str)
        {
            StdScr.AddStr(str);
        }

        public static void AddStr(int y, int x, string str)
        {
            StdScr.AddStr(y, x, str);
        }

        public static void AttrOff(uint attr)
        {
            StdScr.AttrOff(attr);
        }

        public static void AttrOn(uint attr)
        {
            StdScr.AttrOn(attr);
        }

        public static void AttrSet(uint attr)
        {
            StdScr.AttrSet(attr);
        }

        public static void Standend()
        {
            StdScr.Standend();
        }

        public static void Standout()
        {
            StdScr.Standout();
        }

        public static void ColorSet(short color_pair)
        {
            StdScr.ColorSet(color_pair);
        }

        public static void AttrGet(out uint attrs, out short color_pair)
        {
            StdScr.AttrGet(out attrs, out color_pair);
        }

        public static void ChgAt(int n, uint attr, short color)
        {
            StdScr.ChgAt(n, attr, color);
        }

        public static void ChgAt(int y, int x, int n, uint attr, short color)
        {
            StdScr.ChgAt(y, x, n, attr, color);
        }

        public static uint GetBkgd()
        {
            return StdScr.GetBkgd();
        }

        public static void Bkgd(uint ch)
        {
            StdScr.Bkgd(ch);
        }

        public static void BkgdSet(uint ch)
        {
            StdScr.BkgdSet(ch);
        }

        public static void Border(uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            StdScr.Border(ls, rs, ts, bs, tl, tr, bl, br);
        }

        public static void Box(uint verch, uint horch)
        {
            StdScr.Box(verch, horch);
        }

        public static void HLine(uint ch, int n)
        {
            StdScr.HLine(ch, n);
        }

        public static void VLine(uint ch, int n)
        {
            StdScr.VLine(ch, n);
        }

        public static void HLine(int y, int x, uint ch, int n)
        {
            StdScr.HLine(y, x, ch, n);
        }

        public static void VLine(int y, int x, uint ch, int n)
        {
            StdScr.VLine(y, x, ch, n);
        }

        public static void Clear()
        {
            StdScr.Clear();
        }

        public static void Erase()
        {
            StdScr.Erase();
        }

        public static void ClrToBot()
        {
            StdScr.ClrToBot();
        }

        public static void ClrToEol()
        {
            StdScr.ClrToEol();
        }

        public static void DelCh()
        {
            StdScr.DelCh();
        }

        public static void DelCh(int y, int x)
        {
            StdScr.DelCh(y, x);
        }

        public static void DeleteLn()
        {
            StdScr.DeleteLn();
        }

        public static void InsDelLn(int n)
        {
            StdScr.InsDelLn(n);
        }

        public static void InsertLn()
        {
            StdScr.InsertLn();
        }

        public static int GetCh()
        {
            return StdScr.GetCh();
        }

        public static int GetCh(int y, int x)
        {
            return StdScr.GetCh(y, x);
        }

        public static string GetStr()
        {
            return StdScr.GetStr();
        }

        public static string GetStr(int n)
        {
            return StdScr.GetStr(n);
        }

        public static string GetStr(int y, int x)
        {
            return StdScr.GetStr(y, x);
        }

        public static string GetStr(int y, int x, int n)
        {
            return StdScr.GetStr(y, x, n);
        }

        public static void InsCh(char ch)
        {
            StdScr.InsCh(ch);
        }

        public static void InsCh(uint ch)
        {
            StdScr.InsCh(ch);
        }

        public static void InsCh(int y, int x, char ch)
        {
            StdScr.InsCh(y, x, ch);
        }

        public static void InsCh(int y, int x, uint ch)
        {
            StdScr.InsCh(y, x, ch);
        }

        public static void InsStr(string str)
        {
            StdScr.InsStr(str);
        }

        public static void InsStr(string str, int n)
        {
            StdScr.InsStr(str, n);
        }

        public static void InsStr(int y, int x, string str)
        {
            StdScr.InsStr(y, x, str);
        }

        public static void InsStr(int y, int x, string str, int n)
        {
            StdScr.InsStr(y, x, str, n);
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

        public static void Move(int y, int x)
        {
            StdScr.Move(y, x);
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

        public static void SetScrReg(int top, int bot)
        {
            StdScr.SetScrReg(top, bot);
        }

        public static void Refresh()
        {
            StdScr.Refresh();
        }

        public static void Scroll(int n)
        {
            StdScr.Scroll(n);
        }

        public static void TouchWin()
        {
            StdScr.TouchWin();
        }

        public static void TouchLine(int start, int count)
        {
            StdScr.TouchLine(start, count);
        }

        public static void UntouchWin()
        {
            StdScr.UntouchWin();
        }

        #endregion
    }
}
