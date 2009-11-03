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

#include "unicode.h"
#include <assert.h>
#include <errno.h>
#include <iconv.h>

static int
iconv_buf(iconv_t cd, const xbuffer* input, xbuffer* output)
{
	ICONV_CONST char* inptr = (ICONV_CONST char*)xbuf_data(input);
	size_t inleft = xbuf_len(input);
	char* outptr = NULL;
	size_t maxlen = 0, outlen = 0, outleft = 0;
	int ret = 0;

	/* reset iconv */
	iconv(cd, NULL, NULL, NULL, NULL);
	/* perform conversion */
	while (inleft > 0) {
		maxlen = xbuf_maxlen(output);
		outptr = xbuf_buf(output, maxlen) + outlen;
		outleft = maxlen - outlen;
		ret = iconv(cd, &inptr, &inleft, &outptr, &outleft);
		outlen = maxlen - outleft;
		if (ret < 0 && errno == E2BIG) {
			size_t newlen = maxlen + BUFFER_SIZE + 1;
			if (newlen < inleft)
				newlen = inleft;
			ret = xbuf_reserve(output, newlen);
		}
		if (ret < 0)
			break;
	}
	/* append reset sequence */
	for (;;) {
		int ret2;
		maxlen = xbuf_maxlen(output);
		outptr = xbuf_buf(output, maxlen) + outlen;
		outleft = maxlen - outlen;
		ret2 = iconv(cd, NULL, NULL, &outptr, &outleft);
		if (ret2 >= 0) {
			assert(maxlen == outlen + outleft);
			outlen = maxlen - outleft;
			break;
		} else if (errno == E2BIG) {
			size_t newlen = maxlen + BUFFER_SIZE + 1;
			ret2 = xbuf_reserve(output, newlen);
		}
		if (ret2 < 0) {
			ret = ret2;
			break;
		}
	}
	xbuf_resize(output, outlen);

	return ret;
}

#ifdef HAVE_WCHAR_T
static iconv_t
get_unicode_to_wchar(void)
{
	static iconv_t cd = (iconv_t)-1;
	if (cd == (iconv_t)-1)
		cd = iconv_open("WCHAR_T//TRANSLIT//IGNORE", "UTF-16LE");
	return cd;
}

static iconv_t
get_wchar_to_unicode(void)
{
	static iconv_t cd = (iconv_t)-1;
	if (cd == (iconv_t)-1)
		cd = iconv_open("UTF-16LE//TRANSLIT//IGNORE", "WCHAR_T");
	return cd;
}

int 
unicode_to_wchar(const xbuffer* input, xbuffer* output)
{
	iconv_t cd = get_unicode_to_wchar();
	if (cd == (iconv_t)-1)
		return -1;
	return iconv_buf(cd, input, output);
}

int
wchar_to_unicode(const xbuffer* input, xbuffer* output)
{
	iconv_t cd = get_wchar_to_unicode();
	if (cd == (iconv_t)-1)
		return -1;
	return iconv_buf(cd, input, output);
}
#endif

static iconv_t
get_unicode_to_char(void)
{
	static iconv_t cd = (iconv_t)-1;
	if (cd == (iconv_t)-1)
		cd = iconv_open("ASCII//TRANSLIT//IGNORE", "UTF-16LE");
	return cd;
}

static iconv_t
get_char_to_unicode(void)
{
	static iconv_t cd = (iconv_t)-1;
	if (cd == (iconv_t)-1)
		cd = iconv_open("UTF-16LE//TRANSLIT//IGNORE", "ASCII");
	return cd;
}

int 
unicode_to_char(const xbuffer* input, xbuffer* output)
{
	iconv_t cd = get_unicode_to_char();
	if (cd == (iconv_t)-1)
		return -1;
	return iconv_buf(cd, input, output);
}

int
char_to_unicode(const xbuffer* input, xbuffer* output)
{
	iconv_t cd = get_char_to_unicode();
	if (cd == (iconv_t)-1)
		return -1;
	return iconv_buf(cd, input, output);
}


