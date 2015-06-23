using System;
using CursesSharp.Gui;

namespace Gui.FrameWork.Demo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Terminal.Init (false);
			var demoGUI = new Container (0, 0, Terminal.Cols, Terminal.Lines);
			demoGUI.Add (new Label (10, 10, "Hello"));
			demoGUI.Add (new Entry (16, 10, 20, "World"));
			demoGUI.Add (new Label (10, 20, "Ctrl-C / ESC to Exit"));
			Terminal.Run (demoGUI);
		}
	}

}
