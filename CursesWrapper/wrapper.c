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

#ifdef HAVE_USE_WIDECHAR
STATIC_ASSERT(sizeof(wchar_t) == 2);
#endif


WRAP_API int
wrap_LINES(void)
{
	return LINES;
}

WRAP_API int
wrap_COLS(void)
{
	return COLS;
}

WRAP_API int
wrap_COLORS(void)
{
	return COLORS;
}

WRAP_API int
wrap_COLOR_PAIRS(void)
{
	return COLOR_PAIRS;
}

WRAP_API int
wrap_TABSIZE(void)
{
	return TABSIZE;
}
