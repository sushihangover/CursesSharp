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
  Name:								scr_dump

  Synopsis:
	int putwin(WINDOW *win, FILE *filep);
	WINDOW *getwin(FILE *filep);
	int scr_dump(const char *filename);
	int scr_init(const char *filename);
	int scr_restore(const char *filename);
	int scr_set(const char *filename);

  Return Value:
	On successful completion, getwin() returns a pointer to the 
	window it created. Otherwise, it returns a null pointer. Other 
	functions return OK or ERR.

  Portability				     X/Open    BSD    SYS V
	putwin					Y
	getwin					Y
	scr_dump				Y
	scr_init				Y
	scr_restore				Y
	scr_set					Y
*/

