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
  Name:								delch

  Synopsis:
	int delch(void);
	int wdelch(WINDOW *win);
	int mvdelch(int y, int x);
	int mvwdelch(WINDOW *win, int y, int x);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	delch					Y	Y	Y
	wdelch					Y	Y	Y
	mvdelch					Y	Y	Y
	mvwdelch				Y	Y	Y
*/

int 
wrap_wdelch(WINDOW *win)
{
	return wdelch(win);
}

int 
wrap_mvwdelch(WINDOW *win, int y, int x)
{
	return mvwdelch(win, y, x);
}

