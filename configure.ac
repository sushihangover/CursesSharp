#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.62])
AC_INIT([Curses Sharp], [0.8], [curses-sharp-bugs@lists.sourceforge.net])
AC_CONFIG_SRCDIR([CursesWrapper/wrapper.c])

AM_INIT_AUTOMAKE([foreign])

AC_PROG_CC
AC_PROG_CC_C_O
AC_PROG_LIBTOOL

dnl pkg-config
PKG_PROG_PKG_CONFIG
if test "x$PKG_CONFIG" = "x"; then
	AC_MSG_ERROR([You need to install pkg-config])
fi

dnl Mono runtime
AC_PATH_PROG([MONO], [mono], [no])
if test "x$MONO" = "xno"; then
	AC_MSG_ERROR([Mono runtime not found])
fi

dnl C# compiler
AC_PATH_PROG([CSC], [gmcs], [no])
if test "x$CSC" = "xno"; then
	AC_MSG_ERROR([Can't find "gmcs" in your path])
fi

AC_DEFINE([_XOPEN_SOURCE], [1], [X/Open conformance])
AC_DEFINE([_XOPEN_SOURCE_EXTENDED], [1], [X/Open Extended conformance])

AC_ARG_ENABLE(widechar, 
	AS_HELP_STRING([--disable-widechar], [do not use wchar_t]),
	[have_widechar=no],
	[have_widechar=yes]
)

wchar_includes="\
#ifdef HAVE_WCHAR_H
#include <wchar.h>
#endif"

if test "x$have_widechar" != "xno"; then
	AC_C_BIGENDIAN([have_widechar=no])
fi
if test "x$have_widechar" != "xno"; then
	AC_CHECK_HEADERS([wchar.h], [], [have_widechar=no])
fi
if test "x$have_widechar" != "xno"; then
	AC_CHECK_TYPES([wchar_t, wint_t], 
		[], 
		[have_widechar=no], 
		[$wchar_includes]
	)
fi
if test "x$have_widechar" != "xno"; then
	AC_CHECK_SIZEOF([wchar_t], [], [$wchar_includes])
	if test "x$ac_cv_sizeof_wchar_t" != "x2"; then
		have_widechar=no
	fi
fi

curses_includes="\
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
#endif"

if test "x$have_widechar" != "xno"; then
	AC_CHECK_HEADERS([ncursesw/ncurses.h])
fi
AC_CHECK_HEADERS([ncurses.h curses.h])

if test "x$have_widechar" != "xno"; then
	AC_CHECK_DECL([addwstr], [], [have_widechar=no], [
		#define HAVE_USE_WIDECHAR 1
		$curses_includes
	])
fi

save_LIBS="$LIBS"
CURSES_LDFLAGS=
if test "x$have_widechar" != "xno"; then
	AC_SEARCH_LIBS([addwstr], [ncursesw ncurses curses],
		[CURSES_LDFLAGS="$ac_cv_search_initscr"],
		[have_widechar=no]
	)
fi

if test "x$have_widechar" = "xno"; then
	AC_SEARCH_LIBS([initscr], [ncurses curses],
		[CURSES_LDFLAGS="$ac_cv_search_initscr"],
		[AC_MSG_ERROR([Can't find curses implementation])]
	)
fi
LIBS="$save_LIBS"

AC_SUBST([CURSES_LDFLAGS])

CursesSharp_CSCFLAGS=""

AM_CONDITIONAL([HAVE_USE_WIDECHAR], [test "x$have_widechar" != "xno"])
if test "x$have_widechar" != "xno"; then
	AC_DEFINE([HAVE_USE_WIDECHAR], [1],
		  [Define if wchar_t is compatible with .NET char]
	)
	CursesSharp_CSCFLAGS="-define:HAVE_USE_WIDECHAR $CursesSharp_CSCFLAGS"
fi

AC_ARG_ENABLE(panel, 
	AS_HELP_STRING([--disable-panel],
		[disable support for curses panel module]),
	[curses_panel=no],
	[curses_panel=yes]
)
if test "x$curses_panel" != "xno"; then
	AC_CHECK_HEADERS([panel.h], [], [curses_panel=no])
fi
AM_CONDITIONAL([HAVE_CURSES_PANEL], [test "x$curses_panel" != "xno"])
if test "x$curses_panel" != "xno"; then
	AC_DEFINE([HAVE_CURSES_PANEL], [1],
		  [Define if using curses panel module]
	)
	CursesSharp_CSCFLAGS="-define:HAVE_CURSES_PANEL $CursesSharp_CSCFLAGS"
fi

AC_ARG_ENABLE(mouse, 
	AS_HELP_STRING([--disable-mouse],
		[disable support for curses mouse]),
	[curses_mouse=no],
	[curses_mouse=yes]
)
if test "x$curses_mouse" != "xno"; then
	AC_CHECK_DECL([NCURSES_MOUSE_VERSION], [], [ncurses_mouse=no], [
		$curses_includes
	])
fi
AM_CONDITIONAL([HAVE_CURSES_MOUSE], [test "x$curses_mouse" != "xno"])
if test "x$curses_mouse" != "xno"; then
	AC_DEFINE([HAVE_CURSES_MOUSE], [1],
		  [Define if using curses mouse API]
	)
	CursesSharp_CSCFLAGS="-define:HAVE_CURSES_MOUSE $CursesSharp_CSCFLAGS"
fi

AC_SUBST([CursesSharp_CSCFLAGS])


AC_CONFIG_HEADERS([config.h])
AC_CONFIG_FILES([
	Makefile 
	CursesWrapper/Makefile 
	AttributeGen/Makefile
	CursesSharp/Makefile
	CursesSharp.pc
])
AC_CONFIG_FILES([
	FireworkDemo/Makefile
	FireworkDemo/FireworkDemo
	RainDemo/Makefile
	RainDemo/RainDemo
])

AC_OUTPUT

