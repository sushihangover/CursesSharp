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
  Name:								instr

  Synopsis:
	int instr(char *str);
	int innstr(char *str, int n);
	int winstr(WINDOW *win, char *str);
	int winnstr(WINDOW *win, char *str, int n);
	int mvinstr(int y, int x, char *str);
	int mvinnstr(int y, int x, char *str, int n);
	int mvwinstr(WINDOW *win, int y, int x, char *str);
	int mvwinnstr(WINDOW *win, int y, int x, char *str, int n);

	int inwstr(wchar_t *wstr);
	int innwstr(wchar_t *wstr, int n);
	int winwstr(WINDOW *win, wchar_t *wstr);
	int winnwstr(WINDOW *win, wchar_t *wstr, int n);
	int mvinwstr(int y, int x, wchar_t *wstr);
	int mvinnwstr(int y, int x, wchar_t *wstr, int n);
	int mvwinwstr(WINDOW *win, int y, int x, wchar_t *wstr);
	int mvwinnwstr(WINDOW *win, int y, int x, wchar_t *wstr, int n);

  Return Value:
	Upon successful completion, innstr(), mvinnstr(), mvwinnstr() 
	and winnstr() return the number of characters actually read into
	the string; instr(), mvinstr(), mvwinstr() and winstr() return 
	OK. Otherwise, all these functions return ERR.

  Portability				     X/Open    BSD    SYS V
	instr					Y	-      4.0
	winstr					Y	-      4.0
	mvinstr					Y	-      4.0
	mvwinstr				Y	-      4.0
	innstr					Y	-      4.0
	winnstr					Y	-      4.0
	mvinnstr				Y	-      4.0
	mvwinnstr				Y	-      4.0
	inwstr					Y
	winwstr					Y
	mvinwstr				Y
	mvwinwstr				Y
	innwstr					Y
	winnwstr				Y
	mvinnwstr				Y
	mvwinnwstr				Y
*/

WRAP_API int
wrap_winnstr(WINDOW *win, char *str, int n)
{
	return winnstr(win, str, n);
}

WRAP_API int
wrap_mvwinnstr(WINDOW *win, int y, int x, char *str, int n)
{
	return mvwinnstr(win, y, x, str, n);
}

#ifdef HAVE_USE_WIDECHAR

WRAP_API int
wrap_winnwstr(WINDOW *win, wchar_t *wstr, int n)
{
	return winnwstr(win, wstr, n);
}


WRAP_API int
wrap_mvwinnwstr(WINDOW *win, int y, int x, wchar_t *wstr, int n)
{
	return mvwinnwstr(win, y, x, wstr, n);
}

#endif
