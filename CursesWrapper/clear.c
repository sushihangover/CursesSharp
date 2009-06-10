#include <curses.h>

/*
  Name:								clear

  Synopsis:
	int clear(void);
	int wclear(WINDOW *win);
	int erase(void);
	int werase(WINDOW *win);
	int clrtobot(void);
	int wclrtobot(WINDOW *win);
	int clrtoeol(void);
	int wclrtoeol(WINDOW *win);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	clear					Y	Y	Y
	wclear					Y	Y	Y
	erase					Y	Y	Y
	werase					Y	Y	Y
	clrtobot				Y	Y	Y
	wclrtobot				Y	Y	Y
	clrtoeol				Y	Y	Y
	wclrtoeol				Y	Y	Y
*/

int
wrap_erase(void)
{
	return erase();
}
