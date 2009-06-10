#include <curses.h>

/*
  Name:								inopts

  Synopsis:
	int cbreak(void);
	int nocbreak(void);
	int echo(void);
	int noecho(void);
	int halfdelay(int tenths);
	int intrflush(WINDOW *win, bool bf);
	int keypad(WINDOW *win, bool bf);
	int meta(WINDOW *win, bool bf);
	int nl(void);
	int nonl(void);
	int nodelay(WINDOW *win, bool bf);
	int notimeout(WINDOW *win, bool bf);
	int raw(void);
	int noraw(void);
	void noqiflush(void);
	void qiflush(void);
	void timeout(int delay);
	void wtimeout(WINDOW *win, int delay);
	int typeahead(int fildes);

	int crmode(void);
	int nocrmode(void);

  Return Value:
	All functions return OK on success and ERR on error.

  Portability				     X/Open    BSD    SYS V
	cbreak					Y	Y	Y
	nocbreak				Y	Y	Y
	echo					Y	Y	Y
	noecho					Y	Y	Y
	halfdelay				Y	-	Y
	intrflush				Y	-	Y
	keypad					Y	-	Y
	meta					Y	-	Y
	nl					Y	Y	Y
	nonl					Y	Y	Y
	nodelay					Y	-	Y
	notimeout				Y	-	Y
	raw					Y	Y	Y
	noraw					Y	Y	Y
	noqiflush				Y	-	Y
	qiflush					Y	-	Y
	timeout					Y	-	Y
	wtimeout				Y	-	Y
	typeahead				Y	-	Y
	crmode					-
	nocrmode				-
*/

int
wrap_echo(void)
{
	return echo();
}

int
wrap_noecho(void)
{
	return noecho();
}

int
wrap_keypad(WINDOW *win, int bf)
{
	return keypad(win, bf);
}

int
wrap_nodelay(WINDOW *win, int bf)
{
	return nodelay(win, bf);
}

int
wrap_raw(void)
{
	return raw();
}

int
wrap_noraw(void)
{
	return noraw();
}

