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

#ifdef HAVE_USE_WIDECHAR
STATIC_ASSERT(sizeof(wchar_t) == 2);
#endif


WRAP_API int
wrap_LINES(void)
{
	return LINES;
}

WRAP_API int
wrap_COLS(void)
{
	return COLS;
}

WRAP_API int
wrap_COLORS(void)
{
	return COLORS;
}

WRAP_API int
wrap_COLOR_PAIRS(void)
{
	return COLOR_PAIRS;
}

WRAP_API int
wrap_TABSIZE(void)
{
	return TABSIZE;
}





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

/*
  Name:								scr_dump

  Synopsis:
	int putwin(WINDOW *win, FILE *filep);
	WINDOW *getwin(FILE *filep);
	int scr_dump(const char *filename);
	int scr_init(const char *filename);
	int scr_restore(const char *filename);
	int scr_set(const char *filename);

  Return Value:
	On successful completion, getwin() returns a pointer to the 
	window it created. Otherwise, it returns a null pointer. Other 
	functions return OK or ERR.

  Portability				     X/Open    BSD    SYS V
	putwin					Y
	getwin					Y
	scr_dump				Y
	scr_init				Y
	scr_restore				Y
	scr_set					Y
*/

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

/*
  Name:								termattr

  Synopsis:
	int baudrate(void);
	char erasechar(void);
	bool has_ic(void);
	bool has_il(void);
	char killchar(void);
	char *longname(void);
	chtype termattrs(void);
	attr_t term_attrs(void);
	char *termname(void);

	int erasewchar(wchar_t *ch);
	int killwchar(wchar_t *ch);

	char wordchar(void);

  Description:
	baudrate() is supposed to return the output speed of the 
	terminal. In PDCurses, it simply returns INT_MAX.

	has_ic and has_il() return TRUE. These functions have meaning in 
	some other implementations of curses.

	erasechar() and killchar() return ^H and ^U, respectively -- the 
	ERASE and KILL characters. In other curses implementations, 
	these may vary by terminal type. erasewchar() and killwchar() 
	are the wide-character versions; they take a pointer to a 
	location in which to store the character, and return OK or ERR.

	longname() returns a pointer to a static area containing a
	verbose description of the current terminal. The maximum length
	of the string is 128 characters.  It is defined only after the
	call to initscr() or newterm().

	termname() returns a pointer to a static area containing a
	short description of the current terminal (14 characters).

	termattrs() returns a logical OR of all video attributes
	supported by the terminal.

	wordchar() is a PDCurses extension of the concept behind the 
	functions erasechar() and killchar(), returning the "delete 
	word" character, ^W.

  Portability				     X/Open    BSD    SYS V
	baudrate				Y	Y	Y
	erasechar				Y	Y	Y
	has_ic					Y	Y	Y
	has_il					Y	Y	Y
	killchar				Y	Y	Y
	longname				Y	Y	Y
	termattrs				Y	Y	Y
	termname				Y	Y	Y
	erasewchar				Y
	killwchar				Y
	term_attrs				Y
	wordchar				-	-	-
*/

/*
  Name:								terminfo

  Synopsis:
	int mvcur(int oldrow, int oldcol, int newrow, int newcol);
	int del_curterm(TERMINAL *);
	int putp(const char *);
	int restartterm(const char *, int, int *);
	TERMINAL *set_curterm(TERMINAL *);
	int setterm(const char *term);
	int setupterm(const char *, int, int *);
	int tgetent(char *, const char *);
	int tgetflag(const char *);
	int tgetnum(const char *);
	char *tgetstr(const char *, char **);
	char *tgoto(const char *, int, int);
	int tigetflag(const char *);
	int tigetnum(const char *);
	char *tigetstr(const char *);
	char *tparm(const char *,long, long, long, long, long, long,
		long, long, long);
	int tputs(const char *, int, int (*)(int));
	int vidattr(chtype attr);
	int vid_attr(attr_t attr, short color_pair, void *opt);
	int vidputs(chtype attr, int (*putfunc)(int));
	int vid_puts(attr_t attr, short color_pair, void *opt,
		int (*putfunc)(int));

  Description:
	mvcur() lets you move the physical cursor without updating any 
	window cursor positions. It returns OK or ERR.

	The rest of these functions are currently implemented as stubs, 
	returning the appropriate errors and doing nothing else.

  Portability				     X/Open    BSD    SYS V
	mvcur					Y	Y	Y
*/

/*
  Name:                                                          sb

  Synopsis:
	int sb_init(void)
	int sb_set_horz(int total, int viewport, int cur)
	int sb_set_vert(int total, int viewport, int cur)
	int sb_get_horz(int *total, int *viewport, int *cur)
	int sb_get_vert(int *total, int *viewport, int *cur)
	int sb_refresh(void);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	sb_init					-	-	-
	sb_set_horz				-	-	-
	sb_set_vert				-	-	-
	sb_get_horz				-	-	-
	sb_get_vert				-	-	-
	sb_refresh				-	-	-

*/
