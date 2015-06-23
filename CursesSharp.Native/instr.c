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
wrap_winnstr(WINDOW *win, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return winnwstr(win, str, n);
#elif defined(CURSES_WIDE)
	wchar_t stackbuf[BUFFER_SIZE];
	wchar_t* buf;
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init_wc(&xinput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);
	xbuf_init_uc(&xoutput, str, n, 0);

	ret = -1;
	buf = xbuf_buf_wc(&xinput, n);
	if (!buf)
		goto do_exit;
	ret = winnwstr(win, buf, n);
	if (ret < 0)
		goto do_exit;
	xbuf_resize_wc(&xinput, ret);
	ret = wchar_to_unicode(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_len_wc(&xoutput);
do_exit:
	xbuf_free(&xinput);
	return ret;
#else
	char stackbuf[BUFFER_SIZE];
	char* buf;
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init(&xinput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);
	xbuf_init_uc(&xoutput, str, n, 0);

	ret = -1;
	buf = xbuf_buf(&xinput, n);
	if (!buf)
		goto do_exit;
	ret = winnstr(win, buf, n);
	if (ret < 0)
		goto do_exit;
	xbuf_resize(&xinput, ret);
	ret = char_to_unicode(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_len(&xoutput);
do_exit:
	xbuf_free(&xinput);
	return ret;
#endif
}

WRAP_API int
wrap_mvwinnstr(WINDOW *win, int y, int x, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return mvwinnwstr(win, y, x, str, n);
#elif defined(CURSES_WIDE)
	wchar_t stackbuf[BUFFER_SIZE];
	wchar_t* buf;
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init_wc(&xinput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);
	xbuf_init_uc(&xoutput, str, n, 0);

	ret = -1;
	buf = xbuf_buf_wc(&xinput, n);
	if (!buf)
		goto do_exit;
	ret = mvwinnwstr(win, y, x, buf, n);
	if (ret < 0)
		goto do_exit;
	xbuf_resize_wc(&xinput, ret);
	ret = wchar_to_unicode(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_len_wc(&xoutput);
do_exit:
	xbuf_free(&xinput);
	return ret;
#else
	char stackbuf[BUFFER_SIZE];
	char* buf;
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init(&xinput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);
	xbuf_init_uc(&xoutput, str, n, 0);

	ret = -1;
	buf = xbuf_buf(&xinput, n);
	if (!buf)
		goto do_exit;
	ret = mvwinnstr(win, y, x, buf, n);
	if (ret < 0)
		goto do_exit;
	xbuf_resize(&xinput, ret);
	ret = char_to_unicode(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_len(&xoutput);
do_exit:
	xbuf_free(&xinput);
	return ret;
#endif
}

