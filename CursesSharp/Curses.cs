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
    /// <param name="win"></param>
    /// <param name="ncols"></param>
    /// <returns></returns>
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

        public static Window StdScr
        {
            get { return stdscr; }
        }

        public static int Lines
        {
            get { return CursesMethods.LINES(); }
        }

        public static int Cols
        {
            get { return CursesMethods.COLS(); }
        }

        public static int Colors
        {
            get { return CursesMethods.COLORS(); }
        }

        public static int ColorPairs
        {
            get { return CursesMethods.COLOR_PAIRS(); }
        }

        public static int TabSize
        {
            get { return CursesMethods.TABSIZE(); }
        }

        public static uint COLOR_PAIR(int n)
        {
            return CursesMethods.COLOR_PAIR(n);
        }

        public static short PAIR_NUMBER(uint n)
        {
            return CursesMethods.PAIR_NUMBER(n);
        }

        public static Window InitScr()
        {
            if (stdscr != null)
                throw new InvalidOperationException("Curses is already initialized.");

            stdscr = Window.WrapHandle(CursesMethods.initscr());
            return stdscr;
        }

        public static void EndWin()
        {
            if (stdscr == null)
                throw new InvalidOperationException("Curses is not initialized.");
            stdscr.Dispose();
            CursesMethods.endwin();
            stdscr = null;
        }

        public static bool IsEndWin
        {
            get
            {
                return CursesMethods.isendwin();
            }
        }

        public static void ResizeTerm(int nlines, int ncols)
        {
            CursesMethods.resize_term(nlines, ncols);
        }

        public static void Beep()
        {
            CursesMethods.beep();
        }

        public static void Flash()
        {
            CursesMethods.flash();
        }

        public static void StartColor()
        {
            CursesMethods.start_color();
        }

        public static void InitPair(short color, short fg, short bg)
        {
            CursesMethods.init_pair(color, fg, bg);
        }

        public static void InitColor(short color, short red, short green, short blue)
        {
            CursesMethods.init_color(color, red, green, blue);
        }

        public static void ColorContent(short color, out short red, out short green, out short blue)
        {
            CursesMethods.color_content(color, out red, out green, out blue);
        }

        public static void PairContent(short color, out short fg, out short bg)
        {
            CursesMethods.pair_content(color, out fg, out bg);
        }

        public static bool HasColors
        {
            get
            {
                return CursesMethods.has_colors();
            }
        }

        public static bool CanChangeColor
        {
            get
            {
                return CursesMethods.can_change_color();
            }
        }

        public static void AssumeDefaultColors(int f, int b)
        {
            CursesMethods.assume_default_colors(f, b);
        }

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
