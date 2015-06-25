#region Copyright 2009 Robert Konklewski

/*
 * CursesSharp
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * www.gnu.org/licenses/>.
 * 
 */

#endregion

using System;
using CursesSharp.Internal;

namespace CursesSharp
{
    /// <summary>
    /// A callback function type for use in RipOffLine method.
    /// </summary>
    public delegate int RipOffLineFun(Window win, int ncols);

#if HAVE_CURSES_MOUSE
    /// <summary>
    /// Represents an event reported by a mouse.
    /// </summary>
    public class MouseEvent
    {
        private int id;
        private int x, y, z;
        private MouseState bstate;

        /// <summary>
        /// Creates an empty mouse event.
        /// </summary>
        /// <remarks>
        /// To be used for creating an object that is passed to 
        /// <see cref="Curses.GetMouse(MouseEvent)"/> method.
        /// </remarks>
        public MouseEvent()
        {
        }

        /// <summary>
        /// Creates a mouse event with specified values.
        /// </summary>
        /// <param name="id">ID of the mouse that reported the event.</param>
        /// <param name="x">X coordinate of mouse cursor at the time of the event.</param>
        /// <param name="y">Y coordinate of mouse cursor at the time of the event.</param>
        /// <param name="z">Z coordinate of mouse cursor at the time of the event.</param>
        /// <param name="bstate">State of mouse buttons at the time of the event.</param>
        public MouseEvent(int id, int x, int y, int z, MouseState bstate)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.z = z;
            this.bstate = bstate;
        }

        /// <summary>
        /// Represents the ID of the mouse that reported the event.
        /// </summary>
        /// <value>Gets the ID of the mouse the reported the event.</value>
        public int Id
        {
            get { return this.id; }
            internal set { this.id = value; }
        }

        /// <summary>
        /// Represents the X coordinate of mouse cursor position at the
        /// time the event was reported.
        /// </summary>
        /// <value>Gets the X coordinate of mouse cursor position.</value>
        public int X
        {
            get { return this.x; }
             set { this.x = value; }
        }

        /// <summary>
        /// Represents the Y coordinate of mouse cursor position at the
        /// time the event was reported.
        /// </summary>
        /// <value>Gets the Y coordinate of mouse cursor position.</value>
        public int Y
        {
            get { return this.y; }
             set { this.y = value; }
        }

        /// <summary>
        /// Represents the Z coordinate of mouse cursor position at the
        /// time the event was reported.
        /// </summary>
        /// <value>Gets the Z coordinate of mouse cursor position.</value>
        public int Z
        {
            get { return this.z; }
            internal set { this.z = value; }
        }

        /// <summary>
        /// Represents the state of mouse buttons at the time the event
        /// was reported.
        /// </summary>
        /// <value>Gets the state of mouse buttons.</value>
        public MouseState State
        {
            get { return this.bstate; }
            internal set { this.bstate = value; }
        }
    };
