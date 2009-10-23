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
wrap_wgetnstr(WINDOW *win, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return wgetn_wstr(win, (wint_t*)str, n);
#elif defined(CURSES_WIDE)
	int buflen = n;
	wchar_t *buf = myAlloc(sizeof(wchar_t), buflen);
	if (buf == 0)
		return -1;
	buflen = wgetn_wstr(win, (wint_t*)buf, buflen);
	if (buflen < 0)
		return -1;
	return wchar_to_unicode(buf, buflen, str, n);
#else
	int buflen = n;
	char *buf = myAlloc(sizeof(char), buflen);
	if (buf == 0)
		return -1;
	buflen = wgetnstr(win, buf, buflen);
	if (buflen < 0)
		return -1;
	return char_to_unicode(buf, buflen, str, n);
#endif
}

WRAP_API int
wrap_mvwgetnstr(WINDOW *win, int y, int x, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return mvwgetn_wstr(win, y, x, (wint_t*)str, n);
#elif defined(CURSES_WIDE)
	int buflen = n;
	wchar_t *buf = myAlloc(sizeof(wchar_t), buflen);
	if (buf == 0)
		return -1;
	buflen = mvwgetn_wstr(win, y, x, (wint_t*)buf, buflen);
	if (buflen < 0)
		return -1;
	return wchar_to_unicode(buf, buflen, str, n);
#else
	int buflen = n;
	char *buf = myAlloc(sizeof(char), buflen);
	if (buf == 0)
		return -1;
	buflen = mvwgetnstr(win, y, x, buf, buflen);
	if (buflen < 0)
		return -1;
	return char_to_unicode(buf, buflen, str, n);
#endif
}

