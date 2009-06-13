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

int
wrap_has_widechar(void)
{
	return sizeof(wchar_t) == 2;
}

int
wrap_LINES(void)
{
	return LINES;
}

int
wrap_COLS(void)
{
	return COLS;
}

int
wrap_COLORS(void)
{
	return COLORS;
}

int
wrap_COLOR_PAIRS(void)
{
	return COLOR_PAIRS;
}

int
wrap_TABSIZE(void)
{
	return TABSIZE;
}




/*
  Name:								getstr

  Synopsis:
	int getstr(char *str);
	int wgetstr(WINDOW *win, char *str);
	int mvgetstr(int y, int x, char *str);
	int mvwgetstr(WINDOW *win, int y, int x, char *str);
	int getnstr(char *str, int n);
	int wgetnstr(WINDOW *win, char *str, int n);
	int mvgetnstr(int y, int x, char *str, int n);
	int mvwgetnstr(WINDOW *win, int y, int x, char *str, int n);

	int get_wstr(wint_t *wstr);
	int wget_wstr(WINDOW *win, wint_t *wstr);
	int mvget_wstr(int y, int x, wint_t *wstr);
	int mvwget_wstr(WINDOW *win, int, int, wint_t *wstr);
	int getn_wstr(wint_t *wstr, int n);
	int wgetn_wstr(WINDOW *win, wint_t *wstr, int n);
	int mvgetn_wstr(int y, int x, wint_t *wstr, int n);
	int mvwgetn_wstr(WINDOW *win, int y, int x, wint_t *wstr, int n);

  Return Value:
	This functions return ERR on failure or any other value on 
	success.

  Portability				     X/Open    BSD    SYS V
	getstr					Y	Y	Y
	wgetstr					Y	Y	Y
	mvgetstr				Y	Y	Y
	mvwgetstr				Y	Y	Y
	getnstr					Y	-      4.0
	wgetnstr				Y	-      4.0
	mvgetnstr				Y	-       -
	mvwgetnstr				Y	-       -
	get_wstr				Y
	wget_wstr				Y
	mvget_wstr				Y
	mvwget_wstr				Y
	getn_wstr				Y
	wgetn_wstr				Y
	mvgetn_wstr				Y
	mvwgetn_wstr				Y
*/

/*
  Name:								inch

  Synopsis:
	chtype inch(void);
	chtype winch(WINDOW *win);
	chtype mvinch(int y, int x);
	chtype mvwinch(WINDOW *win, int y, int x);

	int in_wch(cchar_t *wcval);
	int win_wch(WINDOW *win, cchar_t *wcval);
	int mvin_wch(int y, int x, cchar_t *wcval);
	int mvwin_wch(WINDOW *win, int y, int x, cchar_t *wcval);

  Description:
	The inch() functions retrieve the character and attribute from 
	the current or specified window position, in the form of a 
	chtype. If a NULL window is specified, (chtype)ERR is returned.

	The in_wch() functions are the wide-character versions; instead 
	of returning a chtype, they store a cchar_t at the address 
	specified by wcval, and return OK or ERR. (No value is stored 
	when ERR is returned.) Note that in PDCurses, chtype and cchar_t 
	are the same.

  Portability				     X/Open    BSD    SYS V
	inch					Y	Y	Y
	winch					Y	Y	Y
	mvinch					Y	Y	Y
	mvwinch					Y	Y	Y
	in_wch					Y
	win_wch					Y
	mvin_wch				Y
	mvwin_wch				Y
*/

/*
  Name:								inchstr

  Synopsis:
	int inchstr(chtype *ch);
	int inchnstr(chtype *ch, int n);
	int winchstr(WINDOW *win, chtype *ch);
	int winchnstr(WINDOW *win, chtype *ch, int n);
	int mvinchstr(int y, int x, chtype *ch);
	int mvinchnstr(int y, int x, chtype *ch, int n);
	int mvwinchstr(WINDOW *, int y, int x, chtype *ch);
	int mvwinchnstr(WINDOW *, int y, int x, chtype *ch, int n);

	int in_wchstr(cchar_t *wch);
	int in_wchnstr(cchar_t *wch, int n);
	int win_wchstr(WINDOW *win, cchar_t *wch);
	int win_wchnstr(WINDOW *win, cchar_t *wch, int n);
	int mvin_wchstr(int y, int x, cchar_t *wch);
	int mvin_wchnstr(int y, int x, cchar_t *wch, int n);
	int mvwin_wchstr(WINDOW *win, int y, int x, cchar_t *wch);
	int mvwin_wchnstr(WINDOW *win, int y, int x, cchar_t *wch, int n);

  Return Value:
	All functions return the number of elements read, or ERR on 
	error.

  Portability				     X/Open    BSD    SYS V
	inchstr					Y	-      4.0
	winchstr				Y	-      4.0
	mvinchstr				Y	-      4.0
	mvwinchstr				Y	-      4.0
	inchnstr				Y	-      4.0
	winchnstr				Y	-      4.0
	mvinchnstr				Y	-      4.0
	mvwinchnstr				Y	-      4.0
	in_wchstr				Y
	win_wchstr				Y
	mvin_wchstr				Y
	mvwin_wchstr				Y
	in_wchnstr				Y
	win_wchnstr				Y
	mvin_wchnstr				Y
	mvwin_wchnstr				Y
*/

