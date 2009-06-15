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
wrap_newwin(int nlines, int ncols, int begy, int begx)
{
	return newwin(nlines, ncols, begy, begx);
}

WRAP_API WINDOW *
wrap_derwin(WINDOW* orig, int nlines, int ncols, int begy, int begx)
{
	return derwin(orig, nlines, ncols, begy, begx);
}

WRAP_API WINDOW *
wrap_subwin(WINDOW* orig, int nlines, int ncols, int begy, int begx)
{
	return subwin(orig, nlines, ncols, begy, begx);
}

WRAP_API WINDOW *
wrap_dupwin(WINDOW *win)
{
	return dupwin(win);
}

WRAP_API int
wrap_delwin(WINDOW *win)
{
	return delwin(win);
}

WRAP_API int
wrap_mvwin(WINDOW *win, int y, int x)
{
	return mvwin(win, y, x);
}

WRAP_API int
wrap_mvderwin(WINDOW *win, int pary, int parx)
{
	return mvderwin(win, pary, parx);
}

WRAP_API int
wrap_syncok(WINDOW *win, int bf)
{
	return syncok(win, (bool)bf);
}

WRAP_API void
wrap_wsyncup(WINDOW *win)
{
	wsyncup(win);
}

WRAP_API void
wrap_wcursyncup(WINDOW *win)
{
	wcursyncup(win);
}

WRAP_API void
wrap_wsyncdown(WINDOW *win)
{
	wsyncdown(win);
}

