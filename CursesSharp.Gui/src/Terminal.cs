using System;
using System.Collections.Generic;
using CursesSharp;

namespace CursesSharp.Gui
{
	/// <summary>
	///   gui.cs Application driver.
	/// </summary>
	/// <remarks>
	///   Before using gui.cs, you must call Application.Init, then
	///   you would create your toplevel container (typically by
	///   calling:  new Container (0, 0, Application.Cols,
	///   Application.Lines), adding widgets to it and finally
	///   calling Application.Run on the toplevel container. 
	/// </remarks>
	public static class Terminal {
		/// <summary>
		///   Color used for unfocused widgets.
		/// </summary>
		public static uint ColorNormal;
		/// <summary>
		///   Color used for focused widgets.
		/// </summary>
		public static uint ColorFocus;
		/// <summary>
		///   Color used for hotkeys in unfocused widgets.
		/// </summary>
		public static uint ColorHotNormal;
		/// <summary>
		///   Color used for hotkeys in focused widgets.
		/// </summary>
		public static uint ColorHotFocus;

		/// <summary>
		///   Color used for marked entries.
		/// </summary>
		public static uint ColorMarked;
		/// <summary>
		///   Color used for marked entries that are currently
		///   selected with the cursor.
		/// </summary>
		public static uint ColorMarkedSelected;

		/// <summary>
		///   Color for unfocused widgets on a dialog.
		/// </summary>
		public static uint ColorDialogNormal;
		/// <summary>
		///   Color for focused widgets on a dialog.
		/// </summary>
		public static uint ColorDialogFocus;
		/// <summary>
		///   Color for hotkeys in an unfocused widget on a dialog.
		/// </summary>
		public static uint ColorDialogHotNormal;
		/// <summary>
		///   Color for a hotkey in a focused widget on a dialog.
		/// </summary>
		public static uint ColorDialogHotFocus;

		/// <summary>
		///   Color used for error text.
		/// </summary>
		public static uint ColorError;

		/// <summary>
		///   Color used for focused widgets on an error dialog.
		/// </summary>
		public static uint ColorErrorFocus;

		/// <summary>
		///   Color used for hotkeys in error dialogs
		/// </summary>
		public static uint ColorErrorHot;

		/// <summary>
		///   Color used for hotkeys in a focused widget in an error dialog
		/// </summary>
		public static uint ColorErrorHotFocus;

		/// <summary>
		///   The basic color of the terminal.
		/// </summary>
		public static uint ColorBasic;

		/// <summary>
		///   The regular color for a selected item on a menu
		/// </summary>
		public static uint ColorMenuSelected;

		/// <summary>
		///   The hot color for a selected item on a menu
		/// </summary>
		public static uint ColorMenuHotSelected;

		/// <summary>
		///   The regular color for a menu entry
		/// </summary>
		public static uint ColorMenu;

		/// <summary>
		///   The hot color for a menu entry
		/// </summary>
		public static uint ColorMenuHot;

		/// <summary>
		///   This event is raised on each iteration of the
		///   main loop. 
		/// </summary>
		/// <remarks>
		///   See also <see cref="Timeout"/>
		/// </remarks>
		static public event EventHandler Iteration;

		// Private variables
		static List<Container> toplevels = new List<Container> ();
		static short last_color_pair;
		static bool inited;
		static Container empty_container;

		/// <summary>
		///    A flag indicating which mouse events are available
		/// </summary>
		public static MouseState MouseEventsAvailable;

		/// <summary>
		///    Creates a new Curses color to be used by Gui.cs apps
		/// </summary>
		public static uint MakeColor (short f, short b)
		{
			Curses.InitPair (++last_color_pair, f, b);
			return Curses.ColorPair ((uint)last_color_pair);
		}

		/// <summary>
		///    The singleton EmptyContainer that covers the entire screen.
		/// </summary>
		static public Container EmptyContainer {
			get {
				return empty_container;
			}
		}

		static Window main_window;
		static Looper mainloop;
		public static Looper MainLoop {
			get {
				return mainloop;
			}
		}

