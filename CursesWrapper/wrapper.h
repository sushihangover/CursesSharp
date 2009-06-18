#ifdef HAVE_CONFIG_H
#include <config.h>
#endif

#if defined(HAVE_USE_WIDECHAR)
# if defined(HAVE_NCURSESW_NCURSES_H)
#  include <ncursesw/ncurses.h>
# endif
#endif
#if defined(HAVE_NCURSES_H)
# include <ncurses.h>
#endif
#if defined(HAVE_CURSES_H)
# include <curses.h>
#endif

#if defined(WIN32)
#define WRAP_API __declspec(dllexport)
#else
#define WRAP_API
#endif

#define _JOIN_AGAIN_(x, y)	x ## y
#define _JOIN_(x, y)		_JOIN_AGAIN_(x, y)

#define STATIC_ASSERT(e)	typedef char _JOIN_(assertion_failed_at_line_, __LINE__) [(e) ? 1 : -1]
