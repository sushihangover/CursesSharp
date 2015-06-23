using CursesSharp;

namespace HelloWorldDemo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// C style from http://www.tldp.org/HOWTO/NCURSES-Programming-HOWTO/helloworld.html
//			initscr();			/* Start curses mode 		  */
//			printw("Hello World !!!");	/* Print Hello World		  */
//			refresh();			/* Print it on to the real screen */
//			getch();			/* Wait for user input */
//			endwin();			/* End curses mode		  */

			Curses.InitScr ();
			Stdscr.Add ("Hello World !!!");
			Stdscr.Refresh ();
			Stdscr.GetChar ();
			Curses.Beep ();
			Curses.EndWin();
		}
	}
}
