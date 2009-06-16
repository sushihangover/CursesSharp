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
wrap_wgetnstr(WINDOW *win, char *str, int n)
{
	return wgetnstr(win, str, n);
}

WRAP_API int
wrap_mvwgetnstr(WINDOW *win, int y, int x, char *str, int n)
{
	return mvwgetnstr(win, y, x, str, n);
}

#ifdef HAVE_USE_WIDECHAR

WRAP_API int
wrap_wgetn_wstr(WINDOW *win, wchar_t *wstr, int n)
{
	return wgetn_wstr(win, (wint_t*)wstr, n);
}

WRAP_API int
wrap_mvwgetn_wstr(WINDOW *win, int y, int x, wchar_t *wstr, int n)
{
	return mvwgetn_wstr(win, y, x, (wint_t*)wstr, n);
}

#endif

