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
wrap_overlay(WINDOW *src_w, WINDOW *dst_w)
{
	return overlay(src_w, dst_w);
}

WRAP_API int
wrap_overwrite(WINDOW *src_w, WINDOW *dst_w)
{
	return overwrite(src_w, dst_w);
}

WRAP_API int
wrap_copywin(WINDOW *src_w, WINDOW *dst_w, int src_tr, int src_tc, int dst_tr,
			 int dst_tc, int dst_br, int dst_bc, int overlay)
{
	return copywin(src_w, dst_w, src_tr, src_tc, dst_tr, dst_tc, dst_br, dst_bc, overlay);
}
