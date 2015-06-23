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
    public sealed class Pad : WindowBase
    {
        public Pad(int nlines, int ncols)
        {
            this.Handle = CursesMethods.newpad(nlines, ncols);
        }

        private Pad(IntPtr winptr, bool ownsPtr)
            : base(winptr, ownsPtr)
        {
        }

        public override void EchoChar(char ch)
        {
            CursesMethods.pechochar(this.Handle, (byte)ch);
        }

        public override void EchoChar(uint ch)
        {
            CursesMethods.pechochar(this.Handle, ch);
        }

        public void Refresh(int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            CursesMethods.prefresh(this.Handle, py, px, sy1, sx1, sy2, sx2);
        }

        public void NoOutRefresh(int py, int px, int sy1, int sx1, int sy2, int sx2)
        {
            CursesMethods.pnoutrefresh(this.Handle, py, px, sy1, sx1, sy2, sx2);
        }

        public Pad SubPad(int nlines, int ncols, int begy, int begx)
        {
            IntPtr newptr = CursesMethods.subpad(this.Handle, nlines, ncols, begy, begx);
            return new Pad(newptr, true);
        }
    }
}
