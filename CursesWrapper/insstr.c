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
  Name:								insstr

  Synopsis:
	int insstr(const char *str);
	int insnstr(const char *str, int n);
	int winsstr(WINDOW *win, const char *str);
	int winsnstr(WINDOW *win, const char *str, int n);
	int mvinsstr(int y, int x, const char *str);
	int mvinsnstr(int y, int x, const char *str, int n);
	int mvwinsstr(WINDOW *win, int y, int x, const char *str);
	int mvwinsnstr(WINDOW *win, int y, int x, const char *str, int n);

	int ins_wstr(const wchar_t *wstr);
	int ins_nwstr(const wchar_t *wstr, int n);
	int wins_wstr(WINDOW *win, const wchar_t *wstr);
	int wins_nwstr(WINDOW *win, const wchar_t *wstr, int n);
	int mvins_wstr(int y, int x, const wchar_t *wstr);
	int mvins_nwstr(int y, int x, const wchar_t *wstr, int n);
	int mvwins_wstr(WINDOW *win, int y, int x, const wchar_t *wstr);
	int mvwins_nwstr(WINDOW *win, int y, int x, const wchar_t *wstr, int n);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	insstr					Y	-      4.0
	winsstr					Y	-      4.0
	mvinsstr				Y	-      4.0
	mvwinsstr				Y	-      4.0
	insnstr					Y	-      4.0
	winsnstr				Y	-      4.0
	mvinsnstr				Y	-      4.0
	mvwinsnstr				Y	-      4.0
	ins_wstr				Y
	wins_wstr				Y
	mvins_wstr				Y
	mvwins_wstr				Y
	ins_nwstr				Y
	wins_nwstr				Y
	mvins_nwstr				Y
	mvwins_nwstr				Y
*/

int 
wrap_winsnstr(WINDOW *win, char *str, int n)
{
	return winsnstr(win, str, n);
}

int 
wrap_mvwinsnstr(WINDOW *win, int y, int x, char *str, int n)
{
	return mvwinsnstr(win, y, x, str, n);
}

int 
wrap_wins_nwstr(WINDOW *win, wchar_t *wstr, int n)
{
	return wins_nwstr(win, wstr, n);
}

int 
wrap_mvwins_nwstr(WINDOW *win, int y, int x, wchar_t *wstr, int n)
{
	return mvwins_nwstr(win, y, x, wstr, n);
}
