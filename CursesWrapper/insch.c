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
  Name:								insch

  Synopsis:
	int insch(chtype ch);
	int winsch(WINDOW *win, chtype ch);
	int mvinsch(int y, int x, chtype ch);
	int mvwinsch(WINDOW *win, int y, int x, chtype ch);

	int insrawch(chtype ch);
	int winsrawch(WINDOW *win, chtype ch);
	int mvinsrawch(int y, int x, chtype ch);
	int mvwinsrawch(WINDOW *win, int y, int x, chtype ch);

	int ins_wch(const cchar_t *wch);
	int wins_wch(WINDOW *win, const cchar_t *wch);
	int mvins_wch(int y, int x, const cchar_t *wch);
	int mvwins_wch(WINDOW *win, int y, int x, const cchar_t *wch);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	insch					Y	Y	Y
	winsch					Y	Y	Y
	mvinsch					Y	Y	Y
	mvwinsch				Y	Y	Y
	insrawch				-	-	-
	winsrawch				-	-	-
	ins_wch					Y
	wins_wch				Y
	mvins_wch				Y
	mvwins_wch				Y
*/

int 
wrap_winsch(WINDOW *win, unsigned int ch)
{
	return winsch(win, ch);
}

int 
wrap_mvwinsch(WINDOW *win, int y, int x, unsigned int ch)
{
	return mvwinsch(win, y, x, ch);
}