/*
  Name:								instr

  Synopsis:
	int instr(char *str);
	int innstr(char *str, int n);
	int winstr(WINDOW *win, char *str);
	int winnstr(WINDOW *win, char *str, int n);
	int mvinstr(int y, int x, char *str);
	int mvinnstr(int y, int x, char *str, int n);
	int mvwinstr(WINDOW *win, int y, int x, char *str);
	int mvwinnstr(WINDOW *win, int y, int x, char *str, int n);

	int inwstr(wchar_t *wstr);
	int innwstr(wchar_t *wstr, int n);
	int winwstr(WINDOW *win, wchar_t *wstr);
	int winnwstr(WINDOW *win, wchar_t *wstr, int n);
	int mvinwstr(int y, int x, wchar_t *wstr);
	int mvinnwstr(int y, int x, wchar_t *wstr, int n);
	int mvwinwstr(WINDOW *win, int y, int x, wchar_t *wstr);
	int mvwinnwstr(WINDOW *win, int y, int x, wchar_t *wstr, int n);

  Return Value:
	Upon successful completion, innstr(), mvinnstr(), mvwinnstr() 
	and winnstr() return the number of characters actually read into
	the string; instr(), mvinstr(), mvwinstr() and winstr() return 
	OK. Otherwise, all these functions return ERR.

  Portability				     X/Open    BSD    SYS V
	instr					Y	-      4.0
	winstr					Y	-      4.0
	mvinstr					Y	-      4.0
	mvwinstr				Y	-      4.0
	innstr					Y	-      4.0
	winnstr					Y	-      4.0
	mvinnstr				Y	-      4.0
	mvwinnstr				Y	-      4.0
	inwstr					Y
	winwstr					Y
	mvinwstr				Y
	mvwinwstr				Y
	innwstr					Y
	winnwstr				Y
	mvinnwstr				Y
	mvwinnwstr				Y
*/

