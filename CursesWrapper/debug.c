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
  Name:								debug

  Synopsis:
	void traceon(void);
	void traceoff(void);
	void PDC_debug(const char *, ...);

  Description:
	traceon() and traceoff() toggle the recording of debugging 
	information to the file "trace". Although not standard, similar 
	functions are in some other curses implementations.

	PDC_debug() is the function that writes to the file, based on 
	whether traceon() has been called. It's used from the PDC_LOG() 
	macro.

  Portability				     X/Open    BSD    SYS V
	traceon					-	-	-
	traceoff				-	-	-
	PDC_debug				-	-	-
*/

void
wrap_traceon(void)
{
#ifdef PDCDEBUG
	traceon();
#endif
}

void
wrap_traceoff(void)
{
#ifdef PDCDEBUG
	traceoff();
#endif
}
