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
    public class Stdscr
    {
        public static void AddCh(char ch)
        {
            Curses.StdScr.AddCh(ch);
        }

        public static void AddCh(uint ch)
        {
            Curses.StdScr.AddCh(ch);
        }

        public static void AddCh(int y, int x, char ch)
        {
            Curses.StdScr.AddCh(y, x, ch);
        }

        public static void AddCh(int y, int x, uint ch)
        {
            Curses.StdScr.AddCh(y, x, ch);
        }

        public static void EchoChar(char ch)
        {
            Curses.StdScr.EchoChar(ch);
        }

        public static void EchoChar(uint ch)
        {
            Curses.StdScr.EchoChar(ch);
        }

        public static void AddChStr(uint[] chstr)
        {
            Curses.StdScr.AddChStr(chstr);
        }

        public static void AddChStr(int y, int x, uint[] chstr)
        {
            Curses.StdScr.AddChStr(y, x, chstr);
        }

        public static void AddStr(string str)
        {
            Curses.StdScr.AddStr(str);
        }

        public static void AddStr(int y, int x, string str)
        {
            Curses.StdScr.AddStr(y, x, str);
        }

        public static uint Attr
        {
            get { return Curses.StdScr.Attr; }
            set { Curses.StdScr.Attr = value; }
        }

        public static void AttrOff(uint attr)
        {
            Curses.StdScr.AttrOff(attr);
        }

        public static void AttrOn(uint attr)
        {
            Curses.StdScr.AttrOn(attr);
        }

        public static void Standend()
        {
            Curses.StdScr.Standend();
        }

        public static void Standout()
        {
            Curses.StdScr.Standout();
        }

        public static short Color
        {
            get { return Curses.StdScr.Color; }
            set { Curses.StdScr.Color = value; }
        }

        public static void ChangeAttr(int n, uint attr, short color)
        {
            Curses.StdScr.ChangeAttr(n, attr, color);
        }

        public static void ChangeAttr(int y, int x, int n, uint attr, short color)
        {
            Curses.StdScr.ChangeAttr(y, x, n, attr, color);
        }

        public static uint Background
        {
            get { return Curses.StdScr.Background; }
            set { Curses.StdScr.Background = value; }
        }

        public static void FillBackground(uint ch)
        {
            Curses.StdScr.FillBackground(ch);
        }

        public static void Border(uint ls, uint rs, uint ts, uint bs, uint tl, uint tr, uint bl, uint br)
        {
            Curses.StdScr.Border(ls, rs, ts, bs, tl, tr, bl, br);
        }

        public static void Box(uint verch, uint horch)
        {
            Curses.StdScr.Box(verch, horch);
        }

        public static void HLine(uint ch, int n)
        {
            Curses.StdScr.HLine(ch, n);
        }

        public static void VLine(uint ch, int n)
        {
            Curses.StdScr.VLine(ch, n);
        }

        public static void HLine(int y, int x, uint ch, int n)
        {
            Curses.StdScr.HLine(y, x, ch, n);
        }

        public static void VLine(int y, int x, uint ch, int n)
        {
            Curses.StdScr.VLine(y, x, ch, n);
        }

        public static void Clear()
        {
            Curses.StdScr.Clear();
        }

        public static void ClearToBottom()
        {
            Curses.StdScr.ClearToBottom();
        }

        public static void ClearToEol()
        {
            Curses.StdScr.ClearToEol();
        }

        public static void Erase()
        {
            Curses.StdScr.Erase();
        }

        public static void DelCh()
        {
            Curses.StdScr.DelCh();
        }

        public static void DelCh(int y, int x)
        {
            Curses.StdScr.DelCh(y, x);
        }

        public static void DeleteLn()
        {
            Curses.StdScr.DeleteLn();
        }

        public static void InsDelLn(int n)
        {
            Curses.StdScr.InsDelLn(n);
        }

        public static void InsertLn()
        {
            Curses.StdScr.InsertLn();
        }

        public static int GetCh()
        {
            return Curses.StdScr.GetCh();
        }

        public static int GetCh(int y, int x)
        {
            return Curses.StdScr.GetCh(y, x);
        }

        public static string GetStr()
        {
            return Curses.StdScr.GetStr();
        }

        public static string GetStr(int n)
        {
            return Curses.StdScr.GetStr(n);
        }

        public static string GetStr(int y, int x)
        {
            return Curses.StdScr.GetStr(y, x);
        }

        public static string GetStr(int y, int x, int n)
        {
            return Curses.StdScr.GetStr(y, x, n);
        }

        public static void InsCh(char ch)
        {
            Curses.StdScr.InsCh(ch);
        }

        public static void InsCh(uint ch)
        {
            Curses.StdScr.InsCh(ch);
        }

        public static void InsCh(int y, int x, char ch)
        {
            Curses.StdScr.InsCh(y, x, ch);
        }

        public static void InsCh(int y, int x, uint ch)
        {
            Curses.StdScr.InsCh(y, x, ch);
        }

        public static void InsStr(string str)
        {
            Curses.StdScr.InsStr(str);
        }

        public static void InsStr(string str, int n)
        {
            Curses.StdScr.InsStr(str, n);
        }

        public static void InsStr(int y, int x, string str)
        {
            Curses.StdScr.InsStr(y, x, str);
        }

        public static void InsStr(int y, int x, string str, int n)
        {
            Curses.StdScr.InsStr(y, x, str, n);
        }

        public static bool FlushOnInterrupt
        {
            set { Curses.StdScr.FlushOnInterrupt = value; }
        }

        public static bool UseKeypad
        {
            set { Curses.StdScr.UseKeypad = value; }
        }

        public static bool UseMeta
        {
            set { Curses.StdScr.UseMeta = value; }
        }

        public static bool IsBlocking
        {
            set { Curses.StdScr.IsBlocking = value; }
        }

        public static int BlockTimeout
        {
            set { Curses.StdScr.BlockTimeout = value; }
        }

        public static bool WaitOnEscape
        {
            set { Curses.StdScr.WaitOnEscape = value; }
        }

#if NCURSES_MOUSE_VERSION
        public static bool MouseTrafo(ref int y, ref int x, bool to_screen)
        {
            return Curses.StdScr.MouseTrafo(ref y, ref x, to_screen);
        }
#endif

        public static void Move(int y, int x)
        {
            Curses.StdScr.Move(y, x);
        }

        public static bool ClearOnRefresh
        {
            set { Curses.StdScr.ClearOnRefresh = value; }
        }

        public static bool UseHwInsDelLine
        {
            set { Curses.StdScr.UseHwInsDelLine = value; }
        }

        public static bool UseHwInsDelChar
        {
            set { Curses.StdScr.UseHwInsDelChar = value; }
        }

        public static bool ImmediateRefresh
        {
            set { Curses.StdScr.ImmediateRefresh = value; }
        }

        public static bool CanLeaveCursor
        {
            set { Curses.StdScr.CanLeaveCursor = value; }
        }

        public static bool EnableScroll
        {
            set { Curses.StdScr.EnableScroll = value; }
        }

        public static void SetScrollRegion(int top, int bot)
        {
            Curses.StdScr.SetScrollRegion(top, bot);
        }

        public static void Refresh()
        {
            Curses.StdScr.Refresh();
        }

        public static void Scroll(int n)
        {
            Curses.StdScr.Scroll(n);
        }

        public static void Touch()
        {
            Curses.StdScr.Touch();
        }

        public static void Touch(int start, int count)
        {
            Curses.StdScr.Touch(start, count);
        }

        public static void Untouch()
        {
            Curses.StdScr.Untouch();
        }
    }
}
