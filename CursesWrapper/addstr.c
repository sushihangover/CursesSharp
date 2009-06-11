#include <curses.h>

/*
  Name:								addstr

  Synopsis:
	int addstr(const char *str);
	int addnstr(const char *str, int n);
	int waddstr(WINDOW *win, const char *str);
	int waddnstr(WINDOW *win, const char *str, int n);
	int mvaddstr(int y, int x, const char *str);
	int mvaddnstr(int y, int x, const char *str, int n);
	int mvwaddstr(WINDOW *win, int y, int x, const char *str);
	int mvwaddnstr(WINDOW *win, int y, int x, const char *str, int n);

	int addwstr(const wchar_t *wstr);
	int addnwstr(const wchar_t *wstr, int n);
	int waddwstr(WINDOW *win, const wchar_t *wstr);
	int waddnwstr(WINDOW *win, const wchar_t *wstr, int n);
	int mvaddwstr(int y, int x, const wchar_t *wstr);
	int mvaddnwstr(int y, int x, const wchar_t *wstr, int n);
	int mvwaddwstr(WINDOW *win, int y, int x, const wchar_t *wstr);
	int mvwaddnwstr(WINDOW *win, int y, int x, const wchar_t *wstr, int n);

  Return Value:
	All functions return OK or ERR.

  Portability				     X/Open    BSD    SYS V
	addstr					Y	Y	Y
	waddstr					Y	Y	Y
	mvaddstr				Y	Y	Y
	mvwaddstr				Y	Y	Y
	addnstr					Y	-      4.0
	waddnstr				Y	-      4.0
	mvaddnstr				Y	-      4.0
	mvwaddnstr				Y	-      4.0
	addwstr					Y
	waddwstr				Y
	mvaddwstr				Y
	mvwaddwstr				Y
	addnwstr				Y
	waddnwstr				Y
	mvaddnwstr				Y
	mvwaddnwstr				Y
*/

int
wrap_waddnstr(WINDOW *win, const char *str, int n)
{
	return waddnstr(win, str, n);
}

int
wrap_mvwaddnstr(WINDOW *win, int y, int x, const char *str, int n)
{
	return mvwaddnstr(win, y, x, str, n);
}

int
wrap_waddnwstr(WINDOW *win, const wchar_t *str, int n)
{
	return waddnwstr(win, str, n);
}

int
wrap_mvwaddnwstr(WINDOW *win, int y, int x, const wchar_t *str, int n)
{
	return mvwaddnwstr(win, y, x, str, n);
}
