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
  Name:								panel

  Synopsis:
	int bottom_panel(PANEL *pan);
	int del_panel(PANEL *pan);
	int hide_panel(PANEL *pan);
	int move_panel(PANEL *pan, int starty, int startx);
	PANEL *new_panel(WINDOW *win);
	PANEL *panel_above(const PANEL *pan);
	PANEL *panel_below(const PANEL *pan);
	int panel_hidden(const PANEL *pan);
	const void *panel_userptr(const PANEL *pan);
	WINDOW *panel_window(const PANEL *pan);
	int replace_panel(PANEL *pan, WINDOW *win);
	int set_panel_userptr(PANEL *pan, const void *uptr);
	int show_panel(PANEL *pan);
	int top_panel(PANEL *pan);
	void update_panels(void);

  Return Value:
	Each routine that returns a pointer to an object returns NULL if 
	an error occurs. Each panel routine that returns an integer, 
	returns OK if it executes successfully and ERR if it does not.

  Portability				     X/Open    BSD    SYS V
	bottom_panel				-	-	Y
	del_panel				-	-	Y
	hide_panel				-	-	Y
	move_panel				-	-	Y
	new_panel				-	-	Y
	panel_above				-	-	Y
	panel_below				-	-	Y
	panel_hidden				-	-	Y
	panel_userptr				-	-	Y
	panel_window				-	-	Y
	replace_panel				-	-	Y
	set_panel_userptr			-	-	Y
	show_panel				-	-	Y
	top_panel				-	-	Y
	update_panels				-	-	Y
*/

