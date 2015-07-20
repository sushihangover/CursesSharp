using System;
using System.Runtime.InteropServices;

namespace Demo.Native.ResizeTerm
{
	class MainClass
	{
		[DllImport ("libc")]
		private static extern int system (string exec);

		[DllImport("ncurses")]
		private static extern int resize_term(int nlines, int ncols);
		[DllImport("ncurses")]
		private static extern IntPtr initscr();


		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello Stack overflow, lets get bigger");
			initscr ();
			resize_term (50, 100);
			system("resize -s 50 100 > /dev/null");
			Console.WriteLine ("We will be 50 line and 100 columns in Terminal.app now");
			Console.ReadKey ();
		}
	}
}
