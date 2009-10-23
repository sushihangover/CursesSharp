#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.62])
AC_INIT([Curses Sharp], [0.8], [curses-sharp-bugs@lists.sourceforge.net])
AC_CONFIG_MACRO_DIR([m4])
AC_CONFIG_SRCDIR([CursesWrapper/wrapper.c])

CPPFLAGS="${CPPFLAGS}"
CFLAGS="${CFLAGS}"

AC_CANONICAL_SYSTEM
case "$target_os" in
	freebsd*)
		CPPFLAGS="${CPPFLAGS} -I/usr/local/include"
	;;
esac

AM_INIT_AUTOMAKE([foreign])

AC_PROG_CC		
AC_PROG_CC_C_O
AC_PROG_LIBTOOL
AC_HEADER_STDC

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
	AC_MSG_ERROR([Cannot find "gmcs" in your path])
fi

AC_DEFINE([_XOPEN_SOURCE], [1], [X/Open conformance])
AC_DEFINE([_XOPEN_SOURCE_EXTENDED], [1], [X/Open Extended conformance])

AC_ARG_ENABLE(wide, 
	AS_HELP_STRING([--disable-wide], 
		[do not use wide character curses functions]
	),
	[curses_wide=no],
	[curses_wide=yes]
)

wchar_includes="\
#ifdef HAVE_WCHAR_H
#include <wchar.h>
#endif"

dnl check for basic wide character types
AC_CHECK_HEADERS([wchar.h], [], [])
AC_CHECK_TYPES([wchar_t, wint_t], [], [], [$wchar_includes])
AC_CHECK_SIZEOF([wchar_t], [], [$wchar_includes])

if test "x$ac_cv_type_wchar_t" != "xyes"; then
	curses_wide=no
	AC_MSG_NOTICE([Disabling wide character support])
fi

curses_includes="\
#if defined(CURSES_WIDE)
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

AC_CHECK_HEADERS([ncursesw/ncurses.h ncurses.h curses.h])

dnl check curses headers for declarations of wide character functions
if test "x$curses_wide" != "xno"; then
	AC_CHECK_DECL([addwstr], [], [
			curses_wide=no
			AC_MSG_NOTICE([Disabling wide character support])
		], [
			#define CURSES_WIDE 1
			$curses_includes
		]
	)
fi

save_LIBS="$LIBS"
CURSES_CFLAGS="-Werror"
CURSES_LDFLAGS=

dnl check for a curses library with wide character functions
dnl disable wide character support if not found
if test "x$curses_wide" != "xno"; then
	AC_SEARCH_LIBS([addwstr], [ncursesw ncurses curses],
		[CURSES_LDFLAGS="$ac_cv_search_addwstr"], [
			curses_wide=no
			AC_MSG_NOTICE([Disabling wide character support])
		]
	)
fi

dnl if a wide character curses library was not found in previous step
dnl then check for an 8-bit character one
if test "x$curses_wide" = "xno"; then
	AC_SEARCH_LIBS([initscr], [ncurses curses],
		[CURSES_LDFLAGS="$ac_cv_search_initscr"],
		[AC_MSG_ERROR([Cannot find curses implementation])]
	)
fi

LIBS="$save_LIBS"

iconv_includes="\
#ifdef HAVE_WCHAR_H
#include <wchar.h>
#endif
#ifdef HAVE_ICONV_H
#include <iconv.h>
#endif"

if test "x$curses_wide" = "xno" -o "x$ac_cv_sizeof_wchar_t" != "x2"; then
	AC_FUNC_ALLOCA
	if test "x$ac_cv_func_alloca_works" != "xyes"; then
		AC_MSG_ERROR([Function alloca() is missing or not working!])
	fi

	AC_CHECK_HEADERS([iconv.h], [], [])
	AC_CHECK_DECLS([iconv_open, iconv_close, iconv],
		[working_iconv=yes], [working_iconv=no], [$iconv_includes]
	)
	if test "x$working_iconv" != "xyes"; then
		AC_MSG_ERROR([Function iconv() is missing or not working!])
	fi
	AC_DEFINE([USING_ICONV], [1],
		  [Define if iconv() function is used]
	)
	AC_COMPILE_IFELSE(AC_LANG_PROGRAM([$iconv_includes], [
		extern size_t iconv(iconv_t, char **, size_t *, char **, size_t *);
		]),
		[],
		[AC_DEFINE([ICONV_CONST], [1],
			[Define if 2nd parameter of iconv() needs to be const]
		)]
	)
fi

AC_SUBST([CURSES_CFLAGS])
AC_SUBST([CURSES_LDFLAGS])

if test "x$curses_wide" != "xno"; then
	AC_DEFINE([CURSES_WIDE], [1],
		  [Define if using wide character curses functions]
	)
fi

CursesSharp_CSCFLAGS=""

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
AC_SUBST([CFLAGS])


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

