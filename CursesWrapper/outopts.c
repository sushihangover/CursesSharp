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
  Name:								outopts

  Synopsis:
	int clearok(WINDOW *win, bool bf);
	int idlok(WINDOW *win, bool bf);
	void idcok(WINDOW *win, bool bf);
	void immedok(WINDOW *win, bool bf);
	int leaveok(WINDOW *win, bool bf);
	int setscrreg(int top, int bot);
	int wsetscrreg(WINDOW *win, int top, int bot);
	int scrollok(WINDOW *win, bool bf);

	int raw_output(bool bf);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	clearok					Y	Y	Y
	idlok					Y	Y	Y
	idcok					Y	-      4.0
	immedok					Y	-      4.0
	leaveok					Y	Y	Y
	setscrreg				Y	Y	Y
	wsetscrreg				Y	Y	Y
	scrollok				Y	Y	Y
	raw_output				-	-	-
*/

int 
wrap_clearok(WINDOW *win, int bf)
{
	return clearok(win, bf);
}

int 
wrap_idlok(WINDOW *win, int bf)
{
	return idlok(win, bf);
}

void 
wrap_idcok(WINDOW *win, int bf)
{
	idcok(win, bf);
}

void 
wrap_immedok(WINDOW *win, int bf)
{
	immedok(win, bf);
}

int 
wrap_leaveok(WINDOW *win, int bf)
{
	return leaveok(win, bf);
}

int 
wrap_wsetscrreg(WINDOW *win, int top, int bot)
{
	return wsetscrreg(win, top, bot);
}

int 
wrap_scrollok(WINDOW *win, int bf)
{
	return scrollok(win, bf);
}
