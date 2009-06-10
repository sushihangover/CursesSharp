#include <curses.h>

/*
  Name:								addchstr

  Synopsis:
	int addchstr(const chtype *ch);
	int addchnstr(const chtype *ch, int n);
	int waddchstr(WINDOW *win, const chtype *ch);
	int waddchnstr(WINDOW *win, const chtype *ch, int n);
	int mvaddchstr(int y, int x, const chtype *ch);
	int mvaddchnstr(int y, int x, const chtype *ch, int n);
	int mvwaddchstr(WINDOW *, int y, int x, const chtype *ch);
	int mvwaddchnstr(WINDOW *, int y, int x, const chtype *ch, int n);

	int add_wchstr(const cchar_t *wch);
	int add_wchnstr(const cchar_t *wch, int n);
	int wadd_wchstr(WINDOW *win, const cchar_t *wch);
	int wadd_wchnstr(WINDOW *win, const cchar_t *wch, int n);
	int mvadd_wchstr(int y, int x, const cchar_t *wch);
	int mvadd_wchnstr(int y, int x, const cchar_t *wch, int n);
	int mvwadd_wchstr(WINDOW *win, int y, int x, const cchar_t *wch);
	int mvwadd_wchnstr(WINDOW *win, int y, int x, const cchar_t *wch,
		int n);

  Return Value:
	All functions return OK or ERR.

  Portability				     X/Open    BSD    SYS V
	addchstr				Y	-      4.0
	waddchstr				Y	-      4.0
	mvaddchstr				Y	-      4.0
	mvwaddchstr				Y	-      4.0
	addchnstr				Y	-      4.0
	waddchnstr				Y	-      4.0
	mvaddchnstr				Y	-      4.0
	mvwaddchnstr				Y	-      4.0
	add_wchstr				Y
	wadd_wchstr				Y
	mvadd_wchstr				Y
	mvwadd_wchstr				Y
	add_wchnstr				Y
	wadd_wchnstr				Y
	mvadd_wchnstr				Y
	mvwadd_wchnstr				Y
*/

/*
  Name:								beep

  Synopsis:
	int beep(void);
	int flash(void);

  Return Value:
	These functions return OK.

  Portability				     X/Open    BSD    SYS V
	beep					Y	Y	Y
	flash					Y	Y	Y
*/

/*
  Name:								bkgd

  Synopsis:
	int bkgd(chtype ch);
	void bkgdset(chtype ch);
	chtype getbkgd(WINDOW *win);
	int wbkgd(WINDOW *win, chtype ch);
	void wbkgdset(WINDOW *win, chtype ch);

	int bkgrnd(const cchar_t *wch);
	void bkgrndset(const cchar_t *wch);
	int getbkgrnd(cchar_t *wch);
	int wbkgrnd(WINDOW *win, const cchar_t *wch);
	void wbkgrndset(WINDOW *win, const cchar_t *wch);
	int wgetbkgrnd(WINDOW *win, cchar_t *wch);

  Return Value:
	bkgd() and wbkgd() return OK, unless the window is NULL, in 
	which case they return ERR.

  Portability				     X/Open    BSD    SYS V
	bkgd					Y	-      4.0
	bkgdset					Y	-      4.0
	getbkgd					Y
	wbkgd					Y	-      4.0
	wbkgdset				Y	-      4.0
	bkgrnd					Y
	bkgrndset				Y
	getbkgrnd				Y
	wbkgrnd					Y
	wbkgrndset				Y
	wgetbkgrnd				Y
*/

