#include <curses.h>

/*
  Name:								color

  Synopsis:
	int start_color(void);
	int init_pair(short pair, short fg, short bg);
	int init_color(short color, short red, short green, short blue);
	bool has_colors(void);
	bool can_change_color(void);
	int color_content(short color, short *red, short *green, short *blue);
	int pair_content(short pair, short *fg, short *bg);

	int assume_default_colors(int f, int b);
	int use_default_colors(void);

	int PDC_set_line_color(short color);

  Return Value:
	All functions return OK on success and ERR on error, except for
	has_colors() and can_change_colors(), which return TRUE or FALSE.

  Portability				     X/Open    BSD    SYS V
	start_color				Y	-      3.2
	init_pair				Y	-      3.2
	init_color				Y	-      3.2
	has_colors				Y	-      3.2
	can_change_color			Y	-      3.2
	color_content				Y	-      3.2
	pair_content				Y	-      3.2
	assume_default_colors			-	-	-
	use_default_colors			-	-	-
	PDC_set_line_color			-	-       -
*/

unsigned long
wrap_COLOR_PAIR(short n)
{
	return COLOR_PAIR(n);
}

short
wrap_PAIR_NUMBER(unsigned long n)
{
	return (short)(PAIR_NUMBER(n));
}

int
wrap_start_color(void)
{
	return start_color();
}

int
wrap_has_colors(void)
{
	return has_colors();
}

int
wrap_init_pair(short color, short fg, short bg)
{
	return init_pair(color, fg, bg);
}