		public static bool UsingColor { get; private set; }

		/// <summary>
		///    Initializes the runtime.   The boolean flag
		///   indicates whether we are forcing color to be off.
		/// </summary>
		public static void Init (bool disable_color = false)
		{
			if (inited)
				return;
			inited = true;

			empty_container = new Container (0, 0, Terminal.Cols, Terminal.Lines);

			try {
				main_window = Curses.InitScr (); 
			} catch (Exception e){
				Console.WriteLine ("Curses failed to initialize, the exception is: " + e);
				throw new Exception ("Terminal.Init failed");
			}
			Curses.RawMode = true;
			Curses.Echo = false;
			//Curses.nonl ();
			Stdscr.Keypad = true;
			//			MainScreen.stdscr.Keypad = true;

			#if BREAK_UTF8_RENDERING
			Curses.Event old = 0;
			MouseEventsAvailable = Curses.console_sharp_mouse_mask (
			Curses.Event.Button1Clicked | Curses.Event.Button1DoubleClicked, out old);
			#endif

			UsingColor = false;
			if (!disable_color)
				UsingColor = Curses.HasColors;

			Curses.StartColor ();
			Curses.UseDefaultColors ();
			if (UsingColor){
				ColorNormal = MakeColor (Colors.WHITE, Colors.BLUE);
				ColorFocus = MakeColor (Colors.BLACK, Colors.CYAN);
				ColorHotNormal = Attrs.BOLD | MakeColor (Colors.YELLOW, Colors.BLUE);
				ColorHotFocus = Attrs.BOLD | MakeColor (Colors.YELLOW, Colors.CYAN);

				ColorMenu = Attrs.BOLD | MakeColor (Colors.WHITE, Colors.CYAN);
				ColorMenuHot = Attrs.BOLD | MakeColor (Colors.YELLOW, Colors.CYAN);
				ColorMenuSelected = Attrs.BOLD | MakeColor (Colors.WHITE, Colors.BLACK);
				ColorMenuHotSelected = Attrs.BOLD | MakeColor (Colors.YELLOW, Colors.BLACK);

				ColorMarked = ColorHotNormal;
				ColorMarkedSelected = ColorHotFocus;

				ColorDialogNormal    = MakeColor (Colors.BLACK, Colors.WHITE);
				ColorDialogFocus     = MakeColor (Colors.BLACK, Colors.CYAN);
				ColorDialogHotNormal = MakeColor (Colors.BLUE,  Colors.WHITE);
				ColorDialogHotFocus  = MakeColor (Colors.BLUE,  Colors.CYAN);

				ColorError = Attrs.BOLD | MakeColor (Colors.WHITE, Colors.RED);
				ColorErrorFocus = MakeColor (Colors.BLACK, Colors.WHITE);
				ColorErrorHot = Attrs.BOLD | MakeColor (Colors.YELLOW, Colors.RED);
				ColorErrorHotFocus = ColorErrorHot;
			} else {
				ColorNormal = Attrs.NORMAL;
				ColorFocus = Attrs.REVERSE;
				ColorHotNormal = Attrs.BOLD;
				ColorHotFocus = Attrs.REVERSE | Attrs.BOLD;

				ColorMenu = Attrs.REVERSE;
				ColorMenuHot = Attrs.NORMAL;
				ColorMenuSelected = Attrs.BOLD;
				ColorMenuHotSelected = Attrs.NORMAL;

				ColorMarked = Attrs.BOLD;
				ColorMarkedSelected = Attrs.REVERSE | Attrs.BOLD;

				ColorDialogNormal = Attrs.REVERSE;
				ColorDialogFocus = Attrs.NORMAL;
				ColorDialogHotNormal = Attrs.BOLD;
				ColorDialogHotFocus = Attrs.NORMAL;

				ColorError = Attrs.BOLD;
			}
			ColorBasic = MakeColor (-1, -1);
			mainloop = new Looper ();
			mainloop.AddWatch (0, Looper.Condition.PollIn, x => {
				Container top = toplevels.Count > 0 ? toplevels [toplevels.Count-1] : null;
				if (top != null)
					ProcessChar (top);

				return true;
			});
		}

