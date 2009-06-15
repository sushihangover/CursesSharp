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
wrap_touchwin(WINDOW *win)
{
	return touchwin(win);
}

WRAP_API int
wrap_touchline(WINDOW *win, int start, int count)
{
	return touchline(win, start, count);
}

WRAP_API int
wrap_untouchwin(WINDOW *win)
{
	return untouchwin(win);
}

WRAP_API int
wrap_wtouchln(WINDOW *win, int y, int n, int changed)
{
	return wtouchln(win, y, n, changed);
}

WRAP_API int
wrap_is_linetouched(WINDOW *win, int line)
{
	return is_linetouched(win, line);
}

WRAP_API int
wrap_is_wintouched(WINDOW *win)
{
	return is_wintouched(win);
}
