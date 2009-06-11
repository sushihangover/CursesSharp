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
            if (NativeMethods.wrap_addch((byte)ch) != 0)
                throw new CursesException("addch() failed.");
        }

        public void AddCh(uint ch)
        {
            if (NativeMethods.wrap_addch(ch) != 0)
                throw new CursesException("addch() failed.");
        }

        public void MvAddCh(int y, int x, char ch)
        {
            if (NativeMethods.wrap_mvaddch(y, x, (byte)ch) != 0)
                throw new CursesException("mvaddch() failed.");
        }

        public void MvAddCh(int y, int x, uint ch)
        {
            if (NativeMethods.wrap_mvaddch(y, x, ch) != 0)
                throw new CursesException("mvaddch() failed.");
        }

        public void AddStr(string str)
        {
            if (Screen.HasWideChar)
            {
                if (NativeMethods.wrap_addnwstr(str, str.Length) != 0)
                    throw new CursesException("addnwstr() failed.");
            }
            else
            {
                if (NativeMethods.wrap_addnstr(str, str.Length) != 0)
                    throw new CursesException("addnstr() failed.");
            }
        }

        public void MvAddStr(int y, int x, string str)
        {
            if (Screen.HasWideChar)
            {
                if (NativeMethods.wrap_mvaddnwstr(y, x, str, str.Length) != 0)
                    throw new CursesException("mvaddnwstr() failed.");
            }
            else
            {
                if (NativeMethods.wrap_mvaddnstr(y, x, str, str.Length) != 0)
                    throw new CursesException("mvaddnstr() failed.");
            }
        }

        public void AttrSet(uint attr)
        {
            if (NativeMethods.wrap_attrset(attr) != 0)
                throw new CursesException("attrset() failed.");
        }

        public void Erase()
        {
            if (NativeMethods.wrap_erase() != 0)
                throw new CursesException("erase() failed.");
        }

        public int GetCh()
        {
            return NativeMethods.wrap_getch();
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
                NativeMethods.wrap_timeout(value);
            }
        }

        public void Move(int y, int x)
        {
            if (NativeMethods.wrap_move(y, x) != 0)
                throw new CursesException("move() failed.");
        }

        public void Refresh()
        {
            if (NativeMethods.wrap_refresh() != 0)
                throw new CursesException("refresh() failed.");
        }

        #endregion
    }
}
