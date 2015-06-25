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
wrap_waddnstr(WINDOW *win, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return xxx waddnwstr(win, str, n);
#elif defined(CURSES_WIDE)
	wchar_t stackbuf[BUFFER_SIZE];
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init_uc(&xinput, str, n, XBUF_FILL);
	xbuf_init_wc(&xoutput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);

	ret = unicode_to_wchar(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_tzero_wc(&xoutput);
	if (ret < 0)
		goto do_exit;
	ret = waddnwstr(win, xbuf_data_wc(&xoutput), xbuf_len_wc(&xoutput));
do_exit:
	xbuf_free(&xoutput);
	return ret;
#else
	char stackbuf[BUFFER_SIZE];
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init_uc(&xinput, str, n, XBUF_FILL);
	xbuf_init(&xoutput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);

	ret = unicode_to_char(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_tzero(&xoutput);
	if (ret < 0)
		goto do_exit;
	ret = waddnstr(win, xbuf_data(&xoutput), xbuf_len(&xoutput));
do_exit:
	xbuf_free(&xoutput);
	return ret;
#endif
}

WRAP_API int
wrap_mvwaddnstr(WINDOW *win, int y, int x, uchar2 *str, int n)
{
#if defined(CURSES_WIDE) && SIZEOF_WCHAR_T == 2
	return mvwaddnwstr(win, y, x, str, n);
#elif defined(CURSES_WIDE)
	wchar_t stackbuf[BUFFER_SIZE];
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init_uc(&xinput, str, n, XBUF_FILL);
	xbuf_init_wc(&xoutput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);

	ret = unicode_to_wchar(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_tzero_wc(&xoutput);
	if (ret < 0)
		goto do_exit;
	ret = mvwaddnwstr(win, y, x, xbuf_data_wc(&xoutput), xbuf_len_wc(&xoutput));
do_exit:
	xbuf_free(&xoutput);
	return ret;
#else
	char stackbuf[BUFFER_SIZE];
	xbuffer xinput, xoutput;
	int ret;

	xbuf_init_uc(&xinput, str, n, XBUF_FILL);
	xbuf_init(&xoutput, stackbuf, BUFFER_SIZE, XBUF_EXPANDABLE);

	ret = unicode_to_char(&xinput, &xoutput);
	if (ret < 0)
		goto do_exit;
	ret = xbuf_tzero(&xoutput);
	if (ret < 0)
		goto do_exit;
	ret = mvwaddnstr(win, y, x, xbuf_data(&xoutput), xbuf_len(&xoutput));
do_exit:
	xbuf_free(&xoutput);
	return ret;
#endif
}

