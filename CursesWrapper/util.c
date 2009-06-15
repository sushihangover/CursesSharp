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


WRAP_API const char *
wrap_unctrl(unsigned int c)
{
	return unctrl(c);
}

WRAP_API void
wrap_filter(void)
{
	filter();
}

WRAP_API void
wrap_use_env(int x)
{
	use_env((bool)x);
}

WRAP_API int
wrap_delay_output(int ms)
{
	return delay_output(ms);
}
