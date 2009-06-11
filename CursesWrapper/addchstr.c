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

int
wrap_waddchnstr(WINDOW *win, const unsigned int *chstr, int n)
{
	return waddchnstr(win, chstr, n);
}

int
wrap_mvwaddchnstr(WINDOW *win, int y, int x, const unsigned int *chstr, int n)
{
	return mvwaddchnstr(win, y, x, chstr, n);
}
