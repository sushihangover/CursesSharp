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
  Name:								inchstr

  Synopsis:
	int inchstr(chtype *ch);
	int inchnstr(chtype *ch, int n);
	int winchstr(WINDOW *win, chtype *ch);
	int winchnstr(WINDOW *win, chtype *ch, int n);
	int mvinchstr(int y, int x, chtype *ch);
	int mvinchnstr(int y, int x, chtype *ch, int n);
	int mvwinchstr(WINDOW *, int y, int x, chtype *ch);
	int mvwinchnstr(WINDOW *, int y, int x, chtype *ch, int n);

	int in_wchstr(cchar_t *wch);
	int in_wchnstr(cchar_t *wch, int n);
	int win_wchstr(WINDOW *win, cchar_t *wch);
	int win_wchnstr(WINDOW *win, cchar_t *wch, int n);
	int mvin_wchstr(int y, int x, cchar_t *wch);
	int mvin_wchnstr(int y, int x, cchar_t *wch, int n);
	int mvwin_wchstr(WINDOW *win, int y, int x, cchar_t *wch);
	int mvwin_wchnstr(WINDOW *win, int y, int x, cchar_t *wch, int n);

  Return Value:
	All functions return the number of elements read, or ERR on 
	error.

  Portability				     X/Open    BSD    SYS V
	inchstr					Y	-      4.0
	winchstr				Y	-      4.0
	mvinchstr				Y	-      4.0
	mvwinchstr				Y	-      4.0
	inchnstr				Y	-      4.0
	winchnstr				Y	-      4.0
	mvinchnstr				Y	-      4.0
	mvwinchnstr				Y	-      4.0
	in_wchstr				Y
	win_wchstr				Y
	mvin_wchstr				Y
	mvwin_wchstr				Y
	in_wchnstr				Y
	win_wchnstr				Y
	mvin_wchnstr				Y
	mvwin_wchnstr				Y
*/

WRAP_API int
wrap_winchnstr(WINDOW *win, unsigned int *ch, int n)
{
	return winchnstr(win, ch, n);
}

WRAP_API int
wrap_mvwinchnstr(WINDOW *win, int y, int x, unsigned int *ch, int n)
{
	return mvwinchnstr(win, y, x, ch, n);
}
