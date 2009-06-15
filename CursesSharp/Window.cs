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
    public sealed class Window : WindowBase
    {
        internal static Window WrapHandle(IntPtr handle)
        {
            return new Window(handle, false);
        }

        public Window(int nlines, int ncols, int begy, int begx)
        {
            this.Handle = CursesMethods.newwin(nlines, ncols, begy, begx);
        }

        private Window(IntPtr handle, bool ownsPtr)
            : base(handle, ownsPtr)
        {
        }

        public void Refresh()
        {
            CursesMethods.wrefresh(this.Handle);
        }

        public void NoOutRefresh()
        {
            CursesMethods.wnoutrefresh(this.Handle);
        }

        public Window DerWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = CursesMethods.derwin(this.Handle, nlines, ncols, begy, begx);
            return new Window(newptr, true);
        }

        public Window SubWin(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = CursesMethods.subwin(this.Handle, nlines, ncols, begy, begx);
            return new Window(newptr, true);
        }

        public Window DupWin()
        {
            IntPtr newptr = CursesMethods.dupwin(this.Handle);
            return new Window(newptr, true);
        }
    }
}