		/// <summary>
		///   The number of lines on the screen
		/// </summary>
		static public int Lines {	
			get {
				return Curses.Lines;
			}
		}

		/// <summary>
		///   The number of columns on the screen
		/// </summary>
		static public int Cols {
			get {
				return Curses.Cols;
			}
		}

		/// <summary>
		///   Displays a message on a modal dialog box.
		/// </summary>
		/// <remarks>
		///   The error boolean indicates whether this is an
		///   error message box or not.   
		/// </remarks>
		static public void Msg (bool error, string caption, string t)
		{
			var lines = new List<string> ();
			int last = 0;
			int max_w = 0;
			string x;
			for (int i = 0; i < t.Length; i++){
				if (t [i] == '\n'){
					x = t.Substring (last, i-last);
					lines.Add (x);
					last = i + 1;
					if (x.Length > max_w)
						max_w = x.Length;
				}
			}
			x = t.Substring (last);
			if (x.Length > max_w)
				max_w = x.Length;
			lines.Add (x);

			Dialog d = new Dialog (System.Math.Max (caption.Length + 8, max_w + 8), lines.Count + 7, caption);
			if (error)
				d.ErrorColors ();

			for (int i = 0; i < lines.Count; i++)
				d.Add (new Label (1, i + 1, (string) lines [i]));

			Button b = new Button (0, 0, "Ok", true);
			d.AddButton (b);
			b.Clicked += delegate { b.Container.Running = false; };

			Terminal.Run (d);
		}

		/// <summary>
		///   Displays an error message.
		/// </summary>
		/// <remarks>
		/// </remarks>
		static public void Error (string caption, string text)
		{
			Msg (true, caption, text);
		}

		/// <summary>
		///   Displays an error message.
		/// </summary>
		/// <remarks>
		///   Overload that allows for String.Format parameters.
		/// </remarks>
		static public void Error (string caption, string format, params object [] pars)
		{
			string t = String.Format (format, pars);

			Msg (true, caption, t);
		}

		/// <summary>
		///   Displays an informational message.
		/// </summary>
		/// <remarks>
		/// </remarks>
		static public void Info (string caption, string text)
		{
			Msg (false, caption, text);
		}

		/// <summary>
		///   Displays an informational message.
		/// </summary>
		/// <remarks>
		///   Overload that allows for String.Format parameters.
		/// </remarks>
		static public void Info (string caption, string format, params object [] pars)
		{
			string t = String.Format (format, pars);

			Msg (false, caption, t);
		}

		static void Shutdown ()
		{
			Curses.EndWin ();;
		}

		static void Redraw (Container container)
		{
			container.Redraw ();
			Stdscr.Refresh ();
		}

		/// <summary>
		///   Forces a repaint of the screen.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public static void Refresh ()
		{
			Container last = null;

			main_window.Redraw ();
			foreach (Container c in toplevels){
				c.Redraw ();
				last = c;
			}
			Stdscr.Refresh ();
			if (last != null)
				last.PositionCursor ();
		}

		/// <summary>
		///   Starts running a new container or dialog box.
		/// </summary>
		/// <remarks>
		///   Use this method if you want to start the dialog, but
		///   you want to control the main loop execution manually
		///   by calling the RunLoop method (for example, to start
		///   the dialog, but continuing to process events).
		///
		///    Use the returned value as the argument to RunLoop
		///    and later to the End method to remove the container
		///    from the screen.
		/// </remarks>
		static public RunState Begin (Container container)
		{
			if (container == null)
				throw new ArgumentNullException ("container");
			var rs = new RunState (container);

			Init ();

			Stdscr.ReadTimeout = -1;

			toplevels.Add (container);

			container.Prepare ();
			container.SizeChanged ();			
			container.FocusFirst ();

			Redraw (container);
			container.PositionCursor ();
			Stdscr.Refresh ();

			return rs;
		}

