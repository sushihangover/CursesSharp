#include <curses.h>

/*
  Name:								addch

  Synopsis:
	int addch(const chtype ch);
	int waddch(WINDOW *win, const chtype ch);
	int mvaddch(int y, int x, const chtype ch);
	int mvwaddch(WINDOW *win, int y, int x, const chtype ch);
	int echochar(const chtype ch);
	int wechochar(WINDOW *win, const chtype ch);

	int addrawch(chtype ch);
	int waddrawch(WINDOW *win, chtype ch);
	int mvaddrawch(int y, int x, chtype ch);
	int mvwaddrawch(WINDOW *win, int y, int x, chtype ch);

	int add_wch(const cchar_t *wch);
	int wadd_wch(WINDOW *win, const cchar_t *wch);
	int mvadd_wch(int y, int x, const cchar_t *wch);
	int mvwadd_wch(WINDOW *win, int y, int x, const cchar_t *wch);
	int echo_wchar(const cchar_t *wch);
	int wecho_wchar(WINDOW *win, const cchar_t *wch);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	addch					Y	Y	Y
	waddch					Y	Y	Y
	mvaddch					Y	Y	Y
	mvwaddch				Y	Y	Y
	echochar				Y	-      3.0
	wechochar				Y	-      3.0
	addrawch				-	-	-
	waddrawch				-	-	-
	mvaddrawch				-	-	-
	mvwaddrawch				-	-	-
	add_wch					Y
	wadd_wch				Y
	mvadd_wch				Y
	mvwadd_wch				Y
	echo_wchar				Y
	wecho_wchar				Y
*/

int
wrap_addch(unsigned int ch)
{
	return addch(ch);
}

int
wrap_mvaddch(int y, int x, unsigned int ch)
{
	return mvaddch(y, x, ch);
}

