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

#include "wrapper.h"


WRAP_API WINDOW *
wrap_newpad(int nlines, int ncols)
{
	return newpad(nlines, ncols);
}

WRAP_API WINDOW *
wrap_subpad(WINDOW *orig, int nlines, int ncols, int begy, int begx)
{
	return subpad(orig, nlines, ncols, begy, begx);
}

WRAP_API int
wrap_prefresh(WINDOW *win, int py, int px, int sy1, int sx1, int sy2, int sx2)
{
	return prefresh(win, py, px, sy1, sx1, sy2, sx2);
}

WRAP_API int
wrap_pnoutrefresh(WINDOW *win, int py, int px, int sy1, int sx1, int sy2, int sx2)
{
	return pnoutrefresh(win, py, px, sy1, sx1, sy2, sx2);
}

WRAP_API int
wrap_pechochar(WINDOW *pad, unsigned int ch)
{
	return pechochar(pad, ch);
}

