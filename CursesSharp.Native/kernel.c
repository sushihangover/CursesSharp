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
wrap_def_prog_mode(void)
{
	return def_prog_mode();
}

WRAP_API int
wrap_def_shell_mode(void)
{
	return def_shell_mode();
}

WRAP_API int
wrap_reset_prog_mode(void)
{
	return reset_prog_mode();
}

WRAP_API int
wrap_reset_shell_mode(void)
{
	return reset_shell_mode();
}

WRAP_API int
wrap_resetty(void)
{
	return resetty();
}

WRAP_API int
wrap_savetty(void)
{
	return savetty();
}

WRAP_API void
wrap_getsyx(int *y, int *x)
{
	getsyx(*y, *x);
}

WRAP_API void
wrap_setsyx(int y, int x)
{
	setsyx(y, x);
}

WRAP_API int
wrap_ripoffline(int line, int (*init)(WINDOW *, int))
{
	return ripoffline(line, init);
}

WRAP_API int
wrap_napms(int ms)
{
	return napms(ms);
}

WRAP_API int
wrap_curs_set(int visibility)
{
	return curs_set(visibility);
}