/*
  Name:								mouse

  Synopsis:
	int mouse_set(unsigned long mbe);
	int mouse_on(unsigned long mbe);
	int mouse_off(unsigned long mbe);
	int request_mouse_pos(void);
	int map_button(unsigned long button);
	void wmouse_position(WINDOW *win, int *y, int *x);
	unsigned long getmouse(void);
	unsigned long getbmap(void);

	int mouseinterval(int wait);
	bool wenclose(const WINDOW *win, int y, int x);
	bool wmouse_trafo(const WINDOW *win, int *y, int *x, bool to_screen);
	bool mouse_trafo(int *y, int *x, bool to_screen);
	mmask_t mousemask(mmask_t mask, mmask_t *oldmask);
	int nc_getmouse(MEVENT *event);
	int ungetmouse(MEVENT *event);

  Description:
	As of PDCurses 3.0, there are two separate mouse interfaces: the
	classic interface, which is based on the undocumented Sys V
	mouse functions; and an ncurses-compatible interface. Both are
	active at all times, and you can mix and match functions from
	each, though it's not recommended. The ncurses interface is
	essentially an emulation layer built on top of the classic
	interface; it's here to allow easier porting of ncurses apps.

	The classic interface: mouse_set(), mouse_on(), mouse_off(),
	request_mouse_pos(), map_button(), wmouse_position(),
	getmouse(), and getbmap(). An application using this interface
	would start by calling mouse_set() or mouse_on() with a non-zero
	value, often ALL_MOUSE_EVENTS. Then it would check for a
	KEY_MOUSE return from getch(). If found, it would call
	request_mouse_pos() to get the current mouse status.

	mouse_set(), mouse_on() and mouse_off() are analagous to
	attrset(), attron() and attroff().  These functions set the
	mouse button events to trap.  The button masks used in these
	functions are defined in curses.h and can be or'ed together.
	They are the group of masks starting with BUTTON1_RELEASED.

	request_mouse_pos() requests curses to fill in the Mouse_status
	structure with the current state of the mouse.

	map_button() enables the specified mouse action to activate the
	Soft Label Keys if the action occurs over the area of the screen
	where the Soft Label Keys are displayed.  The mouse actions are
	defined in curses.h in the group that starts with BUTTON_RELEASED.

	wmouse_position() determines if the current mouse position is
	within the window passed as an argument.  If the mouse is
	outside the current window, -1 is returned in the y and x
	arguments; otherwise the y and x coordinates of the mouse
	(relative to the top left corner of the window) are returned in
	y and x.

	getmouse() returns the current status of the trapped mouse
	buttons as set by mouse_set() or mouse_on().

	getbmap() returns the current status of the button action used
	to map a mouse action to the Soft Label Keys as set by the
	map_button() function.

	The ncurses interface: mouseinterval(), wenclose(),
	wmouse_trafo(), mouse_trafo(), mousemask(), nc_getmouse(), and
	ungetmouse(). A typical application using this interface would
	start by calling mousemask() with a non-zero value, often
	ALL_MOUSE_EVENTS. Then it would check for a KEY_MOUSE return
	from getch(). If found, it would call nc_getmouse() to get the
	current mouse status.

	mouseinterval() sets the timeout for a mouse click. On all
	current platforms, PDCurses receives mouse button press and
	release events, but must synthesize click events. It does this
	by checking whether a release event is queued up after a press
	event. If it gets a press event, and there are no more events
	waiting, it will wait for the timeout interval, then check again
	for a release. A press followed by a release is reported as
	BUTTON_CLICKED; otherwise it's passed through as BUTTON_PRESSED.
	The default timeout is 150ms; valid values are 0 (no clicks
	reported) through 1000ms. In x11, the timeout can also be set
	via the clickPeriod resource. The return value from
	mouseinterval() is the old timeout. To check the old value
	without setting a new one, call it with a parameter of -1. Note 
	that although there's no classic equivalent for this function 
	(apart from the clickPeriod resource), the value set applies in 
	both interfaces.

	wenclose() reports whether the given screen-relative y, x
	coordinates fall within the given window.

	wmouse_trafo() converts between screen-relative and window-
	relative coordinates. A to_screen parameter of TRUE means to
	convert from window to screen; otherwise the reverse. The
	function returns FALSE if the coordinates aren't within the
	window, or if any of the parameters are NULL. The coordinates
	have been converted when the function returns TRUE.

	mouse_trafo() is the stdscr version of wmouse_trafo().

	mousemask() is nearly equivalent to mouse_set(), but instead of
	OK/ERR, it returns the value of the mask after setting it. (This
	isn't necessarily the same value passed in, since the mask could
	be altered on some platforms.) And if the second parameter is a 
	non-null pointer, mousemask() stores the previous mask value 
	there. Also, since the ncurses interface doesn't work with 
	PDCurses' BUTTON_MOVED events, mousemask() filters them out.

	nc_getmouse() returns the current mouse status in an MEVENT 
	struct. This is equivalent to ncurses' getmouse(), renamed to 
	avoid conflict with PDCurses' getmouse(). But if you define 
	NCURSES_MOUSE_VERSION (preferably as 2) before including 
	curses.h, it defines getmouse() to nc_getmouse(), along with a 
	few other redefintions needed for compatibility with ncurses 
	code. nc_getmouse() calls request_mouse_pos(), which (not 
	getmouse()) is the classic equivalent.

	ungetmouse() is the mouse equivalent of ungetch(). However, 
	PDCurses doesn't maintain a queue of mouse events; only one can 
	be pushed back, and it can overwrite or be overwritten by real 
	mouse events.

  Portability				     X/Open    BSD    SYS V
	mouse_set				-	-      4.0
	mouse_on				-	-      4.0
	mouse_off				-	-      4.0
	request_mouse_pos			-	-      4.0
	map_button				-	-      4.0
	wmouse_position				-	-      4.0
	getmouse				-	-      4.0
	getbmap					-	-      4.0
	mouseinterval				-	-	-
	wenclose				-	-	-
	wmouse_trafo				-	-	-
	mouse_trafo				-	-	-
	mousemask				-	-	-
	nc_getmouse				-	-	-
	ungetmouse				-	-	-
*/

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

/*
  Name:								pad

  Synopsis:
	WINDOW *newpad(int nlines, int ncols);
	WINDOW *subpad(WINDOW *orig, int nlines, int ncols,
		       int begy, int begx);
	int prefresh(WINDOW *win, int py, int px, int sy1, int sx1,
		     int sy2, int sx2);
	int pnoutrefresh(WINDOW *w, int py, int px, int sy1, int sx1,
			 int sy2, int sx2);
	int pechochar(WINDOW *pad, chtype ch);
	int pecho_wchar(WINDOW *pad, const cchar_t *wch);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	newpad					Y	-	Y
	subpad					Y	-	Y
	prefresh				Y	-	Y
	pnoutrefresh				Y	-	Y
	pechochar				Y	-      3.0
	pecho_wchar				Y
*/

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
