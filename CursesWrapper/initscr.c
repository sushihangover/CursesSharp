#include <curses.h>

/*
  Name:								initscr

  Synopsis:
	WINDOW *initscr(void);
	WINDOW *Xinitscr(int argc, char *argv[]);
	int endwin(void);
	bool isendwin(void);
	SCREEN *newterm(const char *type, FILE *outfd, FILE *infd);
	SCREEN *set_term(SCREEN *new);
	void delscreen(SCREEN *sp);

	int resize_term(int nlines, int ncols);
	bool is_termresized(void);
	const char *curses_version(void);

  Return Value:
	All functions return NULL on error, except endwin(), which
	returns ERR on error.

  Portability				     X/Open    BSD    SYS V
	initscr					Y	Y	Y
	endwin					Y	Y	Y
	isendwin				Y	-      3.0
	newterm					Y	-	Y
	set_term				Y	-	Y
	delscreen				Y	-      4.0
	resize_term				-	-	-
	is_termresized				-	-	-
	curses_version				-	-	-
*/

WINDOW *
wrap_initscr(void)
{
	return initscr();
}

int
wrap_endwin(void)
{
	return endwin();
}

