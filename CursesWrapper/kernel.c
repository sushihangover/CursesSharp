#include <curses.h>

/*
  Name:								kernel

  Synopsis:
	int def_prog_mode(void);
	int def_shell_mode(void);
	int reset_prog_mode(void);
	int reset_shell_mode(void);
	int resetty(void);
	int savetty(void);
	void getsyx(int y, int x);
	void setsyx(int y, int x);
	int ripoffline(int line, int (*init)(WINDOW *, int));
	int curs_set(int visibility);
	int napms(int ms);

	int draino(int ms);
	int resetterm(void);
	int fixterm(void);
	int saveterm(void);

  Return Value:
	All functions return OK on success and ERR on error, except
	curs_set(), which returns the previous visibility.

  Portability				     X/Open    BSD    SYS V
	def_prog_mode				Y	Y	Y
	def_shell_mode				Y	Y	Y
	reset_prog_mode				Y	Y	Y
	reset_shell_mode			Y	Y	Y
	resetty					Y	Y	Y
	savetty					Y	Y	Y
	getsyx					-	-      3.0
	setsyx					-	-      3.0
	ripoffline				Y	-      3.0
	curs_set				Y	-      3.0
	napms					Y	Y	Y
	draino					-
	resetterm				-
	fixterm					-
	saveterm				-
*/

int 
wrap_napms(int ms)
{
	return napms(ms);
}

