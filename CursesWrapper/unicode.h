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
int unicode_to_wchar(xreader* input, xwriter* output);
int wchar_to_unicode(xreader* input, xwriter* output);
#endif
int unicode_to_char(xreader* input, xwriter* output);
int char_to_unicode(xreader* input, xwriter* output);

#endif /* CURSES_SHARP_UNICODE_H */

