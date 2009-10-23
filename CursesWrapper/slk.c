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
#include "unicode.h"


WRAP_API int 
wrap_slk_init(int fmt)
{
	return slk_init(fmt);
}

WRAP_API int 
wrap_slk_set(int labnum, uchar2 *label, int labellen, int justify)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return slk_wset(labnum, label, justify);
#elif defined(CURSES_WIDE)
	int buflen = labellen + 1;
	wchar_t *buf = myAlloc(sizeof(wchar_t), buflen);
	if (buf == 0)
		return -1;
	buflen = unicode_to_wchar(label, labellen, buf, buflen);
	if (buflen < 0)
		return -1;
	buf[buflen] = 0;
	return slk_wset(labnum, buf, justify);
#else
	int buflen = labellen + 1;
	char *buf = myAlloc(sizeof(char), buflen);
	if (buf == 0)
		return -1;
	buflen = unicode_to_char(label, labellen, buf, buflen);
	if (buflen < 0)
		return -1;
	buf[buflen] = 0;
	return slk_set(labnum, buf, justify);
#endif
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

