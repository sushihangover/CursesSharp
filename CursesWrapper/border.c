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
  Name:								border

  Synopsis:
	int border(chtype ls, chtype rs, chtype ts, chtype bs, chtype tl, 
		   chtype tr, chtype bl, chtype br);
	int wborder(WINDOW *win, chtype ls, chtype rs, chtype ts, 
		    chtype bs, chtype tl, chtype tr, chtype bl, chtype br);
	int box(WINDOW *win, chtype verch, chtype horch);
	int hline(chtype ch, int n);
	int vline(chtype ch, int n);
	int whline(WINDOW *win, chtype ch, int n);
	int wvline(WINDOW *win, chtype ch, int n);
	int mvhline(int y, int x, chtype ch, int n);
	int mvvline(int y, int x, chtype ch, int n);
	int mvwhline(WINDOW *win, int y, int x, chtype ch, int n);
	int mvwvline(WINDOW *win, int y, int x, chtype ch, int n);

  Return Value:
	These functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	border					Y	-      4.0
	wborder					Y	-      4.0
	box					Y	Y	Y
	hline					Y	-      4.0
	vline					Y	-      4.0
	whline					Y	-      4.0
	wvline					Y	-      4.0
	mvhline					Y
	mvvline					Y
	mvwhline				Y
	mvwvline				Y
	border_set				Y
	wborder_set				Y
	box_set					Y
	hline_set				Y
	vline_set				Y
	whline_set				Y
	wvline_set				Y
	mvhline_set				Y
	mvvline_set				Y
	mvwhline_set				Y
	mvwvline_set				Y
*/

int 
wrap_wborder(WINDOW *win, unsigned int ls, unsigned int rs, unsigned int ts, 
			 unsigned int bs, unsigned int tl, unsigned int tr, unsigned int bl,
			 unsigned int br)
{
	return wborder(win, ls, rs, ts, bs, tl, tr, bl, br);
}

int 
wrap_box(WINDOW *win, unsigned int verch, unsigned int horch)
{
	return box(win, verch, horch);
}

int 
wrap_whline(WINDOW *win, unsigned int ch, int n)
{
	return whline(win, ch, n);
}

int 
wrap_wvline(WINDOW *win, unsigned int ch, int n)
{
	return wvline(win, ch, n);
}

int 
wrap_mvwhline(WINDOW *win, int y, int x, unsigned int ch, int n)
{
	return mvwhline(win, y, x, ch, n);
}

int 
wrap_mvwvline(WINDOW *win, int y, int x, unsigned int ch, int n)
{
	return mvwvline(win, y, x, ch, n);
}
