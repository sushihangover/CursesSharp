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
  Name:								overlay

  Synopsis:
	int overlay(const WINDOW *src_w, WINDOW *dst_w)
	int overwrite(const WINDOW *src_w, WINDOW *dst_w)
	int copywin(const WINDOW *src_w, WINDOW *dst_w, int src_tr,
		    int src_tc, int dst_tr, int dst_tc, int dst_br,
		    int dst_bc, bool overlay)

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	overlay					Y	Y	Y
	overwrite				Y	Y	Y
	copywin					Y	-      3.0
*/

int 
wrap_overlay(WINDOW *src_w, WINDOW *dst_w)
{
	return overlay(src_w, dst_w);
}

int 
wrap_overwrite(WINDOW *src_w, WINDOW *dst_w)
{
	return overwrite(src_w, dst_w);
}

int 
wrap_copywin(WINDOW *src_w, WINDOW *dst_w, int src_tr, int src_tc, int dst_tr,
			 int dst_tc, int dst_br, int dst_bc, int overlay)
{
	return copywin(src_w, dst_w, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
}
