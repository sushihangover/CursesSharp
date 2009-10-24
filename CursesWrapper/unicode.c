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
#ifdef HAVE_ICONV_H
#include <iconv.h>
#endif

#ifdef USING_ICONV

#ifdef HAVE_WCHAR_T
static iconv_t cd_unicode_iconv_wchar = 0;
static iconv_t cd_wchar_iconv_unicode = 0;
#endif
static iconv_t cd_unicode_iconv_char = 0;
static iconv_t cd_char_iconv_unicode = 0;

#ifdef HAVE_WCHAR_T
static iconv_t
get_unicode_iconv_wchar(void)
{
	if (cd_unicode_iconv_wchar == 0)
		cd_unicode_iconv_wchar = iconv_open("WCHAR_T", "UCS-2LE"); 
	return cd_unicode_iconv_wchar;
}

static iconv_t
get_wchar_iconv_unicode(void)
{
	if (cd_wchar_iconv_unicode == 0)
		cd_wchar_iconv_unicode = iconv_open("UCS-2LE//TRANSLIT", "WCHAR_T"); 
	return cd_wchar_iconv_unicode;
}
#endif

static iconv_t
get_unicode_iconv_char(void)
{
	if (cd_unicode_iconv_char == 0)
		cd_unicode_iconv_char = iconv_open("ASCII//TRANSLIT", "UCS-2LE"); 
	return cd_unicode_iconv_char;
}

static iconv_t
get_char_iconv_unicode(void)
{
	if (cd_char_iconv_unicode == 0)
		cd_char_iconv_unicode = iconv_open("UCS-2LE", "ASCII"); 
	return cd_char_iconv_unicode;
}

#ifdef HAVE_WCHAR_T
int 
unicode_to_wchar(const uchar2 *instr, int inlen, wchar_t *outstr, int outlen)
{
#ifdef ICONV_CONST
	const char *inptr = (const char *)instr;
#else
	char *inptr = (char *)instr;
#endif
	size_t inleft = inlen * sizeof(uchar2);
	char *outptr = (char *)outstr;
	size_t outleft = outlen * sizeof(wchar_t);
	size_t outleftlen;

	iconv_t cd = get_unicode_iconv_wchar();
	if (cd == (iconv_t)-1 || cd == 0)
		return -1;

	iconv(cd, &inptr, &inleft, &outptr, &outleft);
	while (inleft >= sizeof(uchar2) && outleft >= sizeof(wchar_t)) {
		if (*(const uchar2 *)inptr == 0)
			break;
		inptr += sizeof(uchar2);
		inleft -= sizeof(uchar2);
		*(wchar_t *)outptr = '?';
		outptr += sizeof(wchar_t);
		outleft -= sizeof(wchar_t);

		iconv(cd, &inptr, &inleft, &outptr, &outleft);
	}

	outleftlen = outleft / sizeof(wchar_t);
	return (int)(outlen - outleftlen);
}

int
wchar_to_unicode(const wchar_t *instr, int inlen, uchar2 *outstr, int outlen)
{
#ifdef ICONV_CONST
	const char *inptr = (const char *)instr;
#else
	char *inptr = (char *)instr;
#endif
	size_t inleft = inlen * sizeof(wchar_t);
	char *outptr = (char *)outstr;
	size_t outleft = outlen * sizeof(uchar2);
	size_t outleftlen;

	iconv_t cd = get_wchar_iconv_unicode();
	if (cd == (iconv_t)-1 || cd == 0)
		return -1;

	iconv(cd, &inptr, &inleft, &outptr, &outleft);
	while (inleft >= sizeof(wchar_t) && outleft >= sizeof(uchar2)) {
		if (*(const wchar_t *)inptr == 0)
			break;
		inptr += sizeof(wchar_t);
		inleft -= sizeof(wchar_t);
		*(uchar2 *)outptr = '?';
		outptr += sizeof(uchar2);
		outleft -= sizeof(uchar2);

		iconv(cd, &inptr, &inleft, &outptr, &outleft);
	}

	outleftlen = outleft / sizeof(uchar2);
	return (int)(outlen - outleftlen);
}
#endif

int 
unicode_to_char(const uchar2 *instr, int inlen, char *outstr, int outlen)
{
#ifdef ICONV_CONST
	const char *inptr = (const char *)instr;
#else
	char *inptr = (char *)instr;
#endif
	size_t inleft = inlen * sizeof(uchar2);
	char *outptr = (char *)outstr;
	size_t outleft = outlen;

	iconv_t cd = get_unicode_iconv_char();
	if (cd == (iconv_t)-1 || cd == 0)
		return -1;

	iconv(cd, &inptr, &inleft, &outptr, &outleft);
	while (inleft >= sizeof(uchar2) && outleft >= sizeof(char)) {
		if (*(const uchar2 *)inptr == 0)
			break;
		inptr += sizeof(uchar2);
		inleft -= sizeof(uchar2);
		*(char *)outptr = '?';
		outptr += sizeof(char);
		outleft -= sizeof(char);

		iconv(cd, &inptr, &inleft, &outptr, &outleft);
	}
	return (int)(outlen - outleft);
}

int
char_to_unicode(const char *instr, int inlen, uchar2 *outstr, int outlen)
{
#ifdef ICONV_CONST
	const char *inptr = (const char *)instr;
#else
	char *inptr = (char *)instr;
#endif
	size_t inleft = inlen;
	char *outptr = (char *)outstr;
	size_t outleft = outlen * sizeof(uchar2);

	iconv_t cd = get_char_iconv_unicode();
	if (cd == (iconv_t)-1 || cd == 0)
		return -1;

	iconv(cd, &inptr, &inleft, &outptr, &outleft);
	while (inleft >= sizeof(char) && outleft >= sizeof(uchar2)) {
		if (*(const char *)inptr == 0)
			break;
		inptr += sizeof(char);
		inleft -= sizeof(char);
		*(uchar2 *)outptr = '?';
		outptr += sizeof(uchar2);
		outleft -= sizeof(uchar2);

		iconv(cd, &inptr, &inleft, &outptr, &outleft);
	}
	return (int)(outlen - outleft);
}

#endif /* USING_ICONV */

