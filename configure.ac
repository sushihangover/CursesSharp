#                                               -*- Autoconf -*-
# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.63])
AC_INIT([Curses Sharp], [0.8], [curses-sharp-bugs@lists.sourceforge.net])
AC_SUBST([CURSESWRAPPER_VERSION], [0:0:0])

AM_INIT_AUTOMAKE([foreign])

LT_PREREQ([2.2])
LT_INIT([shared disable-static])

AC_CONFIG_SRCDIR([CursesWrapper/wrapper.c])

# Checks for programs.
AC_PROG_CC
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

# Checks for libraries.
AC_SEARCH_LIBS([initscr], [ncursesw ncurses curses])

AC_DEFINE([_XOPEN_SOURCE], [1], [X/Open Curses])
AC_DEFINE([_XOPEN_SOURCE_EXTENDED], [1], [X/Open Curses Extended])

# Checks for header files.

AC_CHECK_HEADERS([ncursesw/ncurses.h ncurses.h curses.h])
AC_CHECK_HEADERS([panel.h])

# Checks for typedefs, structures, and compiler characteristics.

# Checks for library functions.

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