/*
  Name:								border

  Synopsis:
	int border(chtype ls, chtype rs, chtype ts, chtype bs, chtype tl, 
		   chtype tr, chtype bl, chtype br);
	int wborder(WINDOW *win, chtype ls, chtype rs, chtype ts, 
		    chtype bs, chtype tl, chtype tr, chtype bl, chtype br);
	int box(WINDOW *win, chtype verch, chtype horch);
	int hline(chtype ch, int n);
	int vline(chtype ch, int n);
	int whline(WINDOW *win, chtype ch, int n);
	int wvline(WINDOW *win, chtype ch, int n);
	int mvhline(int y, int x, chtype ch, int n);
	int mvvline(int y, int x, chtype ch, int n);
	int mvwhline(WINDOW *win, int y, int x, chtype ch, int n);
	int mvwvline(WINDOW *win, int y, int x, chtype ch, int n);

	int border_set(const cchar_t *ls, const cchar_t *rs,
		       const cchar_t *ts, const cchar_t *bs,
		       const cchar_t *tl, const cchar_t *tr,
		       const cchar_t *bl, const cchar_t *br);
	int wborder_set(WINDOW *win, const cchar_t *ls, const cchar_t *rs,
			const cchar_t *ts, const cchar_t *bs,
			const cchar_t *tl, const cchar_t *tr,
			const cchar_t *bl, const cchar_t *br);
	int box_set(WINDOW *win, const cchar_t *verch, const cchar_t *horch);
	int hline_set(const cchar_t *wch, int n);
	int vline_set(const cchar_t *wch, int n);
	int whline_set(WINDOW *win, const cchar_t *wch, int n);
	int wvline_set(WINDOW *win, const cchar_t *wch, int n);
	int mvhline_set(int y, int x, const cchar_t *wch, int n);
	int mvvline_set(int y, int x, const cchar_t *wch, int n);
	int mvwhline_set(WINDOW *win, int y, int x, const cchar_t *wch, int n);
	int mvwvline_set(WINDOW *win, int y, int x, const cchar_t *wch, int n);

  Return Value:
	These functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	border					Y	-      4.0
	wborder					Y	-      4.0
	box					Y	Y	Y
	hline					Y	-      4.0
	vline					Y	-      4.0
	whline					Y	-      4.0
	wvline					Y	-      4.0
	mvhline					Y
	mvvline					Y
	mvwhline				Y
	mvwvline				Y
	border_set				Y
	wborder_set				Y
	box_set					Y
	hline_set				Y
	vline_set				Y
	whline_set				Y
	wvline_set				Y
	mvhline_set				Y
	mvvline_set				Y
	mvwhline_set				Y
	mvwvline_set				Y
*/

/*
  Name:								delch

  Synopsis:
	int delch(void);
	int wdelch(WINDOW *win);
	int mvdelch(int y, int x);
	int mvwdelch(WINDOW *win, int y, int x);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	delch					Y	Y	Y
	wdelch					Y	Y	Y
	mvdelch					Y	Y	Y
	mvwdelch				Y	Y	Y
*/

/*
  Name:								deleteln

  Synopsis:
	int deleteln(void);
	int wdeleteln(WINDOW *win);
	int insdelln(int n);
	int winsdelln(WINDOW *win, int n);
	int insertln(void);
	int winsertln(WINDOW *win);

	int mvdeleteln(int y, int x);
	int mvwdeleteln(WINDOW *win, int y, int x);
	int mvinsertln(int y, int x);
	int mvwinsertln(WINDOW *win, int y, int x);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	deleteln				Y	Y	Y
	wdeleteln				Y	Y	Y
	mvdeleteln				-	-	-
	mvwdeleteln				-	-	-
	insdelln				Y	-      4.0
	winsdelln				Y	-      4.0
	insertln				Y	Y	Y
	winsertln				Y	Y	Y
	mvinsertln				-	-	-
	mvwinsertln				-	-	-
*/

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
  Name:								getyx

  Synopsis:
	void getyx(WINDOW *win, int y, int x);
	void getparyx(WINDOW *win, int y, int x);
	void getbegyx(WINDOW *win, int y, int x);
	void getmaxyx(WINDOW *win, int y, int x);

	int getbegy(WINDOW *win);
	int getbegx(WINDOW *win);
	int getcury(WINDOW *win);
	int getcurx(WINDOW *win);
	int getpary(WINDOW *win);
	int getparx(WINDOW *win);
	int getmaxy(WINDOW *win);
	int getmaxx(WINDOW *win);

  Description:
	With the getyx() macro, the cursor position of the window is 
	placed in the two integer variables y and x. getbegyx() and 
	getmaxyx() return the current beginning coordinates and size of 
	the specified window respectively. getparyx() returns the 
	beginning coordinates of the parent's window if the specified 
	window is a sub-window otherwise -1 is returned. These functions 
	are implemented as macros.

	The functions getbegy(), getbegx(), getcurx(), getcury(), 
	getmaxy(), getmaxx(), getpary(), and getparx() return the 
	appropriate coordinate or size values, or ERR in the case of a 
	NULL window.

  Portability				     X/Open    BSD    SYS V
	getyx					Y	Y	Y
	getparyx				-	-      4.0
	getbegyx				-	-      3.0
	getmaxyx				-	-      3.0
	getbegy					-	-	-
	getbegx					-	-	-
	getcury					-	-	-
	getcurx					-	-	-
	getpary					-	-	-
	getparx					-	-	-
	getmaxy					-	-	-
	getmaxx					-	-	-
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
  Name:								insch

  Synopsis:
	int insch(chtype ch);
	int winsch(WINDOW *win, chtype ch);
	int mvinsch(int y, int x, chtype ch);
	int mvwinsch(WINDOW *win, int y, int x, chtype ch);

	int insrawch(chtype ch);
	int winsrawch(WINDOW *win, chtype ch);
	int mvinsrawch(int y, int x, chtype ch);
	int mvwinsrawch(WINDOW *win, int y, int x, chtype ch);

	int ins_wch(const cchar_t *wch);
	int wins_wch(WINDOW *win, const cchar_t *wch);
	int mvins_wch(int y, int x, const cchar_t *wch);
	int mvwins_wch(WINDOW *win, int y, int x, const cchar_t *wch);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	insch					Y	Y	Y
	winsch					Y	Y	Y
	mvinsch					Y	Y	Y
	mvwinsch				Y	Y	Y
	insrawch				-	-	-
	winsrawch				-	-	-
	ins_wch					Y
	wins_wch				Y
	mvins_wch				Y
	mvwins_wch				Y
