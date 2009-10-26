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

#ifdef HAVE_WCHAR_T
const wchar_t LEAD_OFFSET = 0xD800 - (0x10000 >> 10);
const wchar_t SURROGATE_OFFSET = 0x10000 - (0xD800 << 10) - 0xDC00;

int 
unicode_to_wchar(const uchar2 *instr, int inlen, wchar_t *outstr, int *outlen)
{
	int outleft = *outlen;
	while (inlen > 0) {
		if (*instr >= 0xD800) {
			uchar2 lead, trail;
			if (inlen < 2 || outleft < 1) {
				*outlen -= outleft;
				return -1;
			}
			if (*instr <= 0xDBFF) {
				lead = *instr++;
				trail = *instr++;
			} else {
				trail = *instr++;
				lead = *instr++;
			}
			inlen -= 2;
			*outstr++ = (lead << 10) + trail + SURROGATE_OFFSET;
			outleft--;
		} else {
			if (outleft < 1) {
				*outlen -= outleft;
				return -1;
			}
			*outstr++ = *instr++;
			inlen--;
			outleft--;
		}
	}
	*outlen -= outleft;
	return 0;
}

int
wchar_to_unicode(const wchar_t *instr, int inlen, uchar2 *outstr, int *outlen)
{
	int outleft = *outlen;
	while (inlen > 0) {
		if (*instr >= 0xD800) {
			if (outleft < 2) {
				*outlen -= outleft;
				return -1;
			}
			*outstr++ = LEAD_OFFSET + (*instr >> 10);
			*outstr++ = 0xDC00 + (*instr & 0x3FF);
			outleft -= 2;
			inlen--;
		} else {
			if (outleft < 1) {
				*outlen -= outleft;
				return -1;
			}
			*outstr++ = *instr++;
			inlen--;
			outleft--;
		}
	}
	*outlen -= outleft;
	return 0;
}
#endif

int 
unicode_to_char(const uchar2 *instr, int inlen, char *outstr, int *outlen)
{
	return -1;
}

int
char_to_unicode(const char *instr, int inlen, uchar2 *outstr, int *outlen)
{
	return -1;
}


