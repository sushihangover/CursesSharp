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
#include <errno.h>


WRAP_API int
wrap_winsnstr(WINDOW *win, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return wins_nwstr(win, str, n);
#elif defined(CURSES_WIDE)
	int buflen = BUFFER_SIZE;
	wchar_t stackbuf[BUFFER_SIZE];
	wchar_t *buf = stackbuf;
	int ret = unicode_to_wchar_alloc(str, n, &buf, &buflen);
	if (ret < 0)
		return ret;
	ret = wins_nwstr(win, buf, buflen);
	if (buf != stackbuf) {
		free(buf);
	}
	return ret;
#else
#error Not implemented yet
#endif
}

WRAP_API int
wrap_mvwinsnstr(WINDOW *win, int y, int x, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return mvwins_nwstr(win, y, x, str, n);
#elif defined(CURSES_WIDE)
	int buflen = BUFFER_SIZE;
	wchar_t stackbuf[BUFFER_SIZE + 1];
	wchar_t *buf = stackbuf;
	int ret = unicode_to_wchar_alloc(str, n, &buf, &buflen);
	if (ret < 0)
		return -1;
	buf[buflen] = 0;
	ret = mvwins_nwstr(win, y, x, buf, buflen);
	if (buf != stackbuf) {
		free(buf);
	}
	return ret;
#else
	int buflen = BUFFER_SIZE;
	char stackbuf[BUFFER_SIZE + 1];
	char *buf = stackbuf;
	int ret = unicode_to_char(str, n, buf, &buflen);
	if (ret < 0 && errno == E2BIG)
		ret = unicode_to_char_alloc(str, n, &buf, &buflen);
	if (ret < 0)
		return -1;
	buf[buflen] = 0;
	ret = mvwinsnstr(win, y, x, buf, buflen);
	if (buf != stackbuf) {
		free(buf);
	}
	return ret;
#endif
}

