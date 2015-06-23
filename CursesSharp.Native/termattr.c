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
wrap_baudrate(void)
{
	return baudrate();
}

WRAP_API char 
wrap_erasechar(void)
{
	return erasechar();
}

WRAP_API char 
wrap_killchar(void)
{
	return killchar();
}

WRAP_API unsigned int
wrap_termattrs(void)
{
	return termattrs();
}

WRAP_API int
wrap_has_ic(void)
{
	return has_ic();
}

WRAP_API int
wrap_has_il(void)
{
	return has_il();
}

WRAP_API const char *
wrap_termname(void)
{
	return termname();
}

WRAP_API const char *
wrap_longname(void)
{
	return longname();
}
