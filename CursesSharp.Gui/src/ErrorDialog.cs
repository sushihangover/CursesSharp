using System;
using CursesSharp.Gui;

namespace CursesSharp.Gui
{
	public static class ErrorBox
	{

		public static void Error (string msg, string file)
		{
			Error (msg + file);
		}

		public static void Error (string msg)
		{
			var d = new Dialog (Math.Min (Terminal.Cols-8, msg.Length+6), 8, "Error");
			d.ErrorColors ();
			d.Add (new Label (1, 1, msg));
			var b = new Button (0, 0, "Ok");
			b.Clicked += delegate {
				d.Running = false;
			};
			d.AddButton (b);
			Terminal.Run (d);
		}
	}
}

