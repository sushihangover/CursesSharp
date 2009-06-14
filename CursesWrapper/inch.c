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
  Name:								inch

  Synopsis:
	chtype inch(void);
	chtype winch(WINDOW *win);
	chtype mvinch(int y, int x);
	chtype mvwinch(WINDOW *win, int y, int x);

	int in_wch(cchar_t *wcval);
	int win_wch(WINDOW *win, cchar_t *wcval);
	int mvin_wch(int y, int x, cchar_t *wcval);
	int mvwin_wch(WINDOW *win, int y, int x, cchar_t *wcval);

  Description:
	The inch() functions retrieve the character and attribute from 
	the current or specified window position, in the form of a 
	chtype. If a NULL window is specified, (chtype)ERR is returned.

	The in_wch() functions are the wide-character versions; instead 
	of returning a chtype, they store a cchar_t at the address 
	specified by wcval, and return OK or ERR. (No value is stored 
	when ERR is returned.) Note that in PDCurses, chtype and cchar_t 
	are the same.

  Portability				     X/Open    BSD    SYS V
	inch					Y	Y	Y
	winch					Y	Y	Y
	mvinch					Y	Y	Y
	mvwinch					Y	Y	Y
	in_wch					Y
	win_wch					Y
	mvin_wch				Y
	mvwin_wch				Y
*/

WRAP_API unsigned int 
wrap_winch(WINDOW *win)
{
	return winch(win);
}

WRAP_API unsigned int 
wrap_mvwinch(WINDOW *win, int y, int x)
{
	return mvwinch(win, y, x);
}

