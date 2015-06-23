//
// handles.cs: OO wrappers for some curses objects
//
// Authors:
//   Miguel de Icaza (miguel.de.icaza@gmail.com)
//
// Copyright (C) 2007 Novell (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using CursesSharp;

namespace CursesSharp.Gui {

	public class MainScreen {
		public readonly IntPtr Handle;
		readonly static Window mainScreen;
		public readonly static Window curscr;
		public readonly static Window stdscr;

		static MainScreen ()
		{
//			mainScreen = Curses.InitScr ();
//			curscr = Window.CurrentScreen ();
//			stdscr = Window.StandardScreen ();
		}
		
		internal MainScreen (IntPtr handle) 
		{
			Handle = handle;
		}
				
//		static public MainScreen Standard {
//			get {
//				return stdscr;
//			}
//		}
//
//		static public MainScreen Current {
//			get {
//				return curscr;
//			}
//		}
//

		public void wtimeout (int delay)
		{
			mainScreen.ReadTimeout = delay;
		}

		public void notimeout (bool bf)
		{
			mainScreen.DelayEscape = bf; 
		}

		public void keypad (bool bf)
		{
			mainScreen.Keypad =  bf;
		}

		public void meta (bool bf)
		{
			mainScreen.Meta = bf;
		}

		public void intrflush (bool bf)
		{
			mainScreen.FlushOnInterrupt = bf;
		}

		public void clearok (bool bf)
		{
			mainScreen.ClearOnRefresh = bf;
		}
		
		public void idlok (bool bf)
		{
			mainScreen.UseHwInsDelLine = bf;
		}
		
		public void idcok (bool bf)
		{
			mainScreen.UseHwInsDelChar = bf;
		}
		
		public void immedok (bool bf)
		{
			mainScreen.ImmediateRefresh = bf;
		}
		
		public void leaveok (bool bf)
		{
			mainScreen.CanLeaveCursor = bf;
		}
		
		public void setscrreg (int top, int bot)
		{
			mainScreen.SetScrollRegion (top, bot);
		}
		
		public void scrollok (bool bf)
		{
			mainScreen.EnableScroll = bf;
		}
		
		public void wrefresh ()
		{
			mainScreen.Refresh();
		}

		public void redrawwin ()
		{
			mainScreen.Redraw(); 
		}
		
		public void wredrawwin (int beg_line, int num_lines)
		{
			mainScreen.Redraw (beg_line, num_lines);
		}

		public void wnoutrefresh ()
		{
			mainScreen.NoOutRefresh();
		}

		public void move (int line, int col)
		{
			mainScreen.Move (line, col);
		}

		public void addch (char ch)
		{
			mainScreen.Add (ch);
		}

		public void refresh ()
		{
			mainScreen.Refresh();
		}
	}

	// Currently unused, to do later
	public class Screen {
		public readonly IntPtr Handle;
		
		internal Screen (IntPtr handle)
		{
			Handle = handle;
		}
	}
}
