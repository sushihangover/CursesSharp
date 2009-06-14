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

/*
  Name:								inopts

  Synopsis:
	int cbreak(void);
	int nocbreak(void);
	int echo(void);
	int noecho(void);
	int halfdelay(int tenths);
	int intrflush(WINDOW *win, bool bf);
	int keypad(WINDOW *win, bool bf);
	int meta(WINDOW *win, bool bf);
	int nl(void);
	int nonl(void);
	int nodelay(WINDOW *win, bool bf);
	int raw(void);
	int noraw(void);
	void noqiflush(void);
	void qiflush(void);
	int notimeout(WINDOW *win, bool bf);
	void timeout(int delay);
	void wtimeout(WINDOW *win, int delay);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	cbreak					Y	Y	Y
	nocbreak				Y	Y	Y
	echo					Y	Y	Y
	noecho					Y	Y	Y
	halfdelay				Y	-	Y
	intrflush				Y	-	Y
	keypad					Y	-	Y
	meta					Y	-	Y
	nl					Y	Y	Y
	nonl					Y	Y	Y
	nodelay					Y	-	Y
	notimeout				Y	-	Y
	raw					Y	Y	Y
	noraw					Y	Y	Y
	noqiflush				Y	-	Y
	qiflush					Y	-	Y
	timeout					Y	-	Y
	wtimeout				Y	-	Y
	typeahead				Y	-	Y
	crmode					-
	nocrmode				-
*/

WRAP_API int
wrap_cbreak(void)
{
	return cbreak();
}

WRAP_API int
wrap_nocbreak(void)
{
	return nocbreak();
}

WRAP_API int
wrap_echo(void)
{
	return echo();
}

WRAP_API int
wrap_noecho(void)
{
	return noecho();
}

WRAP_API int
wrap_halfdelay(int tenths)
{
	return halfdelay(tenths);
}

WRAP_API int
wrap_intrflush(WINDOW *win, int bf)
{
	return intrflush(win, bf);
}

WRAP_API int
wrap_keypad(WINDOW *win, int bf)
{
	return keypad(win, bf);
}

WRAP_API int
wrap_meta(WINDOW *win, int bf)
{
	return meta(win, bf);
}

WRAP_API int
wrap_nl(void)
{
	return nl();
}

WRAP_API int
wrap_nonl(void)
{
	return nonl();
}

WRAP_API int
wrap_nodelay(WINDOW *win, int bf)
{
	return nodelay(win, bf);
}

WRAP_API int
wrap_raw(void)
{
	return raw();
}

WRAP_API int
wrap_noraw(void)
{
	return noraw();
}

WRAP_API void
wrap_qiflush(void)
{
	qiflush();
}

WRAP_API void
wrap_noqiflush(void)
{
	noqiflush();
}

WRAP_API int
wrap_notimeout(WINDOW *win, int bf)
{
	return notimeout(win, bf);
}

WRAP_API void
wrap_wtimeout(WINDOW *win, int delay)
{
	wtimeout(win, delay);
}

