using System;
using CursesSharp;
using CursesSharp.Gui;

namespace Demo.Gui.MessageBox
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Terminal.Init ();
			var demoGUI = new Container (0, 0, Terminal.Cols, Terminal.Lines);
			demoGUI.Add (new Label ( (Terminal.Cols / 2) - 6, (Terminal.Lines / 2) - 1, "Hello World"));
			Terminal.Run(demoGUI);
			ErrorBox.Error ("Bye World From SushiHangover");
		}
	}
}
