using System;

namespace Curses
{
    internal class StdWindow : IWindow
    {
        private IntPtr stdscr;

        internal StdWindow(IntPtr stdscr)
        {
            this.stdscr = stdscr;
        }

        #region IWindow Members

        public void AddCh(char ch)
        {
            if (NativeMethods.wrap_waddch(this.stdscr, (byte)ch) != 0)
                throw new CursesException("addch() failed.");
        }

        public void AddCh(uint ch)
        {
            if (NativeMethods.wrap_waddch(this.stdscr, ch) != 0)
                throw new CursesException("addch() failed.");
        }

        public void MvAddCh(int y, int x, char ch)
        {
            if (NativeMethods.wrap_mvwaddch(this.stdscr, y, x, (byte)ch) != 0)
                throw new CursesException("mvaddch() failed.");
        }

        public void MvAddCh(int y, int x, uint ch)
        {
            if (NativeMethods.wrap_mvwaddch(this.stdscr, y, x, ch) != 0)
                throw new CursesException("mvaddch() failed.");
        }

        public void AddStr(string str)
        {
            if (Screen.HasWideChar)
            {
                if (NativeMethods.wrap_waddnwstr(this.stdscr, str, str.Length) != 0)
                    throw new CursesException("addnwstr() failed.");
            }
            else
            {
                if (NativeMethods.wrap_waddnstr(this.stdscr, str, str.Length) != 0)
                    throw new CursesException("addnstr() failed.");
            }
        }

        public void MvAddStr(int y, int x, string str)
        {
            if (Screen.HasWideChar)
            {
                if (NativeMethods.wrap_mvwaddnwstr(this.stdscr, y, x, str, str.Length) != 0)
                    throw new CursesException("mvaddnwstr() failed.");
            }
            else
            {
                if (NativeMethods.wrap_mvwaddnstr(this.stdscr, y, x, str, str.Length) != 0)
                    throw new CursesException("mvaddnstr() failed.");
            }
        }

        public void AttrSet(uint attr)
        {
            if (NativeMethods.wrap_wattrset(this.stdscr, attr) != 0)
                throw new CursesException("attrset() failed.");
        }

        public void Erase()
        {
            if (NativeMethods.wrap_werase(this.stdscr) != 0)
                throw new CursesException("erase() failed.");
        }

        public int GetCh()
        {
            return NativeMethods.wrap_wgetch(this.stdscr);
        }

        public bool Keypad
        {
            set
            {
                if (NativeMethods.wrap_keypad(this.stdscr, value) != 0)
                    throw new CursesException("keypad() failed.");
            }
        }

        public bool NoDelay
        {
            set
            {
                if (NativeMethods.wrap_nodelay(this.stdscr, value) != 0)
                    throw new CursesException("nodelay() failed.");
            }
        }

        public int Timeout
        {
            set
            {
                NativeMethods.wrap_wtimeout(this.stdscr, value);
            }
        }

        public void Move(int y, int x)
        {
            if (NativeMethods.wrap_wmove(this.stdscr, y, x) != 0)
                throw new CursesException("move() failed.");
        }

        public void Refresh()
        {
            if (NativeMethods.wrap_wrefresh(this.stdscr) != 0)
                throw new CursesException("refresh() failed.");
        }

        #endregion
    }
}
