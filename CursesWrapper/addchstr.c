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
  Name:								addchstr

  Synopsis:
	int addchstr(const chtype *ch);
	int addchnstr(const chtype *ch, int n);
	int waddchstr(WINDOW *win, const chtype *ch);
	int waddchnstr(WINDOW *win, const chtype *ch, int n);
	int mvaddchstr(int y, int x, const chtype *ch);
	int mvaddchnstr(int y, int x, const chtype *ch, int n);
	int mvwaddchstr(WINDOW *, int y, int x, const chtype *ch);
	int mvwaddchnstr(WINDOW *, int y, int x, const chtype *ch, int n);

  Return Value:
	All functions return OK or ERR.

  Portability				     X/Open    BSD    SYS V
	addchstr				Y	-      4.0
	waddchstr				Y	-      4.0
	mvaddchstr				Y	-      4.0
	mvwaddchstr				Y	-      4.0
	addchnstr				Y	-      4.0
	waddchnstr				Y	-      4.0
	mvaddchnstr				Y	-      4.0
	mvwaddchnstr				Y	-      4.0
	add_wchstr				Y
	wadd_wchstr				Y
	mvadd_wchstr				Y
	mvwadd_wchstr				Y
	add_wchnstr				Y
	wadd_wchnstr				Y
	mvadd_wchnstr				Y
	mvwadd_wchnstr				Y
*/

int
wrap_waddchnstr(WINDOW *win, const unsigned int *chstr, int n)
{
	return waddchnstr(win, chstr, n);
}

int
wrap_mvwaddchnstr(WINDOW *win, int y, int x, const unsigned int *chstr, int n)
{
	return mvwaddchnstr(win, y, x, chstr, n);
}
