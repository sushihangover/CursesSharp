#include <curses.h>

/*
  Name:								beep

  Synopsis:
	int beep(void);
	int flash(void);

  Return Value:
	These functions return OK.

  Portability				     X/Open    BSD    SYS V
	beep					Y	Y	Y
	flash					Y	Y	Y
*/

int
wrap_beep(void)
{
	return beep();
}

int
wrap_flash(void)
{
	return flash();
}
