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
  Name:								getstr

  Synopsis:
	int getstr(char *str);
	int wgetstr(WINDOW *win, char *str);
	int mvgetstr(int y, int x, char *str);
	int mvwgetstr(WINDOW *win, int y, int x, char *str);
	int getnstr(char *str, int n);
	int wgetnstr(WINDOW *win, char *str, int n);
	int mvgetnstr(int y, int x, char *str, int n);
	int mvwgetnstr(WINDOW *win, int y, int x, char *str, int n);

	int get_wstr(wint_t *wstr);
	int wget_wstr(WINDOW *win, wint_t *wstr);
	int mvget_wstr(int y, int x, wint_t *wstr);
	int mvwget_wstr(WINDOW *win, int, int, wint_t *wstr);
	int getn_wstr(wint_t *wstr, int n);
	int wgetn_wstr(WINDOW *win, wint_t *wstr, int n);
	int mvgetn_wstr(int y, int x, wint_t *wstr, int n);
	int mvwgetn_wstr(WINDOW *win, int y, int x, wint_t *wstr, int n);

  Return Value:
	This functions return ERR on failure or any other value on 
	success.

  Portability				     X/Open    BSD    SYS V
	getstr					Y	Y	Y
	wgetstr					Y	Y	Y
	mvgetstr				Y	Y	Y
	mvwgetstr				Y	Y	Y
	getnstr					Y	-      4.0
	wgetnstr				Y	-      4.0
	mvgetnstr				Y	-       -
	mvwgetnstr				Y	-       -
	get_wstr				Y
	wget_wstr				Y
	mvget_wstr				Y
	mvwget_wstr				Y
	getn_wstr				Y
	wgetn_wstr				Y
	mvgetn_wstr				Y
	mvwgetn_wstr				Y
*/

int 
wrap_wgetnstr(WINDOW *win, char *str, int n)
{
	return wgetnstr(win, str, n);
}

int 
wrap_mvwgetnstr(WINDOW *win, int y, int x, char *str, int n)
{
	return mvwgetnstr(win, y, x, str, n);
}

int 
wrap_wgetn_wstr(WINDOW *win, wchar_t *wstr, int n)
{
	return wgetn_wstr(win, (wint_t*)wstr, n);
}

int 
wrap_mvwgetn_wstr(WINDOW *win, int y, int x, wchar_t *wstr, int n)
{
	return mvwgetn_wstr(win, y, x, (wint_t*)wstr, n);
}
