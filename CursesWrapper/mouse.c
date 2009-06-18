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


#ifdef HAVE_CURSES_MOUSE

struct WrapMEvent 
{
	int id;
	int x;
	int y;
	int z;
	unsigned int bstate;
};

STATIC_ASSERT(sizeof(struct WrapMEvent) == 20);

WRAP_API int
wrap_has_mouse(void)
{
#ifdef WIN32
	return 1;
#elif defined(NCURSES_VERSION)
	return (bool)has_mouse();
#endif
}

WRAP_API int 
wrap_getmouse(struct WrapMEvent *wrap_mevent)
{
	MEVENT mevent;
	int ret = getmouse(&mevent);
	if (ret != ERR)
	{
		wrap_mevent->id = mevent.id;
		wrap_mevent->x = mevent.x;
		wrap_mevent->y = mevent.y;
		wrap_mevent->z = mevent.z;
		wrap_mevent->bstate = (unsigned int)mevent.bstate;
	}
	return ret;
}

WRAP_API int 
wrap_ungetmouse(struct WrapMEvent *wrap_mevent)
{
	MEVENT mevent;
	mevent.id = (short)wrap_mevent->id;
	mevent.x = (int)wrap_mevent->x;
	mevent.y = (int)wrap_mevent->y;
	mevent.z = (int)wrap_mevent->z;
	mevent.bstate = (mmask_t)wrap_mevent->bstate;
	return ungetmouse(&mevent);
}

WRAP_API unsigned int
wrap_mousemask(unsigned int mask, unsigned int *oldmask)
{
	return (unsigned int)mousemask((mmask_t)mask, (mmask_t*)oldmask);
}

WRAP_API int
wrap_wenclose(WINDOW *win, int y, int x)
{
	return wenclose(win, y, x);
}

WRAP_API int
wrap_wmouse_trafo(WINDOW *win, int *y, int *x, int to_screen)
{
	return wmouse_trafo(win, y, x, (bool)to_screen);
}

WRAP_API int 
wrap_mouseinterval(int wait)
{
	return mouseinterval(wait);
}

#endif
