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
  Name:								attr

  Synopsis:
	int attroff(chtype attrs);
	int wattroff(WINDOW *win, chtype attrs);
	int attron(chtype attrs);
	int wattron(WINDOW *win, chtype attrs);
	int attrset(chtype attrs);
	int wattrset(WINDOW *win, chtype attrs);
	int standend(void);
	int wstandend(WINDOW *win);
	int standout(void);
	int wstandout(WINDOW *win);

	int color_set(short color_pair, void *opts);
	int wcolor_set(WINDOW *win, short color_pair, void *opts);

	int attr_get(attr_t *attrs, short *color_pair, void *opts);
	int attr_off(attr_t attrs, void *opts);
	int attr_on(attr_t attrs, void *opts);
	int attr_set(attr_t attrs, short color_pair, void *opts);
	int wattr_get(WINDOW *win, attr_t *attrs, short *color_pair,
		void *opts);
	int wattr_off(WINDOW *win, attr_t attrs, void *opts);
	int wattr_on(WINDOW *win, attr_t attrs, void *opts);
	int wattr_set(WINDOW *win, attr_t attrs, short color_pair,
		void *opts);

	int chgat(int n, attr_t attr, short color, const void *opts);
	int mvchgat(int y, int x, int n, attr_t attr, short color,
		const void *opts);
	int mvwchgat(WINDOW *win, int y, int x, int n, attr_t attr,
		short color, const void *opts);
	int wchgat(WINDOW *win, int n, attr_t attr, short color,
		const void *opts);

	chtype getattrs(WINDOW *win);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	attroff					Y	Y	Y
	wattroff				Y	Y	Y
	attron					Y	Y	Y
	wattron					Y	Y	Y
	attrset					Y	Y	Y
	wattrset				Y	Y	Y
	standend				Y	Y	Y
	wstandend				Y	Y	Y
	standout				Y	Y	Y
	wstandout				Y	Y	Y
	color_set				Y
	wcolor_set				Y
	attr_get				Y
	wattr_get				Y
	attr_on					Y
	wattr_on				Y
	attr_off				Y
	wattr_off				Y
	attr_set				Y
	wattr_set				Y
	chgat					Y
	wchgat					Y
	mvchgat					Y
	mvwchgat				Y
	getattrs				-
*/

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

