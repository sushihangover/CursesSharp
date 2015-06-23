using System;
using CursesSharp.Gui;

namespace Demo.Gui.Timeout
{
	class MainClass
	{
		static void Stamp (string txt)
		{
			Console.WriteLine ("{0} At {1}", txt, DateTime.Now);
		}

		static bool timeout(Looper looper) {
			Console.WriteLine ("{0}", "Hello from looper");
			return true;
		}
			
		public static void Main (string[] args)
		{
			Console.WriteLine ("The Timeout code is broken...it was broken in the original repo/version also");
			var myLoop = new Looper ();
			Stamp ("Start");
			var firstTimeout = myLoop.AddTimeout (TimeSpan.FromSeconds (1), timeout );
			var secondTimeout = myLoop.AddTimeout (TimeSpan.FromSeconds (2), x => {
				Stamp ("2 second timeout");
				return true;
			});
			var thirdTimeout = myLoop.AddTimeout (TimeSpan.FromSeconds (3), x => {
				Stamp ("3 second timeout");
				return true;
			});

			var fiveSecondTimeout = myLoop.AddTimeout (TimeSpan.FromSeconds (10), x => {
				Console.WriteLine("Stopping timers");
				myLoop.RemoveTimeout (thirdTimeout);
				myLoop.RemoveTimeout (secondTimeout);
				myLoop.RemoveTimeout (firstTimeout);
				myLoop.Stop ();
				return false;
			});

			myLoop.Run ();
			myLoop.RemoveTimeout (fiveSecondTimeout);
		}
	}
}