#endif

    /// <summary>
    /// Static interface to the curses library.
    /// </summary>
    public static partial class Curses
    {
		// We encode ESC + char (what Alt-char generates) as 0x2000 + char
		public const int KeyAlt = 0x2000;
		public const int ERR = int.MaxValue;

		public static int IsAlt (int key)
		{
			if ((key & KeyAlt) != 0)
				return key & ~KeyAlt;
			return 0;
		}

		static public uint ColorPair(uint n){
			return 0 + n * 256;
		}

		/// <summary>
		/// When initscr() is called two WINDOWs, the stdscr and curscr come into existance. 
		/// stdscr (standard screen) is what will be displayed by the next refresh() call 
		/// stdscr have size equivalent to that of the screen.
		/// </summary>
        private static Window stdscr = null;
		/// <summary>
		/// When initscr() is called two WINDOWs, the stdscr and curscr come into existance. 
		/// curscr is the current state of the screen.
		/// curscr have size equivalent to that of the screen.
		/// </summary>
		private static Window curscr = null;

        /// <summary>
        /// Represents the default window that is created during library initialization.
		/// </summary>
        /// <value>Gets the default window.</value>
        public static Window StdScr
        {
            get { return stdscr; }
        }

		public static Window CurScr
		{
			get { return curscr; }
		}

        /// <summary>
        /// Represents the number of lines on the screen.
        /// </summary>
        /// <value>Gets the number of lines on the screen.</value>
        public static int Lines
        {
            get { return CursesMethods.LINES(); }
        }

        /// <summary>
        /// Represents the number of columns on the screen.
        /// </summary>
        /// <value>Returns the number of columns on the screen.</value>
        public static int Cols
        {
            get { return CursesMethods.COLS(); }
        }

        /// <summary>
        /// Represents the maximum number of colors that the screen can display.
        /// </summary>
        /// <value>Gets the maximum number of colors.</value>
        public static int Colors
        {
            get { return CursesMethods.COLORS(); }
        }

        /// <summary>
        /// Represents the maximum number of color pairs that can be defined.
        /// </summary>
        /// <value>Returns the maximum number of color pairs.</value>
        public static int ColorPairs
        {
            get { return CursesMethods.COLOR_PAIRS(); }
        }

        /// <summary>
        /// Represents the size of the TAB character.
        /// </summary>
        /// <value>Returns the size of the TAB character.</value>
        public static int TabSize
        {
            get { return CursesMethods.TABSIZE(); }
        }

        /// <summary>
        /// Encodes a specified color pair into a text attribute.
        /// </summary>
        /// <param name="n">Color pair number</param>
        /// <returns>Text attribute (ch)</returns>
        public static uint COLOR_PAIR(int n)
        {
            return CursesMethods.COLOR_PAIR(n);
        }

        /// <summary>
        /// Extracts the color pair from a specified text attribute.
        /// </summary>
        /// <param name="n">Text attribute (ch)</param>
        /// <returns>Color pair number</returns>
        public static short PAIR_NUMBER(uint n)
        {
            return CursesMethods.PAIR_NUMBER(n);
        }

        /// <summary>
        /// Initializes Curses Sharp and the underlying curses implementation.
        /// </summary>
        /// 
        /// <remarks>
        /// It should be the first function called as most other functions
        /// require the library be initialized.
        /// <para>
        /// The Window object returned can be later retrieved using 
        /// <see cref="StdScr"/> property.
        /// </para>
        /// </remarks>
        /// <returns>The default Window object</returns>
        public static Window InitScr()
        {
            if (stdscr != null)
                throw new InvalidOperationException("Curses is already initialized.");

            stdscr = Window.WrapHandle(CursesMethods.initscr ());
			curscr = Window.WrapHandle(CursesMethods.curscr ());
            return stdscr;
        }

        /// <summary>
        /// Shuts down Curses Sharp and the underlying curses implementation.
        /// </summary>
        public static void EndWin()
        {
            if (stdscr == null)
                throw new InvalidOperationException("Curses is not initialized.");
            stdscr.Dispose();
            CursesMethods.endwin();
            //stdscr = null;
        }

        /// <summary>
        /// Returns true if EndWin has been called, and false otherwise.
        /// </summary>
        public static bool IsEndWin
        {
            get
            {
                return CursesMethods.isendwin();
            }
        }

        /// <summary>
        /// Resizes the default and current window objects.
        /// </summary>
        /// <remarks>
        /// In Win32 (PDCurses) also resizes the console window.
        /// </remarks>
        /// <param name="nlines">New number of lines</param>
        /// <param name="ncols">New number of columns</param>
        public static void ResizeTerm(int nlines, int ncols)
        {
            CursesMethods.resize_term(nlines, ncols);
        }

        /// <summary>
        /// Sounds an audible alarm.
        /// </summary>
        /// <remarks>
        /// Sounds an audible alarm on the terminal, if possible; otherwise 
        /// it flashes the screen (visible bell).
        /// If neither alter is possible, nothing happens.        
        /// </remarks>
        public static void Beep()
        {
            CursesMethods.beep();
        }

        /// <summary>
        /// Flashes the screen.
        /// </summary>
        /// <remarks>
        /// Flashes the screen, and if that is not possible, sounds the alert.
        /// If neither alter is possible, nothing happens.
        /// </remarks>
        public static void Flash()
        {
            CursesMethods.flash();
        }

        /// <summary>
        /// Initializes the basic colors.
        /// </summary>
        /// <remarks>
        /// Initializes eight basic colors (black, red, green, yellow, blue,
        /// magenta, cyan, and white), and two global properties, <see cref="Colors"/>
        /// and <see cref="ColorPairs"/>. It also restores the colors on the
        /// terminal to the values they had when the terminal was just
        /// turned on.
        /// <para>
        /// StartColor must be called if the programmer wants to use colors, 
        /// and before any other color manipulation method is called. It is 
        /// good practice to call this method right after <see cref="InitScr"/>.
        /// </para>
        /// </remarks>
        public static void StartColor()
        {
            CursesMethods.start_color();
        }

        /// <summary>
        /// Changes the definition of a color-pair.
        /// </summary>
        /// <remarks>
        /// If the color-pair was previously initialized, the screen is 
        /// refreshed and all occurences of that color-pair are changed 
        /// to the new definition.
        /// <para>
        /// For portable applications the value of <paramref name="color"/> 
        /// must be between 1 and <see cref="ColorPairs"/> - 1, and the value 
        /// of <paramref name="fg"/> and <paramref name="bg"/> must be
        /// between 0 and <see cref="Colors"/>.
        /// </para>
        /// </remarks>
        /// <param name="color">Number of the color-pair to be changed.</param>
        /// <param name="fg">Foreground color number.</param>
        /// <param name="bg">Background color number.</param>
        public static void InitPair(short color, short fg, short bg)
        {
            CursesMethods.init_pair(color, fg, bg);
        }

        /// <summary>
        /// Changes the definition of a color.
        /// </summary>
        /// <remarks>
        /// When it is used, all occurences of that color on the screen 
        /// immediately change to the new definition.
        /// <para>
        /// The value of <paramref name="color"/> must be between 0 and 
        /// <see cref="Colors"/>, and the value of <paramref name="red"/>,
        /// <paramref name="green"/> and <paramref name="blue"/> must be
        /// between 0 and 1000.
        /// </para>
        /// </remarks>
        /// <param name="color">Number of the color to be changed.</param>
        /// <param name="red">Amount of the red color component.</param>
        /// <param name="green">Amount of the green color component.</param>
        /// <param name="blue">Amount of the blue color component.</param>
        public static void InitColor(short color, short red, short green, short blue)
        {
            CursesMethods.init_color(color, red, green, blue);
        }

        /// <summary>
        /// Retrieves the intensity of the red, green and blue (RGB) components
        /// in a color.
        /// </summary>
        /// <remarks>
        /// Requires three references of variables for storing the
        /// information about amounts of the components in that color.
        /// the components.
        /// <para>
        /// The value of <paramref name="color"/> must be between 0 and 
        /// <see cref="Colors"/>. The values that are stored in 
        /// <paramref name="red"/>, <paramref name="green"/> and 
        /// <paramref name="blue"/> are between 0 and 1000.
        /// </para>
        /// </remarks>
        /// <param name="color">Color number</param>
        /// <param name="red">Reference to a variable in which the amount of 
        ///     the red color component will be stored.</param>
        /// <param name="green">Reference to a variable in which the amount of 
        ///     the green color component will be stored.</param>
        /// <param name="blue">Reference to a variable in which the amount of 
        ///     the blue color component will be stored.</param>
        public static void ColorContent(short color, out short red, out short green, out short blue)
        {
            CursesMethods.color_content(color, out red, out green, out blue);
        }

        /// <summary>
        /// Retrieves the color numbers that a specified color-pair consists of.
        /// </summary>
        /// <remarks>
        /// Requires two references of variables for storing the foreground
        /// and the background color numbers.
        /// <para>
        /// The value of <paramref name="color"/> must be between 1 and 
        /// <see cref="ColorPairs"/> - 1. The values that are stored in 
        /// <paramref name="fg"/> and <paramref name="bg"/> are between
        /// 0 and <see cref="Colors"/>.
        /// </para>
        /// </remarks>
        /// <param name="color">Color-pair number</param>
        /// <param name="fg">Reference to a variable in which the foreground
        ///     color will be stored.</param>
        /// <param name="bg">Reference to a variable in which the background
        ///     color will be stored.</param>
        public static void PairContent(short color, out short fg, out short bg)
        {
            CursesMethods.pair_content(color, out fg, out bg);
        }

        /// <summary>
        /// Represents the ability of the terminal to manipulate colors.
        /// </summary>
        /// <value>Returns true if the terminal can manipulate colors.</value>
        public static bool HasColors
        {
            get
            {
                return CursesMethods.has_colors();
            }
        }

        /// <summary>
        /// Represents the ability of the terminal to change color definitions.
        /// </summary>
        /// <value>Returns true if the terminal supports colors and can change 
        ///     their definitions.</value>
        public static bool CanChangeColor
        {
            get
            {
                return CursesMethods.can_change_color();
            }
        }

        /// <summary>
        /// Changes the definition of a color-pair number 0.
        /// </summary>
        /// <remarks>
        /// The screen is refreshed and all occurences of color-pair 
        /// number 0 are changed to the new definition. The value of 
        /// <paramref name="fg"/> and <paramref name="bg"/> must 
        /// be between 0 and <see cref="Colors"/>.
        /// </remarks>
        /// <param name="fg">Foreground color number.</param>
        /// <param name="bg">Background color number.</param>
        public static void AssumeDefaultColors(int fg, int bg)
        {
            CursesMethods.assume_default_colors(fg, bg);
        }

        /// <summary>
        /// Enables the use of default (-1) colors.
        /// </summary>
        /// <remarks>
        /// If this method is first called, the color number -1 can also be 
        /// used in methods that require color numbers as arguments.
        /// </remarks>
        public static void UseDefaultColors()
        {
            CursesMethods.use_default_colors();
        }

        /// <summary>
        /// Places a character back into the input queue to be returned
        /// by the next call to <see cref="WindowBase.GetChar()"/>.
        /// </summary>
        /// <remarks>
        /// There is just one input queue for all windows.
        /// </remarks>
        /// <param name="ch">Character to be placed into the input queue.</param>
        public static void UngetCh(int ch)
        {
            CursesMethods.ungetch(ch);
        }

        /// <summary>
        /// Throws away any typeahead that has been typed by the user and 
        /// has not yet been read by the program.
        /// </summary>
        public static void FlushInput()
        {
            CursesMethods.flushinp();
        }

        /// <summary>
        /// Represents the state of cbreak mode, i.e. the state of line 
        /// buffering and erase/kill character processing. 
        /// </summary>
        /// <remarks>
        /// If the value is set to true, then line buffering and erase/kill 
        /// character processing is disabled, making characters typed by 
        /// the user immediately available to the program. If the value
        /// is set to false, then the terminal is put into normal (cooked)
        /// mode.
        /// <para>
        /// Initially the terminal may or may not be in cbreak mode; therefore, 
        /// a program should enable or disable this mode explicitly.
        /// </para>
        /// <para>
        /// Equivalent to curses cbreak/nocbreak functions.
        /// </para>
        /// </remarks>
        /// <value>Places the terminal into or out of cbreak mode.</value>
        public static bool CBreakMode
        {
            set
            {
                if (value)
                    CursesMethods.cbreak();
                else
                    CursesMethods.nocbreak();
            }
        }

        /// <summary>
        /// Sets half-delay mode. 
        /// </summary>
        /// <remarks>
        /// This mode is similar to cbreak mode in that characters typed 
        /// by the user are immediately available to the program. 
        /// However, after blocking for <paramref name="tenths"/>
        /// tenths of seconds, -1 is returned if nothing has been typed.
        /// <para>
        /// The value of <paramref name="tenths"/> must be between
        /// 1 and 255.
        /// </para>
        /// <para>
        /// The terminal is placed out of half-delay mode by entering normal 
        /// (cooked) mode, i.e. setting <see cref="CBreakMode"/> to false.
        /// </para>        
        /// </remarks>
        /// <param name="tenths"></param>
        public static void HalfDelayMode(int tenths)
        {
            CursesMethods.halfdelay(tenths);
        }

        /// <summary>
        /// Represents the state of raw mode. 
        /// </summary>
        /// <remarks>
        /// Raw mode is similar to cbreak 
        /// mode, in that characters typed are immediately available to the
        /// program. The differences are that in raw mode, the interrupt,
        /// quit, suspend, and flow characters are all passed through
        /// uninterpreted, instead of generating a signal.
        /// </remarks>
        /// <value>Places the terminal into or out of raw mode.</value>
        public static bool RawMode
        {
            set
            {
                if (value)
                    CursesMethods.raw();
                else
                    CursesMethods.noraw();
            }
        }

        /// <summary>
        /// Represents the state of echoing characters typed by the user
        /// by <see cref="WindowBase.GetChar()"/>. 
        /// </summary>
        /// <remarks>
        /// If set to true, characters are echoed as they are typed. If
        /// set to false, characters typed are not echoed.
        /// <para>
        /// Initially Curses Sharp is in echo mode, so characters typed
        /// are echoed.
        /// </para>
        /// </remarks>
        /// <value>Enables or disables echoing of characters typed.</value>
        public static bool Echo
        {
            set
            {
                if (value)
                    CursesMethods.echo();
                else
                    CursesMethods.noecho();
            }
        }

        /// <summary>
        /// Represents the status of newline character processing by the terminal.
        /// </summary>
        /// <remarks>
        /// Represents the status of newline character processing by the terminal,
        /// i.e. whether the underlying display device translates the return key
        /// into newline on input, and whether it translates newline into return
        /// and line-feed on output. In either case, the call Add('\n') does the
        /// equivalent of return and line-feed on the virtual screen.
        /// <para>
        /// Initially these translations do occur. If they are disabled, curses
        /// will be able to make better use of the line-feed capability, resulting
        /// in faster cursor motion. Also, curses will be able then to detect
        /// the return key.
        /// </para>
        /// </remarks>
        /// <value>Enables or disables processing of newline characters.</value>
        public static bool Newlines
        {
            set
            {
                if (value)
                    CursesMethods.nl();
                else
                    CursesMethods.nonl();
            }
        }

        public static bool QiFlush
        {
            set
            {
                if (value)
                    CursesMethods.qiflush();
                else
                    CursesMethods.noqiflush();
            }
        }

        /// <summary>
        /// Saves the current terminal modes as the "program" (in curses) state
        /// for use by the <see cref="ResetProgramMode"/> method.
        /// </summary>
        /// <remarks>
        /// This is done automatically by <see cref="InitScr"/>.
        /// </remarks>
        public static void SaveProgramMode()
        {
            CursesMethods.def_prog_mode();
        }

        /// <summary>
        /// Saves the current terminal modes as the "shell" (out of curses) state
        /// for use by the <see cref="ResetShellMode"/> method.
        /// </summary>
        /// <remarks>
        /// This is done automatically by <see cref="InitScr"/>.
        /// </remarks>
        public static void SaveShellMode()
        {
            CursesMethods.def_shell_mode();
        }

        /// <summary>
        /// Restores the terminal to "program" (in curses) state.
        /// </summary>
        public static void ResetProgramMode()
        {
            CursesMethods.reset_prog_mode();
        }

        /// <summary>
        /// Restores the terminal to "shell" (out of curses) state.
        /// </summary>
        /// <remarks>
        /// This is done automatically by <see cref="EndWin"/>.
        /// </remarks>
        public static void ResetShellMode()
        {
            CursesMethods.reset_shell_mode();
        }

        /// <summary>
        /// Saves the current state of the terminal modes. It can be
        /// restored later by <see cref="ResetTty"/>.
        /// </summary>
        public static void SaveTty()
        {
            CursesMethods.savetty();
        }

        /// <summary>
        /// Restores the state of the termial modes to what it was at the last
        /// call to <see cref="SaveTty"/>.
        /// </summary>
        public static void ResetTty()
        {
            CursesMethods.resetty();
        }

        public static void GetCursorYX(out int y, out int x)
        {
            CursesMethods.getsyx(out y, out x);
        }

        public static void SetCursorYX(int y, int x)
        {
            CursesMethods.setsyx(y, x);
        }

        public static void RipOffLine(int line, RipOffLineFun init)
        {
            RipOffLineFunInt initInt = delegate(IntPtr winptr, int ncols)
            {
                return init(Window.WrapHandle(winptr), ncols);
            };
            CursesMethods.ripoffline(line, initInt);
        }

        /// <summary>
        /// Used to sleep for <paramref name="ms"/> milliseconds.
        /// </summary>
        /// <param name="ms">Number of milliseconds to sleep.</param>
        public static void NapMs(int ms)
        {
            CursesMethods.napms(ms);
        }

        /// <summary>
        /// Represents the appearance of the cursor.
        /// </summary>
        /// <remarks>
        /// <para>
        /// <list type="table">
        ///     <listheader>
        ///         <term>Value</term>
        ///         <description>Cursor appearance</description>
        ///     </listheader>
        ///     <item>
        ///         <term>0</term>
        ///         <description>Invisible</description>
        ///     </item>
        ///     <item>
        ///         <term>1</term>
        ///         <description>Normal</description>
        ///     </item>
        ///     <item>
        ///         <term>2</term>
        ///         <description>Very visible</description>
        ///     </item>
        /// </list>
        /// </para>
        /// </remarks>
        /// <value>Sets the appearance of the cursor.</value>
        public static int CursorVisibility
        {
            set { CursesMethods.curs_set(value); }
        }

        /// <summary>
        /// Returns a string corresponding to the key <paramref name="key"/>.
        /// </summary>
        /// <remarks>
        /// Returns a string corresponding to the key <paramref name="key"/>
        /// according to the following rules:
        /// <list type="bullet">
        ///     <item>
        ///         <description>
        ///         Printable characters are displayed as themselves, e.g. 
        ///         a one-character string containing the key.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         Control characters are displayed in the ^X notation.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         DEL (character 127) is displayed as ^?.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         Values above 128 are either meta characters (if the screen
        ///         has not been initialized, or if <see cref="WindowBase.Meta"/>
        ///         has been set to true), shown in the M-X notation, or are
        ///         displayed as themselves, in which case the values may
        ///         not be printable.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         Values above 256 may be the names of function keys.
        ///         </description>
        ///     </item>
        ///     <item>
        ///         <description>
        ///         Otherwise (if there is no corresponding name), an exception 
        ///         is thrown.
        ///         </description>
        ///     </item>
        /// </list>
        /// </remarks>
        /// <param name="key">Code of the key to find.</param>
        /// <returns>String corresponding to the specified key.</returns>
        public static string KeyName(int key)
        {
            return CursesMethods.keyname(key);
        }

        /// <summary>
        /// Checks if the terminal recognizes a key.
        /// </summary>
        /// <param name="key">Value of the key to check.</param>
        /// <returns>true if the key is recognized; false, otherwise.</returns>
        public static bool HasKey(int key)
        {
            return CursesMethods.has_key(key);
        }

#if HAVE_CURSES_MOUSE
        public static bool HasMouse
        {
            get
            {
                return CursesMethods.has_mouse();
            }
        }

        public static MouseEvent GetMouse()
        {
            WrapMEvent wme;
            CursesMethods.getmouse(out wme);
            return new MouseEvent(wme.id, wme.x, wme.y, wme.z, (MouseState)wme.bstate);
        }

        public static void GetMouse(MouseEvent mevent)
        {
            WrapMEvent wme;
            CursesMethods.getmouse(out wme);
            mevent.Id = wme.id;
            mevent.X = wme.x;
            mevent.Y = wme.y;
            mevent.Z = wme.z;
            mevent.State = (MouseState)wme.bstate;
        }

        public static void UngetMouse(MouseEvent mevent)
        {
            WrapMEvent wme;
            wme.id = mevent.Id;
            wme.x = mevent.X;
            wme.y = mevent.Y;
            wme.z = mevent.Z;
            wme.bstate = (uint)mevent.State;
            CursesMethods.ungetmouse(ref wme);
        }

        public static MouseState MouseMask(MouseState mask)
        {
            MouseState dummy;
            return MouseMask(mask, out dummy);
        }

        public static MouseState MouseMask(MouseState mask, out MouseState oldmask)
        {
            uint tmpMask = 0;
            uint outMask = CursesMethods.mousemask((uint)mask, out tmpMask);
            oldmask = (MouseState)tmpMask;
            return (MouseState)outMask;
        }

        public static int SetMouseInterval(int wait)
        {
            return CursesMethods.mouseinterval(wait);
        }
#endif

        public static void DoUpdate()
        {
            CursesMethods.doupdate();
        }

        public static void TraceOn()
        {
            CursesMethods.traceon();
        }

        public static void TraceOff()
        {
            CursesMethods.traceoff();
        }

		public static void SendSignalToStop()
		{
			CursesMethods.sendsigtstp ();
		}

        public static string UnCtrl(uint c)
        {
            return CursesMethods.unctrl(c);
        }

        public static void Filter()
        {
            CursesMethods.filter();
        }

        public static void UseEnv(bool x)
        {
            CursesMethods.use_env(x);
        }

        public static void DelayOutput(int ms)
        {
            CursesMethods.delay_output(ms);
        }

        public static int Baudrate
        {
            get { return CursesMethods.baudrate(); }
        }

        public static char EraseChar
        {
            get { return CursesMethods.erasechar(); }
        }

        public static char KillChar
        {
            get { return CursesMethods.killchar(); }
        }

        public static uint TermAttrs
        {
            get { return CursesMethods.termattrs(); }
        }

        public static bool HasHwInsDelChar
        {
            get { return CursesMethods.has_ic(); }
        }

        public static bool HasHwInsDelLine
        {
            get { return CursesMethods.has_il(); }
        }

        public static string TerminalName
        {
            get { return CursesMethods.termname(); }
        }

        public static string TerminalLongName
        {
            get { return CursesMethods.longname(); }
        }

        public static void ScreenDump(string filename)
        {
            CursesMethods.scr_dump(filename);
        }

        public static void ScreenInit(string filename)
        {
            CursesMethods.scr_init(filename);
        }

        public static void ScreenRestore(string filename)
        {
            CursesMethods.scr_restore(filename);
        }

        public static void ScreenSet(string filename)
        {
            CursesMethods.scr_set(filename);
        }
    }
}
