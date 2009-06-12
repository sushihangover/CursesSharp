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
  Name:								touch

  Synopsis:
	int touchwin(WINDOW *win);
	int touchline(WINDOW *win, int start, int count);
	int untouchwin(WINDOW *win);
	int wtouchln(WINDOW *win, int y, int n, int changed);
	bool is_linetouched(WINDOW *win, int line);
	bool is_wintouched(WINDOW *win);

  Return Value:
	All functions return OK on success and ERR on error except
	is_wintouched() and is_linetouched().

  Portability				     X/Open    BSD    SYS V
	touchwin				Y	Y	Y
	touchline				Y	-      3.0
	untouchwin				Y	-      4.0
	wtouchln				Y	Y	Y
	is_linetouched				Y	-      4.0
	is_wintouched				Y	-      4.0
*/

int 
wrap_touchwin(WINDOW *win)
{
	return touchwin(win);
}

int 
wrap_touchline(WINDOW *win, int start, int count)
{
	return touchline(win, start, count);
}

int 
wrap_untouchwin(WINDOW *win)
{
	return untouchwin(win);
}

int 
wrap_wtouchln(WINDOW *win, int y, int n, int changed)
{
	return wtouchln(win, y, n, changed);
}

int 
wrap_is_linetouched(WINDOW *win, int line)
{
	return is_linetouched(win, line);
}

int 
wrap_is_wintouched(WINDOW *win)
{
	return is_wintouched(win);
}
