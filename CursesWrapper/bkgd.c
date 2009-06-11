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

#include <curses.h>

/*
  Name:								bkgd

  Synopsis:
	int bkgd(chtype ch);
	void bkgdset(chtype ch);
	chtype getbkgd(WINDOW *win);
	int wbkgd(WINDOW *win, chtype ch);
	void wbkgdset(WINDOW *win, chtype ch);

	int bkgrnd(const cchar_t *wch);
	void bkgrndset(const cchar_t *wch);
	int getbkgrnd(cchar_t *wch);
	int wbkgrnd(WINDOW *win, const cchar_t *wch);
	void wbkgrndset(WINDOW *win, const cchar_t *wch);
	int wgetbkgrnd(WINDOW *win, cchar_t *wch);

  Return Value:
	bkgd() and wbkgd() return OK, unless the window is NULL, in 
	which case they return ERR.

  Portability				     X/Open    BSD    SYS V
	bkgd					Y	-      4.0
	bkgdset					Y	-      4.0
	getbkgd					Y
	wbkgd					Y	-      4.0
	wbkgdset				Y	-      4.0
	bkgrnd					Y
	bkgrndset				Y
	getbkgrnd				Y
	wbkgrnd					Y
	wbkgrndset				Y
	wgetbkgrnd				Y
*/

unsigned int
wrap_getbkgd(WINDOW *win)
{
	return getbkgd(win);
}

int 
wrap_wbkgd(WINDOW *win, unsigned int ch)
{
	return wbkgd(win, ch);
}

void 
wrap_wbkgdset(WINDOW *win, unsigned int ch)
{
	return wbkgdset(win, ch);
}

