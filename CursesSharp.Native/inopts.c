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
	return intrflush(win, (bool)bf);
}

WRAP_API int
wrap_keypad(WINDOW *win, int bf)
{
	return keypad(win, (bool)bf);
}

WRAP_API int
wrap_meta(WINDOW *win, int bf)
{
	return meta(win, (bool)bf);
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
	return nodelay(win, (bool)bf);
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
	return notimeout(win, (bool)bf);
}

WRAP_API void
wrap_wtimeout(WINDOW *win, int delay)
{
	wtimeout(win, delay);
}

