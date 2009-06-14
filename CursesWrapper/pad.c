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
  Name:								pad

  Synopsis:
	WINDOW *newpad(int nlines, int ncols);
	WINDOW *subpad(WINDOW *orig, int nlines, int ncols,
		       int begy, int begx);
	int prefresh(WINDOW *win, int py, int px, int sy1, int sx1,
		     int sy2, int sx2);
	int pnoutrefresh(WINDOW *w, int py, int px, int sy1, int sx1,
			 int sy2, int sx2);
	int pechochar(WINDOW *pad, chtype ch);
	int pecho_wchar(WINDOW *pad, const cchar_t *wch);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	newpad					Y	-	Y
	subpad					Y	-	Y
	prefresh				Y	-	Y
	pnoutrefresh				Y	-	Y
	pechochar				Y	-      3.0
	pecho_wchar				Y
*/

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

