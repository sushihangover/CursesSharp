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
  Name:								slk

  Synopsis:
	int slk_init(int fmt);
	int slk_set(int labnum, const char *label, int justify);
	int slk_refresh(void);
	int slk_noutrefresh(void);
	char *slk_label(int labnum);
	int slk_clear(void);
	int slk_restore(void);
	int slk_touch(void);
	int slk_attron(const chtype attrs);
	int slk_attr_on(const attr_t attrs, void *opts);
	int slk_attrset(const chtype attrs);
	int slk_attr_set(const attr_t attrs, short color_pair, void *opts);
	int slk_attroff(const chtype attrs);
	int slk_attr_off(const attr_t attrs, void *opts);
	int slk_color(short color_pair);

	int slk_wset(int labnum, const wchar_t *label, int justify);

	int PDC_mouse_in_slk(int y, int x);
	void PDC_slk_free(void);
	void PDC_slk_initialize(void);

	wchar_t *slk_wlabel(int labnum)

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	slk_init				Y	-	Y
	slk_set					Y	-	Y
	slk_refresh				Y	-	Y
	slk_noutrefresh				Y	-	Y
	slk_label				Y	-	Y
	slk_clear				Y	-	Y
	slk_restore				Y	-	Y
	slk_touch				Y	-	Y
	slk_attron				Y	-	Y
	slk_attrset				Y	-	Y
	slk_attroff				Y	-	Y
	slk_attr_on				Y
	slk_attr_set				Y
	slk_attr_off				Y
	slk_wset				Y
	PDC_mouse_in_slk			-	-	-
	PDC_slk_free				-	-	-
	PDC_slk_initialize			-	-	-
	slk_wlabel				-	-	-
*/

