#ifndef CURSES_SHARP_UNICODE_H
#define CURSES_SHARP_UNICODE_H

#ifdef HAVE_CONFIG_H
#include <config.h>
#endif

#ifdef HAVE_STDLIB_H
#include <stdlib.h>
#endif

#ifdef HAVE_WCHAR_H
#include <wchar.h>
#endif

#define BUFFER_SIZE 128


typedef unsigned short uchar2;

#ifdef HAVE_WCHAR_T
int unicode_to_wchar(const uchar2 *instr, int inlen, wchar_t *outstr, int *outlen);
int unicode_to_wchar_alloc(const uchar2 *instr, int inlen, wchar_t **outstr, int *outlen);
int wchar_to_unicode(const wchar_t *instr, int inlen, uchar2 *outstr, int *outlen);
#endif
int unicode_to_char(const uchar2 *instr, int inlen, char *outstr, int *outlen);
int char_to_unicode(const char *instr, int inlen, uchar2 *outstr, int *outlen);

#endif /* CURSES_SHARP_UNICODE_H */

