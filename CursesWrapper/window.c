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

/*
  Name:								window

  Synopsis:
	WINDOW *newwin(int nlines, int ncols, int begy, int begx);
  	WINDOW *derwin(WINDOW* orig, int nlines, int ncols,
		int begy, int begx);
	WINDOW *subwin(WINDOW* orig, int nlines, int ncols,
		int begy, int begx);
	WINDOW *dupwin(WINDOW *win);
	int delwin(WINDOW *win);
	int mvwin(WINDOW *win, int y, int x);
	int mvderwin(WINDOW *win, int pary, int parx);
	int syncok(WINDOW *win, bool bf);
	void wsyncup(WINDOW *win);
	void wcursyncup(WINDOW *win);
	void wsyncdown(WINDOW *win);

  Return Value:
	newwin(), subwin(), derwin() and dupwin() return a pointer
	to the new window, or NULL on failure. delwin(), mvwin(),
	mvderwin() and syncok() return OK or ERR. wsyncup(),
	wcursyncup() and wsyncdown() return nothing.

  Errors:
	It is an error to call resize_window() before calling initscr().
	Also, an error will be generated if we fail to create a newly
	sized replacement window for curscr, or stdscr. This could
	happen when increasing the window size. NOTE: If this happens,
	the previously successfully allocated windows are left alone;
	i.e., the resize is NOT cancelled for those windows.

  Portability				     X/Open    BSD    SYS V
	newwin					Y	Y	Y
	delwin					Y	Y	Y
	mvwin					Y	Y	Y
	subwin					Y	Y	Y
	derwin					Y	-	Y
	mvderwin				Y	-	Y
	dupwin					Y	-      4.0
	wsyncup					Y	-      4.0
	syncok					Y	-      4.0
	wcursyncup				Y	-      4.0
	wsyncdown				Y	-      4.0
	resize_window				-	-	-
	wresize					-	-	-
	PDC_makelines				-	-	-
	PDC_makenew				-	-	-
	PDC_sync				-	-	-
*/

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
	return syncok(win, bf);
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

