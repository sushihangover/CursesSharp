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


WRAP_API int
wrap_wrefresh(WINDOW *win)
{
	return wrefresh(win);
}

WRAP_API int
wrap_wnoutrefresh(WINDOW *win)
{
	return wnoutrefresh(win);
}

WRAP_API int
wrap_doupdate(void)
{
	return doupdate();
}

WRAP_API int
wrap_redrawwin(WINDOW *win)
{
	return redrawwin(win);
}

WRAP_API int
wrap_wredrawln(WINDOW *win, int beg_line, int num_lines)
{
	return wredrawln(win, beg_line, num_lines);
}
