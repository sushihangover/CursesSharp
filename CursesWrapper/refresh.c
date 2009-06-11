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
  Name:								refresh

  Synopsis:
	int refresh(void);
	int wrefresh(WINDOW *win);
	int wnoutrefresh(WINDOW *win);
	int doupdate(void);
	int redrawwin(WINDOW *win);
	int wredrawln(WINDOW *win, int beg_line, int num_lines);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	refresh					Y	Y	Y
	wrefresh				Y	Y	Y
	wnoutrefresh				Y	Y	Y
	doupdate				Y	Y	Y
	redrawwin				Y	-      4.0
	wredrawln				Y	-      4.0
*/

int 
wrap_wrefresh(WINDOW *win)
{
	return wrefresh(win);
}

int 
wrap_wnoutrefresh(WINDOW *win)
{
	return wnoutrefresh(win);
}

int 
wrap_doupdate(void)
{
	return doupdate();
}

int 
wrap_redrawwin(WINDOW *win)
{
	return redrawwin(win);
}

int 
wrap_wredrawln(WINDOW *win, int beg_line, int num_lines)
{
	return wredrawln(win, beg_line, num_lines);
}
