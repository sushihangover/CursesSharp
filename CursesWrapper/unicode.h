#ifndef CURSES_SHARP_UNICODE_H
#define CURSES_SHARP_UNICODE_H

#ifdef HAVE_CONFIG_H
#include <config.h>
#endif

#ifdef HAVE_ALLOCA_H
#include <alloca.h>
#endif

#ifdef HAVE_WCHAR_H
#include <wchar.h>
#endif

#define myAlloc(size, count)	alloca((size) * (count))

typedef unsigned short uchar2;

#ifdef USING_ICONV

#ifdef HAVE_WCHAR_T
int unicode_to_wchar(const uchar2 *instr, int inlen, wchar_t *outstr, int outlen);
int wchar_to_unicode(const wchar_t *instr, int inlen, uchar2 *outstr, int outlen);
#endif
int unicode_to_char(const uchar2 *instr, int inlen, char *outstr, int outlen);
int char_to_unicode(const char *instr, int inlen, uchar2 *outstr, int outlen);

#endif /* USING_ICONV */

#endif /* CURSES_SHARP_UNICODE_H */

