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


WRAP_API void
wrap_getyx(WINDOW *win, int *y, int *x)
{
	getyx(win, *y, *x);
}

WRAP_API void
wrap_getparyx(WINDOW *win, int *y, int *x)
{
	getparyx(win, *y, *x);
}

WRAP_API void
wrap_getbegyx(WINDOW *win, int *y, int *x)
{
	getbegyx(win, *y, *x);
}

WRAP_API void
wrap_getmaxyx(WINDOW *win, int *y, int *x)
{
	getmaxyx(win, *y, *x);
}
