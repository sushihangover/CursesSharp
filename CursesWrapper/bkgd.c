#include <curses.h>

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

unsigned int
wrap_getbkgd(WINDOW *win)
{
	return getbkgd(win);
}

int 
wrap_wbkgd(WINDOW *win, unsigned int ch)
{
	return wbkgd(win, ch);
}

void 
wrap_wbkgdset(WINDOW *win, unsigned int ch)
{
	return wbkgdset(win, ch);
}

