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

#include <curses.h>

/*
  Name:								keyname

  Synopsis:
	char *keyname(int key);

	char *key_name(wchar_t c);

	bool has_key(int key);

  Description:
	keyname() returns a string corresponding to the argument key. 
	key may be any key returned by wgetch().

	key_name() is the wide-character version. It takes a wchar_t 
	parameter, but still returns a char *.

	has_key() returns TRUE for recognized keys, FALSE otherwise. 
	This function is an ncurses extension.

  Portability				     X/Open    BSD    SYS V
	keyname					Y	-      3.0
	key_name				Y
	has_key					-	-	-
*/

char *
wrap_keyname(int key)
{
	return keyname(key);
}

char *
wrap_key_name(wchar_t c)
{
	return key_name(c);
}

int
wrap_has_key(int key)
{
	return has_key(key);
}