		/// <summary>
		///   Runs the main loop for the created dialog
		/// </summary>
		/// <remarks>
		///   Calling this method will block until the
		///   dialog has completed execution.
		/// </remarks>
		public static void RunLoop (RunState state)
		{
			RunLoop (state, true);
		}

		/// <summary>
		///   Runs the main loop for the created dialog
		/// </summary>
		/// <remarks>
		///   Use the wait parameter to control whether this is a
		///   blocking or non-blocking call.
		/// </remarks>
		public static void RunLoop (RunState state, bool wait)
		{
			if (state == null)
				throw new ArgumentNullException ("state");
			if (state.Container == null)
				throw new ObjectDisposedException ("state");

			for (state.Container.Running = true; state.Container.Running; ){
				if (mainloop.EventsPending (wait)){
					mainloop.MainIteration ();
					if (Iteration != null)
						Iteration (null, EventArgs.Empty);
				} else if (wait == false)
					return;
			}
		}

		public static void Stop ()
		{
			if (toplevels.Count == 0)
				return;
			toplevels [toplevels.Count-1].Running = false;
			MainLoop.Stop ();
		}

		/// <summary>
		///   Runs the main loop on the given container.
		/// </summary>
		/// <remarks>
		///   This method is used to start processing events
		///   for the main application, but it is also used to
		///   run modal dialog boxes.
		/// </remarks>
		static public void Run (Container container)
		{
			var runToken = Begin (container);
			RunLoop (runToken);
			Stdscr.Clear ();
			End (runToken);
//			inited = false;
		}

		/// <summary>
		///   Use this method to complete an execution started with Begin
		/// </summary>
		static public void End (RunState state)
		{
			if (state == null)
				throw new ArgumentNullException ("state");
			state.Dispose ();
		}

		// Called by the Dispose handler.
		internal static void End (Container container)
		{
			toplevels.Remove (container);
			if (toplevels.Count == 0)
				Shutdown ();
			else
				Refresh ();
		}

		static void ProcessChar (Container container)
		{
			int ch = Stdscr.GetChar ();

			if ((ch == -1) || (ch == Keys.RESET)){
				// TODO: Fixme				
				//				if (Curses.CheckWinChange ()){
				//					EmptyContainer.Clear ();
				//					foreach (Container c in toplevels)
				//						c.SizeChanged ();
				//					Refresh ();
				//				}
				return;
			}

			// Control-c, quit the current operation.
			if (ch == Keys.CTRLC || ch == Keys.ESC){
				container.Running = false;
				return;
			}

			if (ch == Keys.MOUSE){
				MouseEvent ev = Curses.GetMouse ();
				container.ProcessMouse (ev);
				return;
			}

			if (ch == Keys.ESC){
				Stdscr.ReadTimeout = 100;
				int k = Stdscr.GetChar ();
				if (k != Curses.ERR && k != Keys.ESC)
					ch = Curses.KeyAlt | k;
				Stdscr.ReadTimeout = -1;
			}

			if (container.ProcessHotKey (ch))
				return;

			if (container.ProcessKey (ch))
				return;

			if (container.ProcessColdKey (ch))
				return;

			// Control-z, suspend execution, then repaint.
			if (ch == Keys.CTRLZ) {
				Curses.SendSignalToStop ();
				// TODO: Fixme ;-) This is broken on return
				container.Redraw ();
				Stdscr.Refresh ();
				return;
			}

			//
			// Focus handling
			//
			if (ch == 9 || ch == Keys.DOWN || ch == Keys.RIGHT) {
				if (!container.FocusNext ())
					container.FocusNext ();
				Stdscr.Refresh ();
			} else if (ch == Keys.UP  || ch == Keys.LEFT){
				if (!container.FocusPrev ())
					container.FocusPrev ();
				Stdscr.Refresh ();
			}
		}
	}

	public class RunState : IDisposable {
		internal RunState (Container container)
		{
			Container = container;
		}
		internal Container Container;

		public void Dispose ()
		{
			Dispose (true);
//			GC.SuppressFinalize(this);
		}

		public virtual void Dispose (bool disposing)
		{
			if (Container != null){
				Terminal.End (Container);
				Container = null;
			}
		}
	}}

