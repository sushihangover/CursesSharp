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
    public class MouseEvent
    {
        private int id;
        private int x, y, z;
        private MouseState bstate;

        public MouseEvent()
        {
        }

        public MouseEvent(int id, int x, int y, int z, MouseState bstate)
        {
            this.id = id;
            this.x = x;
            this.y = y;
            this.z = z;
            this.bstate = bstate;
        }

        public int Id
        {
            get { return this.id; }
            internal set { this.id = value; }
        }

        public int X
        {
            get { return this.x; }
            internal set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            internal set { this.y = value; }
        }

        public int Z
        {
            get { return this.z; }
            internal set { this.z = value; }
        }

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
        private static Window stdscr = null;

        /// <summary>
        /// Represents the default window that is created during library initialization.
        /// </summary>
        /// <value>Gets the default window.</value>
        public static Window StdScr
        {
            get { return stdscr; }
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
        /// It should be the first function called as most other functions
        /// require the library be initialized.
        /// </summary>
        /// 
        /// <remarks>
        /// The Window object returned can be later retrieved using 
        /// <see cref="StdScr"/> property.
        /// 
        /// </remarks>
        /// <returns>The default Window object</returns>
        public static Window InitScr()
        {
            if (stdscr != null)
                throw new InvalidOperationException("Curses is already initialized.");

            stdscr = Window.WrapHandle(CursesMethods.initscr());
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
            stdscr = null;
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
        /// Sounds an audible alarm on the terminal, if possible; otherwise 
        /// it flashes the screen (visible bell).
        /// If neither alter is possible, nothing happens.
        /// </summary>
        public static void Beep()
        {
            CursesMethods.beep();
        }

        /// <summary>
        /// Flashes the screen, and if that is not possible, sounds the alert.
        /// If neither alter is possible, nothing happens.
        /// </summary>
        public static void Flash()
        {
            CursesMethods.flash();
        }

        /// <summary>
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
        /// </summary>
        public static void StartColor()
        {
            CursesMethods.start_color();
        }

        /// <summary>
        /// Changes the definition of a color-pair. If the color-pair was 
        /// previously initialized, the screen is refreshed and all occurences
        /// of that color-pair are changed to the new definition.
        /// </summary>
        /// <remarks>
        /// For portable applications the value of <paramref name="color"/> 
        /// must be between 1 and <see cref="ColorPairs"/> - 1, and the value 
        /// of <paramref name="fg"/> and <paramref name="bg"/> must be
        /// between 0 and <see cref="Colors"/>.
        /// </remarks>
        /// <param name="color">Number of the color-pair to be changed.</param>
        /// <param name="fg">Foreground color number.</param>
        /// <param name="bg">Background color number.</param>
        public static void InitPair(short color, short fg, short bg)
        {
            CursesMethods.init_pair(color, fg, bg);
        }

        /// <summary>
        /// Changes the definition of a color. When it is used, all occurences
        /// of that color on the screen immediately change to the new definition.
        /// </summary>
        /// <remarks>
        /// The value of <paramref name="color"/> must be between 0 and 
        /// <see cref="Colors"/>, and the value of <paramref name="red"/>,
        /// <paramref name="green"/> and <paramref name="blue"/> must be
        /// between 0 and 1000.
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
        /// in a color. Requires three references of variables for storing the
        /// information about amounts of the components in that color.
        /// the components.
        /// </summary>
        /// <remarks>
        /// The value of <paramref name="color"/> must be between 0 and 
        /// <see cref="Colors"/>. The values that are stored in 
        /// <paramref name="red"/>, <paramref name="green"/> and 
        /// <paramref name="blue"/> are between 0 and 1000.
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
        /// Requires two references of variables for storing the foreground
        /// and the background color numbers.
        /// </summary>
        /// <remarks>
        /// The value of <paramref name="color"/> must be between 1 and 
        /// <see cref="ColorPairs"/> - 1. The values that are stored in 
        /// <paramref name="fg"/> and <paramref name="bg"/> are between
        /// 0 and <see cref="Colors"/>.
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
        /// Changes the definition of a color-pair number 0. The screen is 
        /// refreshed and all occurences of color-pair number 0 are changed 
        /// to the new definition.
        /// </summary>
        /// <remarks>
        /// The value of <paramref name="fg"/> and <paramref name="bg"/> must 
        /// be between 0 and <see cref="Colors"/>.
        /// </remarks>
        /// <param name="fg">Foreground color number.</param>
        /// <param name="bg">Background color number.</param>
        public static void AssumeDefaultColors(int fg, int bg)
        {
            CursesMethods.assume_default_colors(fg, bg);
        }

        /// <summary>
        /// Enables the use of default colors. If this method is first called,
        /// the color number -1 can also be used in methods that require color
        /// numbers as arguments.
        /// </summary>
        public static void UseDefaultColors()
        {
            CursesMethods.use_default_colors();
        }

        public static void UngetCh(int ch)
        {
            CursesMethods.ungetch(ch);
        }

        public static void FlushInput()
        {
            CursesMethods.flushinp();
        }

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

        public static void HalfDelayMode(int tenths)
        {
            CursesMethods.halfdelay(tenths);
        }

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

        public static void SaveProgramMode()
        {
            CursesMethods.def_prog_mode();
        }

        public static void SaveShellMode()
        {
            CursesMethods.def_shell_mode();
        }

        public static void ResetProgramMode()
        {
            CursesMethods.reset_prog_mode();
        }

        public static void ResetShellMode()
        {
            CursesMethods.reset_shell_mode();
        }

        public static void ResetTty()
        {
            CursesMethods.resetty();
        }

        public static void SaveTty()
        {
            CursesMethods.savetty();
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

        public static void NapMs(int ms)
        {
            CursesMethods.napms(ms);
        }

        public static int CursorVisibility
        {
            set { CursesMethods.curs_set(value); }
        }

        public static string KeyName(int key)
        {
            return CursesMethods.keyname(key);
        }

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
