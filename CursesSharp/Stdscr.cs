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
        public static uint Attr
        {
            get { return Curses.StdScr.Attr; }
            set { Curses.StdScr.Attr = value; }
        }

        public static short Color
        {
            get { return Curses.StdScr.Color; }
            set { Curses.StdScr.Color = value; }
        }

        public static uint Background
        {
            get { return Curses.StdScr.Background; }
            set { Curses.StdScr.Background = value; }
        }

        public static bool FlushOnInterrupt
        {
            set { Curses.StdScr.FlushOnInterrupt = value; }
        }

        public static bool Keypad
        {
            set { Curses.StdScr.Keypad = value; }
        }

        public static bool Meta
        {
            set { Curses.StdScr.Meta = value; }
        }

        public static bool Blocking
        {
            set { Curses.StdScr.Blocking = value; }
        }

        public static int ReadTimeout
        {
            set { Curses.StdScr.ReadTimeout = value; }
        }

        public static bool DelayEscape
        {
            set { Curses.StdScr.DelayEscape = value; }
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

        public static void Add(char ch)
        {
            Curses.StdScr.Add(ch);
        }

        public static void Add(uint ch)
        {
            Curses.StdScr.Add(ch);
        }

        public static void Add(int y, int x, char ch)
        {
            Curses.StdScr.Add(y, x, ch);
        }

        public static void Add(int y, int x, uint ch)
        {
            Curses.StdScr.Add(y, x, ch);
        }

        public static void Add(uint[] chstr)
        {
            Curses.StdScr.Add(chstr);
        }

        public static void Add(int y, int x, uint[] chstr)
        {
            Curses.StdScr.Add(y, x, chstr);
        }

        public static void Add(string str)
        {
            Curses.StdScr.Add(str);
        }

        public static void Add(int y, int x, string str)
        {
            Curses.StdScr.Add(y, x, str);
        }

        public static void EchoChar(char ch)
        {
            Curses.StdScr.EchoChar(ch);
        }

        public static void EchoChar(uint ch)
        {
            Curses.StdScr.EchoChar(ch);
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

        public static void ChangeAttr(int n, uint attr, short color)
        {
            Curses.StdScr.ChangeAttr(n, attr, color);
        }

        public static void ChangeAttr(int y, int x, int n, uint attr, short color)
        {
            Curses.StdScr.ChangeAttr(y, x, n, attr, color);
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

        public static void Delete()
        {
            Curses.StdScr.Delete();
        }

        public static void Delete(int y, int x)
        {
            Curses.StdScr.Delete(y, x);
        }

        public static void DeleteLine()
        {
            Curses.StdScr.DeleteLine();
        }

        public static void InsDelLine(int n)
        {
            Curses.StdScr.InsDelLine(n);
        }

        public static void InsertLine()
        {
            Curses.StdScr.InsertLine();
        }

        public static int GetChar()
        {
            return Curses.StdScr.GetChar();
        }

        public static int GetChar(int y, int x)
        {
            return Curses.StdScr.GetChar(y, x);
        }

        public static string GetString()
        {
            return Curses.StdScr.GetString();
        }

        public static string GetString(int n)
        {
            return Curses.StdScr.GetString(n);
        }

        public static string GetString(int y, int x)
        {
            return Curses.StdScr.GetString(y, x);
        }

        public static string GetString(int y, int x, int n)
        {
            return Curses.StdScr.GetString(y, x, n);
        }

        public static void Insert(char ch)
        {
            Curses.StdScr.Insert(ch);
        }

        public static void Insert(uint ch)
        {
            Curses.StdScr.Insert(ch);
        }

        public static void Insert(int y, int x, char ch)
        {
            Curses.StdScr.Insert(y, x, ch);
        }

        public static void Insert(int y, int x, uint ch)
        {
            Curses.StdScr.Insert(y, x, ch);
        }

        public static void Insert(string str)
        {
            Curses.StdScr.Insert(str);
        }

        public static void Insert(string str, int n)
        {
            Curses.StdScr.Insert(str, n);
        }

        public static void Insert(int y, int x, string str)
        {
            Curses.StdScr.Insert(y, x, str);
        }

        public static void Insert(int y, int x, string str, int n)
        {
            Curses.StdScr.Insert(y, x, str, n);
        }

#if HAVE_CURSES_MOUSE
        public static bool MouseTrafo(ref int y, ref int x, bool to_screen)
        {
            return Curses.StdScr.MouseTrafo(ref y, ref x, to_screen);
        }
#endif

        public static void Move(int y, int x)
        {
            Curses.StdScr.Move(y, x);
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
