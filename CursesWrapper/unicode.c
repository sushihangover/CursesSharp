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

#ifdef HAVE_WCHAR_T
const wchar_t LEAD_OFFSET = 0xD800 - (0x10000 >> 10);
const wchar_t SURROGATE_OFFSET = 0x10000 - (0xD800 << 10) - 0xDC00;

int 
wchar_validate(wchar_t wc)
{
#if SIZEOF_WCHAR_T == 4
	if (wc > 0x10FFFF)
		return 0;
	if (wc >= 0xD800 && wc <= 0xDFFF)
		return 0;
#endif
	return 1;
}

int 
unicode_to_wchar(const xbuffer* input, xbuffer* output)
{
	size_t inlen = xbuf_len_uc(input);
	const uchar2* ptr = xbuf_data_uc(input);
	const uchar2* bufend = ptr + inlen;

	while (ptr < bufend && *ptr) {
		uchar2 ch = *ptr++;
		wchar_t outch = ch;

		if (ch >= 0xD800 && ch <= 0xDBFF) {
			uchar2 ch2;
			if (ptr >= bufend)
				return -1;
			ch2 = *ptr++;
			assert(0xDC00 <= ch2 && ch2 <= 0xDFFF);
			outch = 0x10000 + ((ch - 0xD800) << 10) + (ch2 - 0xDC00);
		}
		assert(ch < 0xDC00 || ch > 0xDFFF);

		assert(wchar_validate(outch));
		if (xbuf_ensure_wc(output, 1) < 0)
			return -1;
		xbuf_put_wc(output, outch);
	}

	return 0;
}

int
wchar_to_unicode(const xbuffer* input, xbuffer* output)
{
	size_t inlen = xbuf_len_wc(input);
	const wchar_t* ptr = xbuf_data_wc(input);
	const wchar_t* bufend = ptr + inlen;

	while (ptr < bufend && *ptr) {
		wchar_t ch = *ptr++;
		assert(ch <= 0x10FFFF);
		if (ch <= 0xFFFF) {
			if (xbuf_ensure_uc(output, 1) < 0)
				return -1;
			xbuf_put_uc(output, (uchar2)ch);
		} else {
			uchar2 outch1 = LEAD_OFFSET + (ch >> 10);
			uchar2 outch2 = 0xDC00 + (ch & 0x3FF);
			assert(0xD800 <= outch1 && outch1 <= 0xDBFF);
			assert(0xDC00 <= outch2 && outch2 <= 0xDFFF);
			if (xbuf_ensure_uc(output, 2) < 0)
				return -1;
			xbuf_put_uc(output, outch1);
			xbuf_put_uc(output, outch2);
		}
	}

	return 0;
}
#endif

int 
unicode_to_char(const xbuffer* input, xbuffer* output)
{
	return -1;
}

int
char_to_unicode(const xbuffer* input, xbuffer* output)
{
	return -1;
}


