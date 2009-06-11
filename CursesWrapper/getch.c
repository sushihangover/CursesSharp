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
  Name:								getch

  Synopsis:
	int getch(void);
	int wgetch(WINDOW *win);
	int mvgetch(int y, int x);
	int mvwgetch(WINDOW *win, int y, int x);
	int ungetch(int ch);
	int flushinp(void);

	int get_wch(wint_t *wch);
	int wget_wch(WINDOW *win, wint_t *wch);
	int mvget_wch(int y, int x, wint_t *wch);
	int mvwget_wch(WINDOW *win, int y, int x, wint_t *wch);
	int unget_wch(const wchar_t wch);

  Return Value:
	These functions return ERR or the value of the character, meta 
	character or function key token.

  Portability				     X/Open    BSD    SYS V
	getch					Y	Y	Y
	wgetch					Y	Y	Y
	mvgetch					Y	Y	Y
	mvwgetch				Y	Y	Y
	ungetch					Y	Y	Y
	flushinp				Y	Y	Y
	get_wch					Y
	wget_wch				Y
	mvget_wch				Y
	mvwget_wch				Y
	unget_wch				Y
	PDC_get_key_modifiers			-	-	-
*/

int
wrap_wgetch(WINDOW* win)
{
	return wgetch(win);
}

int 
wrap_mvwgetch(WINDOW *win, int y, int x)
{
	return mvwgetch(win, y, x);
}

int 
wrap_ungetch(int ch)
{
	return ungetch(ch);
}

int 
wrap_flushinp(void)
{
	return flushinp();
}

