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
wrap_wattroff(WINDOW *win, unsigned int attrs)
{
	return wattroff(win, attrs);
}

WRAP_API int
wrap_wattron(WINDOW *win, unsigned int attrs)
{
	return wattron(win, attrs);
}

WRAP_API int
wrap_wattrset(WINDOW *win, unsigned int attrs)
{
	return wattrset(win, attrs);
}

WRAP_API int
wrap_wstandend(WINDOW* win)
{
	return wstandend(win);
}

WRAP_API int
wrap_wstandout(WINDOW* win)
{
	return wstandout(win);
}

WRAP_API int
wrap_wcolor_set(WINDOW *win, short color_pair)
{
	return wcolor_set(win, color_pair, 0);
}

WRAP_API int
wrap_wattr_get(WINDOW *win, unsigned int *attrs, short *color_pair)
{
	return wattr_get(win, (attr_t*)attrs, color_pair, 0);
}

WRAP_API int
wrap_wchgat(WINDOW *win, int n, unsigned int attr, short color)
{
	return wchgat(win, n, attr, color, 0);
}

WRAP_API int
wrap_mvwchgat(WINDOW *win, int y, int x, int n, unsigned int attr, short color)
{
	return mvwchgat(win, y, x, n, attr, color, 0);
}

