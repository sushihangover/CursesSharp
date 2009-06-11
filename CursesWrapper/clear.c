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
  Name:								clear

  Synopsis:
	int clear(void);
	int wclear(WINDOW *win);
	int erase(void);
	int werase(WINDOW *win);
	int clrtobot(void);
	int wclrtobot(WINDOW *win);
	int clrtoeol(void);
	int wclrtoeol(WINDOW *win);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	clear					Y	Y	Y
	wclear					Y	Y	Y
	erase					Y	Y	Y
	werase					Y	Y	Y
	clrtobot				Y	Y	Y
	wclrtobot				Y	Y	Y
	clrtoeol				Y	Y	Y
	wclrtoeol				Y	Y	Y
*/

int 
wrap_wclear(WINDOW *win)
{
	return wclear(win);
}

int 
wrap_werase(WINDOW *win)
{
	return werase(win);
}

int 
wrap_wclrtobot(WINDOW *win)
{
	return wclrtobot(win);
}

int 
wrap_wclrtoeol(WINDOW *win)
{
	return wclrtoeol(win);
}