*/

/*
  Name:								insstr

  Synopsis:
	int insstr(const char *str);
	int insnstr(const char *str, int n);
	int winsstr(WINDOW *win, const char *str);
	int winsnstr(WINDOW *win, const char *str, int n);
	int mvinsstr(int y, int x, const char *str);
	int mvinsnstr(int y, int x, const char *str, int n);
	int mvwinsstr(WINDOW *win, int y, int x, const char *str);
	int mvwinsnstr(WINDOW *win, int y, int x, const char *str, int n);

	int ins_wstr(const wchar_t *wstr);
	int ins_nwstr(const wchar_t *wstr, int n);
	int wins_wstr(WINDOW *win, const wchar_t *wstr);
	int wins_nwstr(WINDOW *win, const wchar_t *wstr, int n);
	int mvins_wstr(int y, int x, const wchar_t *wstr);
	int mvins_nwstr(int y, int x, const wchar_t *wstr, int n);
	int mvwins_wstr(WINDOW *win, int y, int x, const wchar_t *wstr);
	int mvwins_nwstr(WINDOW *win, int y, int x, const wchar_t *wstr, int n);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	insstr					Y	-      4.0
	winsstr					Y	-      4.0
	mvinsstr				Y	-      4.0
	mvwinsstr				Y	-      4.0
	insnstr					Y	-      4.0
	winsnstr				Y	-      4.0
	mvinsnstr				Y	-      4.0
	mvwinsnstr				Y	-      4.0
	ins_wstr				Y
	wins_wstr				Y
	mvins_wstr				Y
	mvwins_wstr				Y
	ins_nwstr				Y
	wins_nwstr				Y
	mvins_nwstr				Y
	mvwins_nwstr				Y
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
  Name:								outopts

  Synopsis:
	int clearok(WINDOW *win, bool bf);
	int idlok(WINDOW *win, bool bf);
	void idcok(WINDOW *win, bool bf);
	void immedok(WINDOW *win, bool bf);
	int leaveok(WINDOW *win, bool bf);
	int setscrreg(int top, int bot);
	int wsetscrreg(WINDOW *win, int top, int bot);
	int scrollok(WINDOW *win, bool bf);

	int raw_output(bool bf);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	clearok					Y	Y	Y
	idlok					Y	Y	Y
	idcok					Y	-      4.0
	immedok					Y	-      4.0
	leaveok					Y	Y	Y
	setscrreg				Y	Y	Y
	wsetscrreg				Y	Y	Y
	scrollok				Y	Y	Y
	raw_output				-	-	-
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
  Name:								printw

  Synopsis:
	int printw(const char *fmt, ...);
	int wprintw(WINDOW *win, const char *fmt, ...);
	int mvprintw(int y, int x, const char *fmt, ...);
	int mvwprintw(WINDOW *win, int y, int x, const char *fmt,...);
	int vwprintw(WINDOW *win, const char *fmt, va_list varglist);
	int vw_printw(WINDOW *win, const char *fmt, va_list varglist);

  Return Value:
	All functions return the number of characters printed, or 
	ERR on error.

  Portability				     X/Open    BSD    SYS V
	printw					Y	Y	Y
	wprintw					Y	Y	Y
	mvprintw				Y	Y	Y
	mvwprintw				Y	Y	Y
	vwprintw				Y	-      4.0
	vw_printw				Y
*/

/*
  Name:								refresh

  Synopsis:
	int refresh(void);
	int wrefresh(WINDOW *win);
	int wnoutrefresh(WINDOW *win);
	int doupdate(void);
	int redrawwin(WINDOW *win);
	int wredrawln(WINDOW *win, int beg_line, int num_lines);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	refresh					Y	Y	Y
	wrefresh				Y	Y	Y
	wnoutrefresh				Y	Y	Y
	doupdate				Y	Y	Y
	redrawwin				Y	-      4.0
	wredrawln				Y	-      4.0
*/

