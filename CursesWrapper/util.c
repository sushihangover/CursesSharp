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
  Name:								util

  Synopsis:
	char *unctrl(chtype c);
	void filter(void);
	void use_env(bool x);
	int delay_output(int ms);

	int getcchar(const cchar_t *wcval, wchar_t *wch, attr_t *attrs,
		     short *color_pair, void *opts);
	int setcchar(cchar_t *wcval, const wchar_t *wch, const attr_t attrs,
		     short color_pair, const void *opts);
	wchar_t *wunctrl(cchar_t *wc);

  Return Value:
	unctrl() and wunctrl() return NULL on failure. delay_output() 
	always returns OK.

	getcchar() returns the number of wide characters wcval points to 
	when wch is NULL; when it's not, getcchar() returns OK or ERR. 

	setcchar() returns OK or ERR.

  Portability				     X/Open    BSD    SYS V
	unctrl					Y	Y	Y
	filter					Y	-      3.0
	use_env					Y	-      4.0
	delay_output				Y	Y	Y
	getcchar				Y
	setcchar				Y
	wunctrl					Y
	PDC_mbtowc				-	-	-
	PDC_mbstowcs				-	-	-
	PDC_wcstombs				-	-	-
*/

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
