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


WRAP_API int 
wrap_slk_init(int fmt)
{
	return slk_init(fmt);
}

WRAP_API int 
wrap_slk_set(int labnum, char *label, int justify)
{
	return slk_set(labnum, label, justify);
}

WRAP_API int 
wrap_slk_refresh(void)
{
	return slk_refresh();
}

WRAP_API int 
wrap_slk_noutrefresh(void)
{
	return slk_noutrefresh();
}

WRAP_API const char *
wrap_slk_label(int labnum)
{
	return slk_label(labnum);
}

WRAP_API int 
wrap_slk_clear(void)
{
	return slk_clear();
}

WRAP_API int 
wrap_slk_restore(void)
{
	return slk_restore();
}

WRAP_API int 
wrap_slk_touch(void)
{
	return slk_touch();
}

WRAP_API int 
wrap_slk_attron(unsigned int attrs)
{
	return slk_attron(attrs);
}

WRAP_API int 
wrap_slk_attrset(unsigned int attrs)
{
	return slk_attrset(attrs);
}

WRAP_API int 
wrap_slk_attroff(unsigned int attrs)
{
	return slk_attroff(attrs);
}

WRAP_API int 
wrap_slk_color(short color_pair)
{
	return slk_color(color_pair);
}

#ifdef HAVE_USE_WIDECHAR

WRAP_API int 
wrap_slk_wset(int labnum, wchar_t *label, int justify)
{
	return slk_wset(labnum, label, justify);
}

#endif
