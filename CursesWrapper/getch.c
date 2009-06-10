#include <curses.h>

/*
  Name:								getch

  Synopsis:
	int getch(void);
	int wgetch(WINDOW *win);
	int mvgetch(int y, int x);
	int mvwgetch(WINDOW *win, int y, int x);
	int ungetch(int ch);
	int flushinp(void);

	int get_wch(wint_t *wch);
	int wget_wch(WINDOW *win, wint_t *wch);
	int mvget_wch(int y, int x, wint_t *wch);
	int mvwget_wch(WINDOW *win, int y, int x, wint_t *wch);
	int unget_wch(const wchar_t wch);

	unsigned long PDC_get_key_modifiers(void);
	int PDC_save_key_modifiers(bool flag);
	int PDC_return_key_modifiers(bool flag);

  Return Value:
	These functions return ERR or the value of the character, meta 
	character or function key token.

  Portability				     X/Open    BSD    SYS V
	getch					Y	Y	Y
	wgetch					Y	Y	Y
	mvgetch					Y	Y	Y
	mvwgetch				Y	Y	Y
	ungetch					Y	Y	Y
	flushinp				Y	Y	Y
	get_wch					Y
	wget_wch				Y
	mvget_wch				Y
	mvwget_wch				Y
	unget_wch				Y
	PDC_get_key_modifiers			-	-	-
*/

int
wrap_getch(void)
{
	return getch();
}

