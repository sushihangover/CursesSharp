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
  Name:								initscr

  Synopsis:
	WINDOW *initscr(void);
	WINDOW *Xinitscr(int argc, char *argv[]);
	int endwin(void);
	bool isendwin(void);
	SCREEN *newterm(const char *type, FILE *outfd, FILE *infd);
	SCREEN *set_term(SCREEN *new);
	void delscreen(SCREEN *sp);

	int resize_term(int nlines, int ncols);
	bool is_termresized(void);
	const char *curses_version(void);

  Return Value:
	All functions return NULL on error, except endwin(), which
	returns ERR on error.

  Portability				     X/Open    BSD    SYS V
	initscr					Y	Y	Y
	endwin					Y	Y	Y
	isendwin				Y	-      3.0
	newterm					Y	-	Y
	set_term				Y	-	Y
	delscreen				Y	-      4.0
	resize_term				-	-	-
	is_termresized				-	-	-
	curses_version				-	-	-
*/

WRAP_API WINDOW *
wrap_initscr(void)
{
	return initscr();
}

WRAP_API int
wrap_endwin(void)
{
	return endwin();
}

WRAP_API int
wrap_isendwin(void)
{
	return isendwin();
}

WRAP_API int
wrap_resize_term(int nlines, int ncols)
{
	return resize_term(nlines, ncols);
}

