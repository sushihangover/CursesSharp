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
  Name:								getyx

  Synopsis:
	void getyx(WINDOW *win, int y, int x);
	void getparyx(WINDOW *win, int y, int x);
	void getbegyx(WINDOW *win, int y, int x);
	void getmaxyx(WINDOW *win, int y, int x);

	int getbegy(WINDOW *win);
	int getbegx(WINDOW *win);
	int getcury(WINDOW *win);
	int getcurx(WINDOW *win);
	int getpary(WINDOW *win);
	int getparx(WINDOW *win);
	int getmaxy(WINDOW *win);
	int getmaxx(WINDOW *win);

  Description:
	With the getyx() macro, the cursor position of the window is 
	placed in the two integer variables y and x. getbegyx() and 
	getmaxyx() return the current beginning coordinates and size of 
	the specified window respectively. getparyx() returns the 
	beginning coordinates of the parent's window if the specified 
	window is a sub-window otherwise -1 is returned. These functions 
	are implemented as macros.

	The functions getbegy(), getbegx(), getcurx(), getcury(), 
	getmaxy(), getmaxx(), getpary(), and getparx() return the 
	appropriate coordinate or size values, or ERR in the case of a 
	NULL window.

  Portability				     X/Open    BSD    SYS V
	getyx					Y	Y	Y
	getparyx				-	-      4.0
	getbegyx				-	-      3.0
	getmaxyx				-	-      3.0
	getbegy					-	-	-
	getbegx					-	-	-
	getcury					-	-	-
	getcurx					-	-	-
	getpary					-	-	-
	getparx					-	-	-
	getmaxy					-	-	-
	getmaxx					-	-	-
*/

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
