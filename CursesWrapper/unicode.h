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

#include "xbuffer.h"

#define BUFFER_SIZE 128


#ifdef HAVE_WCHAR_T
int wchar_validate(wchar_t wc);
int unicode_to_wchar(const xbuffer* input, xbuffer* output);
int wchar_to_unicode(const xbuffer* input, xbuffer* output);
#endif
int unicode_to_char(const xbuffer* input, xbuffer* output);
int char_to_unicode(const xbuffer* input, xbuffer* output);

#endif /* CURSES_SHARP_UNICODE_H */

