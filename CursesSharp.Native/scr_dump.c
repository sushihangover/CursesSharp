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
wrap_scr_dump(char *filename)
{
	return scr_dump(filename);
}

WRAP_API int 
wrap_scr_init(char *filename)
{
	return scr_init(filename);
}

WRAP_API int 
wrap_scr_restore(char *filename)
{
	return scr_restore(filename);
}

WRAP_API int 
wrap_scr_set(char *filename)
{
	return scr_set(filename);
}
