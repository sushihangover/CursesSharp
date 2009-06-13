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
  Name:								addch

  Synopsis:
	int addch(const chtype ch);
	int waddch(WINDOW *win, const chtype ch);
	int mvaddch(int y, int x, const chtype ch);
	int mvwaddch(WINDOW *win, int y, int x, const chtype ch);
	int echochar(const chtype ch);
	int wechochar(WINDOW *win, const chtype ch);

	int add_wch(const cchar_t *wch);
	int wadd_wch(WINDOW *win, const cchar_t *wch);
	int mvadd_wch(int y, int x, const cchar_t *wch);
	int mvwadd_wch(WINDOW *win, int y, int x, const cchar_t *wch);
	int echo_wchar(const cchar_t *wch);
	int wecho_wchar(WINDOW *win, const cchar_t *wch);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	addch					Y	Y	Y
	waddch					Y	Y	Y
	mvaddch					Y	Y	Y
	mvwaddch				Y	Y	Y
	echochar				Y	-      3.0
	wechochar				Y	-      3.0
	addrawch				-	-	-
	waddrawch				-	-	-
	mvaddrawch				-	-	-
	mvwaddrawch				-	-	-
	add_wch					Y
	wadd_wch				Y
	mvadd_wch				Y
	mvwadd_wch				Y
	echo_wchar				Y
	wecho_wchar				Y
*/

int
wrap_waddch(WINDOW *win, unsigned int ch)
{
	return waddch(win, ch);
}

int
wrap_mvwaddch(WINDOW *win, int y, int x, unsigned int ch)
{
	return mvwaddch(win, y, x, ch);
}

int
wrap_wechochar(WINDOW *win, unsigned int ch)
{
	return wechochar(win, ch);
}
