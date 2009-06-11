#include <curses.h>

/*  
  Name:								move

  Synopsis:
	int move(int y, int x);
	int wmove(WINDOW *win, int y, int x);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	move					Y	Y	Y
	wmove					Y	Y	Y
*/

int
wrap_wmove(WINDOW *win, int y, int x)
{
	return wmove(win, y, x);
}