/*
  Name:								scanw

  Synopsis:
	int scanw(const char *fmt, ...);
	int wscanw(WINDOW *win, const char *fmt, ...);
	int mvscanw(int y, int x, const char *fmt, ...);
	int mvwscanw(WINDOW *win, int y, int x, const char *fmt, ...);
	int vwscanw(WINDOW *win, const char *fmt, va_list varglist);
	int vw_scanw(WINDOW *win, const char *fmt, va_list varglist);

  Return Value:
	Upon successful completion, the scanw, mvscanw, mvwscanw and
	wscanw functions return the number of items successfully
	matched.  On end-of-file, they return EOF.  Otherwise they
	return ERR.

  Portability				     X/Open    BSD    SYS V
	scanw					Y	Y	Y
	wscanw					Y	Y	Y
	mvscanw					Y	Y	Y
	mvwscanw				Y	Y	Y
	vwscanw					Y	-      4.0
	vw_scanw				Y
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
  Name:								scroll

  Synopsis:
	int scroll(WINDOW *win);
	int scrl(int n);
	int wscrl(WINDOW *win, int n);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	scroll					Y	Y	Y
	scrl					Y	-      4.0
	wscrl					Y	-      4.0
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
  Name:								touch

  Synopsis:
	int touchwin(WINDOW *win);
	int touchline(WINDOW *win, int start, int count);
	int untouchwin(WINDOW *win);
	int wtouchln(WINDOW *win, int y, int n, int changed);
	bool is_linetouched(WINDOW *win, int line);
	bool is_wintouched(WINDOW *win);

  Return Value:
	All functions return OK on success and ERR on error except
	is_wintouched() and is_linetouched().

  Portability				     X/Open    BSD    SYS V
	touchwin				Y	Y	Y
	touchline				Y	-      3.0
	untouchwin				Y	-      4.0
	wtouchln				Y	Y	Y
	is_linetouched				Y	-      4.0
	is_wintouched				Y	-      4.0
*/

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

	int PDC_mbtowc(wchar_t *pwc, const char *s, size_t n);
	size_t PDC_mbstowcs(wchar_t *dest, const char *src, size_t n);
	size_t PDC_wcstombs(char *dest, const wchar_t *src, size_t n);

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

/*
  Name:								window

  Synopsis:
	WINDOW *newwin(int nlines, int ncols, int begy, int begx);
  	WINDOW *derwin(WINDOW* orig, int nlines, int ncols,
		int begy, int begx);
	WINDOW *subwin(WINDOW* orig, int nlines, int ncols,
		int begy, int begx);
	WINDOW *dupwin(WINDOW *win);
	int delwin(WINDOW *win);
	int mvwin(WINDOW *win, int y, int x);
	int mvderwin(WINDOW *win, int pary, int parx);
	int syncok(WINDOW *win, bool bf);
	void wsyncup(WINDOW *win);
	void wcursyncup(WINDOW *win);
	void wsyncdown(WINDOW *win);

	WINDOW *resize_window(WINDOW *win, int nlines, int ncols);
	int wresize(WINDOW *win, int nlines, int ncols);
	WINDOW *PDC_makelines(WINDOW *win);
	WINDOW *PDC_makenew(int nlines, int ncols, int begy, int begx);
	void PDC_sync(WINDOW *win);

  Return Value:
	newwin(), subwin(), derwin() and dupwin() return a pointer
	to the new window, or NULL on failure. delwin(), mvwin(),
	mvderwin() and syncok() return OK or ERR. wsyncup(),
	wcursyncup() and wsyncdown() return nothing.

  Errors:
	It is an error to call resize_window() before calling initscr().
	Also, an error will be generated if we fail to create a newly
	sized replacement window for curscr, or stdscr. This could
	happen when increasing the window size. NOTE: If this happens,
	the previously successfully allocated windows are left alone;
	i.e., the resize is NOT cancelled for those windows.

  Portability				     X/Open    BSD    SYS V
	newwin					Y	Y	Y
	delwin					Y	Y	Y
	mvwin					Y	Y	Y
	subwin					Y	Y	Y
	derwin					Y	-	Y
	mvderwin				Y	-	Y
	dupwin					Y	-      4.0
	wsyncup					Y	-      4.0
	syncok					Y	-      4.0
	wcursyncup				Y	-      4.0
	wsyncdown				Y	-      4.0
	resize_window				-	-	-
	wresize					-	-	-
	PDC_makelines				-	-	-
	PDC_makenew				-	-	-
	PDC_sync				-	-	-
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
