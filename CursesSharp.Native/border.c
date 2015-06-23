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


WRAP_API int
wrap_wborder(WINDOW *win, unsigned int ls, unsigned int rs, unsigned int ts, 
			 unsigned int bs, unsigned int tl, unsigned int tr, unsigned int bl,
			 unsigned int br)
{
	return wborder(win, ls, rs, ts, bs, tl, tr, bl, br);
}

WRAP_API int
wrap_box(WINDOW *win, unsigned int verch, unsigned int horch)
{
	return box(win, verch, horch);
}

WRAP_API int
wrap_whline(WINDOW *win, unsigned int ch, int n)
{
	return whline(win, ch, n);
}

WRAP_API int
wrap_wvline(WINDOW *win, unsigned int ch, int n)
{
	return wvline(win, ch, n);
}

WRAP_API int
wrap_mvwhline(WINDOW *win, int y, int x, unsigned int ch, int n)
{
	return mvwhline(win, y, x, ch, n);
}

WRAP_API int
wrap_mvwvline(WINDOW *win, int y, int x, unsigned int ch, int n)
{
	return mvwvline(win, y, x, ch, n);
}
