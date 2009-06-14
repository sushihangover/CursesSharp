#if defined(HAVE_NCURSESW_NCURSES_H)
#include <ncursesw/ncurses.h>
#elif defined(HAVE_NCURSES_H)
#include <ncurses.h>
#else
#include <curses.h>
#endif

#if defined(WIN32)
#define WRAP_API __declspec(dllexport)
#else
#define WRAP_API
#endif
