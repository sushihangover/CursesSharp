using System;
using CursesSharp;
using CursesSharp.Gui;

namespace CursesSharp.Gui
{
	public class MessageBox {
		public static int Query (int width, int height, string title, string message, params string [] buttons)
		{
			var d = new Dialog (width, height, title);
			int clicked = -1, count = 0;

			foreach (var s in buttons){
				int n = count++;
				var b = new Button (s);
				b.Clicked += delegate {
					clicked = n;
					d.Running = false;
				};
				d.AddButton (b);
			}
			if (message != null){
				var l = new Label ((width - 4 - message.Length)/2, 0, message);
				d.Add (l);
			}

			Terminal.Run (d);
			return clicked;
		}
	}
}

