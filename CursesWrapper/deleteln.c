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
  Name:								deleteln

  Synopsis:
	int deleteln(void);
	int wdeleteln(WINDOW *win);
	int insdelln(int n);
	int winsdelln(WINDOW *win, int n);
	int insertln(void);
	int winsertln(WINDOW *win);

	int mvdeleteln(int y, int x);
	int mvwdeleteln(WINDOW *win, int y, int x);
	int mvinsertln(int y, int x);
	int mvwinsertln(WINDOW *win, int y, int x);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	deleteln				Y	Y	Y
	wdeleteln				Y	Y	Y
	mvdeleteln				-	-	-
	mvwdeleteln				-	-	-
	insdelln				Y	-      4.0
	winsdelln				Y	-      4.0
	insertln				Y	Y	Y
	winsertln				Y	Y	Y
	mvinsertln				-	-	-
	mvwinsertln				-	-	-
*/

WRAP_API int
wrap_wdeleteln(WINDOW *win)
{
	return wdeleteln(win);
}

WRAP_API int
wrap_winsdelln(WINDOW *win, int n)
{
	return winsdelln(win, n);
}

WRAP_API int
wrap_winsertln(WINDOW *win)
{
	return winsertln(win);
}

