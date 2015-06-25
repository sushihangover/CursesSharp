using System;
using CursesSharp;

namespace CursesSharp.Gui
{
	public class ButtonBar : Widget
	{
		string[] labels;

		public delegate void ButtonAction (int n);

		public ButtonBar (string[] labels) : base (0, Terminal.Lines - 1, Terminal.Cols, 1)
		{
			this.labels = labels;
		}

		public string this [int idx] {
			get {
				return labels [idx];
			}
			set {
				labels [idx] = value;
				Redraw ();
			}
		}

		//		public override void Redraw ()
		//		{
		//			//int x = 0;
		//			int y = Terminal.Lines - 1;
		//			Move (y, 0);
		//
		//			for (int i = 0; i < labels.Length; i++) {
		//				Stdscr.Attr = Terminal.ColorBasic;
		//				Stdscr.Add (i == 0 ? "1" : String.Format (" {0}", i + 1));
		//				Stdscr.Attr = ColorFocus;
		//				try {
		//					Stdscr.Add ("{0,-6}", labels [i]);
		//				} catch {
		//					Console.WriteLine ("{0}:{1}", Curses.Lines, Curses.Cols);
		//				}
		//			}
		//		}
		public override void Redraw ()
		{
			#if DEBUG
			Debug.Print ("Button redraw - start");
			#endif
			int y = Terminal.Lines - 1;
			Move (y, 0);

			for (int i = 0; i < labels.Length; i++) {
				#if DEBUG
				int curX;
				int curY;
				Curses.StdScr.GetCursorYX (out curX, out curY);
				Debug.Print ("Button redraw - x:{0} y:{1} - {2}", curX, curY, labels [i]);
				#endif
				Stdscr.Attr = Terminal.ColorBasic;
				Stdscr.Add (i == 0 ? "1" : String.Format (" {0}", i + 1));
				Stdscr.Attr = ColorFocus;
				try {
					Stdscr.Add ("{0,-6}", labels [i]);
				} catch {
					#if DEBUG
					Debug.Print ("Exception: Button Redraw - Stdscr.Add {0,-6}", labels [i]);
					#endif
				}
			}
			#if DEBUG
			Debug.Print ("Button redraw - end");
			#endif
		}

		public override void DoSizeChanged ()
		{
			y = Terminal.Lines - 1;
		}

		void Raise (int n)
		{
			if (Action != null)
				Action (n);
		}

		public event ButtonAction Action;

		public override bool ProcessHotKey (int key)
		{
			if ((key >= (Keys.KEY_F (1)) && key <= Keys.KEY_F (10))) {
				Raise (key - Keys.KEY_F (1) + 1);
			} else if (key >= (Curses.KeyAlt + '0') && (key <= (Curses.KeyAlt + '9'))) {
				var n = (key - Curses.KeyAlt - '0');
				Raise (n == 0 ? n = 10 : n);
			} else
				return false;

			return true;
		}
	}
}

