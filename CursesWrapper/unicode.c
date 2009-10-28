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
unicode_to_wchar(xreader* input, xwriter* output)
{
	size_t inleft = xrdr_left_uc(input);
	while (inleft > 0) {
		uchar2 ch = xrdr_get_uc(input);
		wchar_t outch = ch;

		if (ch >= 0xD800 && ch <= 0xDFFF) {
			uchar2 ch2;
			if (inleft < 2)
				return -1;
			ch2 = xrdr_get_uc(input);
			assert(0xD800 <= ch && ch <= 0xDBFF);
			assert(0xDC00 <= ch2 && ch2 <= 0xDFFF);
			outch = 0x10000 + ((ch - 0xD800) << 10) + (ch2 - 0xDC00);
		} else if (ch == 0) {
			assert(inleft > 1);
			return -1;
		}
		assert(xrdr_left_uc(input) < inleft);
		inleft = xrdr_left_uc(input);

		assert(wchar_validate(outch));
		if (xwrtr_append_wc(output, 1) < 0)
			return -1;
		xwrtr_put_wc(output, outch);
	}

	return 0;
}

int
wchar_to_unicode(xreader* input, xwriter* output)
{
	while (xrdr_left_wc(input) > 0) {
		wchar_t ch = xrdr_get_wc(input);
		assert(ch <= 0x10FFFF);
		if (ch <= 0xFFFF) {
			if (xwrtr_append_uc(output, 1) < 0)
				return -1;
			xwrtr_put_uc(output, (uchar2)ch);
		} else {
			uchar2 outch1 = LEAD_OFFSET + (ch >> 10);
			uchar2 outch2 = 0xDC00 + (ch & 0x3FF);
			assert(0xD800 <= outch1 && outch1 <= 0xDBFF);
			assert(0xDC00 <= outch2 && outch2 <= 0xDFFF);
			if (xwrtr_append_uc(output, 2) < 0)
				return -1;
			xwrtr_put_uc(output, outch1);
			xwrtr_put_uc(output, outch2);
		}
		if (ch == 0)
			return 0;
	}

	return 0;
}
#endif

int 
unicode_to_char(xreader* input, xwriter* output)
{
	return -1;
}

int
char_to_unicode(xreader* input, xwriter* output)
{
	return -1;
}


