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
  Name:								termattr

  Synopsis:
	int baudrate(void);
	char erasechar(void);
	bool has_ic(void);
	bool has_il(void);
	char killchar(void);
	char *longname(void);
	chtype termattrs(void);
	attr_t term_attrs(void);
	char *termname(void);

	int erasewchar(wchar_t *ch);
	int killwchar(wchar_t *ch);

	char wordchar(void);

  Description:
	baudrate() is supposed to return the output speed of the 
	terminal. In PDCurses, it simply returns INT_MAX.

	has_ic and has_il() return TRUE. These functions have meaning in 
	some other implementations of curses.

	erasechar() and killchar() return ^H and ^U, respectively -- the 
	ERASE and KILL characters. In other curses implementations, 
	these may vary by terminal type. erasewchar() and killwchar() 
	are the wide-character versions; they take a pointer to a 
	location in which to store the character, and return OK or ERR.

	longname() returns a pointer to a static area containing a
	verbose description of the current terminal. The maximum length
	of the string is 128 characters.  It is defined only after the
	call to initscr() or newterm().

	termname() returns a pointer to a static area containing a
	short description of the current terminal (14 characters).

	termattrs() returns a logical OR of all video attributes
	supported by the terminal.

	wordchar() is a PDCurses extension of the concept behind the 
	functions erasechar() and killchar(), returning the "delete 
	word" character, ^W.

  Portability				     X/Open    BSD    SYS V
	baudrate				Y	Y	Y
	erasechar				Y	Y	Y
	has_ic					Y	Y	Y
	has_il					Y	Y	Y
	killchar				Y	Y	Y
	longname				Y	Y	Y
	termattrs				Y	Y	Y
	termname				Y	Y	Y
	erasewchar				Y
	killwchar				Y
	term_attrs				Y
	wordchar				-	-	-
*/
