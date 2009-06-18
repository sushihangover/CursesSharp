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

#ifdef HAVE_CURSES_PANEL

#ifdef HAVE_PANEL_H
#include <panel.h>
#endif


WRAP_API PANEL *
wrap_new_panel(WINDOW *win)
{
	return new_panel(win);
}

WRAP_API int 
wrap_bottom_panel(PANEL *pan)
{
	return bottom_panel(pan);
}

WRAP_API int 
wrap_top_panel(PANEL *pan)
{
	return top_panel(pan);
}

WRAP_API int 
wrap_show_panel(PANEL *pan)
{
	return show_panel(pan);
}

WRAP_API void 
wrap_update_panels(void)
{
	update_panels();
}

WRAP_API int 
wrap_hide_panel(PANEL *pan)
{
	return hide_panel(pan);
}

WRAP_API WINDOW *
wrap_panel_window(PANEL *pan)
{
	return panel_window(pan);
}

WRAP_API int 
wrap_replace_panel(PANEL *pan, WINDOW *win)
{
	return replace_panel(pan, win);
}

WRAP_API int 
wrap_move_panel(PANEL *pan, int starty, int startx)
{
	return move_panel(pan, starty, startx);
}

WRAP_API int 
wrap_panel_hidden(PANEL *pan)
{
	return panel_hidden(pan);
}

WRAP_API PANEL *
wrap_panel_above(PANEL *pan)
{
	return panel_above(pan);
}

WRAP_API PANEL *
wrap_panel_below(PANEL *pan)
{
	return panel_below(pan);
}

WRAP_API int 
wrap_del_panel(PANEL *pan)
{
	return del_panel(pan);
}

#endif
