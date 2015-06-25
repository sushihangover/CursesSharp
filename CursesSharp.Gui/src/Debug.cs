using System.IO;

namespace CursesSharp.Gui
{
	static class Debug
	{
		static readonly StreamWriter log = File.CreateText ("log");

		static public void Print (string msg)
		{
			log.WriteLine (msg);
			log.Flush ();
		}

		static public void Print (string format, params object[] args)
		{
			log.WriteLine (format, args);
			log.Flush ();
		}
	}
}
