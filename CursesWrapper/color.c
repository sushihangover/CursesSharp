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
  Name:								color

  Synopsis:
	int start_color(void);
	int init_pair(short pair, short fg, short bg);
	int init_color(short color, short red, short green, short blue);
	bool has_colors(void);
	bool can_change_color(void);
	int color_content(short color, short *red, short *green, short *blue);
	int pair_content(short pair, short *fg, short *bg);

	int assume_default_colors(int f, int b);
	int use_default_colors(void);

  Return Value:
	All functions return OK on success and ERR on error, except for
	has_colors() and can_change_colors(), which return TRUE or FALSE.

  Portability				     X/Open    BSD    SYS V
	start_color				Y	-      3.2
	init_pair				Y	-      3.2
	init_color				Y	-      3.2
	has_colors				Y	-      3.2
	can_change_color			Y	-      3.2
	color_content				Y	-      3.2
	pair_content				Y	-      3.2
	assume_default_colors			-	-	-
	use_default_colors			-	-	-
	PDC_set_line_color			-	-       -
*/

unsigned int
wrap_COLOR_PAIR(int n)
{
	return COLOR_PAIR(n);
}

short
wrap_PAIR_NUMBER(unsigned int n)
{
	return (short)(PAIR_NUMBER(n));
}

int
wrap_start_color(void)
{
	return start_color();
}

int
wrap_init_pair(short color, short fg, short bg)
{
	return init_pair(color, fg, bg);
}

int
wrap_init_color(short color, short red, short green, short blue)
{
	return init_color(color, red, green, blue);
}

int 
wrap_color_content(short color, short *red, short *green, short *blue)
{
	return color_content(color, red, green, blue);
}

int 
wrap_pair_content(short pair, short *fg, short *bg)
{
	return pair_content(pair, fg, bg);
}

int
wrap_has_colors(void)
{
	return has_colors();
}

int 
wrap_can_change_color(void)
{
	return can_change_color();
}

int 
wrap_assume_default_colors(int f, int b)
{
	return assume_default_colors(f, b);
}

int 
wrap_use_default_colors(void)
{
	return use_default_colors();
}
