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


WRAP_API unsigned int
wrap_COLOR_PAIR(int n)
{
	return COLOR_PAIR(n);
}

WRAP_API short
wrap_PAIR_NUMBER(unsigned int n)
{
	return (short)(PAIR_NUMBER(n));
}

WRAP_API int
wrap_start_color(void)
{
	return start_color();
}

WRAP_API int
wrap_init_pair(short color, short fg, short bg)
{
	return init_pair(color, fg, bg);
}

WRAP_API int
wrap_init_color(short color, short red, short green, short blue)
{
	return init_color(color, red, green, blue);
}

WRAP_API int
wrap_color_content(short color, short *red, short *green, short *blue)
{
	return color_content(color, red, green, blue);
}

WRAP_API int
wrap_pair_content(short pair, short *fg, short *bg)
{
	return pair_content(pair, fg, bg);
}

WRAP_API int
wrap_has_colors(void)
{
	return has_colors();
}

WRAP_API int
wrap_can_change_color(void)
{
	return can_change_color();
}

WRAP_API int
wrap_assume_default_colors(int f, int b)
{
	return assume_default_colors(f, b);
}

WRAP_API int
wrap_use_default_colors(void)
{
	return use_default_colors();
}
