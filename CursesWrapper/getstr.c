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
	int ret, buflen = BUFFER_SIZE;
	wchar_t stackbuf[BUFFER_SIZE];
	wchar_t *buf = stackbuf;
	if (buflen < n) {
		buf = malloc(n * sizeof(wchar_t));
		if (!buf)
			return -1;
	}
	ret = wgetn_wstr(win, (wint_t*)buf, n);
	if (ret < 0) {
		if (buf != stackbuf)
			free(buf);
		return ret;
	}
	buflen = ret;
	ret = wchar_to_unicode(buf, buflen, str, &n);
	if (buf != stackbuf)
		free(buf);
	if (ret < 0)
		return ret;
	return n;
#else
	int ret, buflen = BUFFER_SIZE;
	char stackbuf[BUFFER_SIZE];
	char *buf = stackbuf;
	if (buflen < n) {
		buf = malloc(n * sizeof(char));
		if (!buf)
			return -1;
	}
	ret = wgetnstr(win, buf, n);
	if (ret < 0) {
		if (buf != stackbuf)
			free(buf);
		return ret;
	}
	buflen = ret;
	ret = char_to_unicode(buf, buflen, str, &n);
	if (buf != stackbuf)
		free(buf);
	if (ret < 0)
		return ret;
	return n;
#endif
}

WRAP_API int
wrap_mvwgetnstr(WINDOW *win, int y, int x, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return mvwgetn_wstr(win, y, x, (wint_t*)str, n);
#elif defined(CURSES_WIDE)
	int ret, buflen = BUFFER_SIZE;
	wchar_t stackbuf[BUFFER_SIZE];
	wchar_t *buf = stackbuf;
	if (buflen < n) {
		buf = malloc(n * sizeof(wchar_t));
		if (!buf)
			return -1;
	}
	ret = mvwgetn_wstr(win, y, x, (wint_t*)buf, n);
	if (ret < 0) {
		if (buf != stackbuf)
			free(buf);
		return ret;
	}
	buflen = ret;
	ret = wchar_to_unicode(buf, buflen, str, &n);
	if (buf != stackbuf)
		free(buf);
	if (ret < 0)
		return ret;
	return n;
#else
	int ret, buflen = BUFFER_SIZE;
	char stackbuf[BUFFER_SIZE];
	char *buf = stackbuf;
	if (buflen < n) {
		buf = malloc(n * sizeof(char));
		if (!buf)
			return -1;
	}
	ret = mvwgetnstr(win, y, x, buf, n);
	if (ret < 0) {
		if (buf != stackbuf)
			free(buf);
		return ret;
	}
	buflen = ret;
	ret = char_to_unicode(buf, buflen, str, &n);
	if (buf != stackbuf)
		free(buf);
	if (ret < 0)
		return ret;
	return n;
#endif
}

