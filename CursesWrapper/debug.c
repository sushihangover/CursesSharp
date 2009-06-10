#include <curses.h>

/*
  Name:								debug

  Synopsis:
	void traceon(void);
	void traceoff(void);
	void PDC_debug(const char *, ...);

  Description:
	traceon() and traceoff() toggle the recording of debugging 
	information to the file "trace". Although not standard, similar 
	functions are in some other curses implementations.

	PDC_debug() is the function that writes to the file, based on 
	whether traceon() has been called. It's used from the PDC_LOG() 
	macro.

  Portability				     X/Open    BSD    SYS V
	traceon					-	-	-
	traceoff				-	-	-
	PDC_debug				-	-	-
*/

void
wrap_traceon(void)
{
#ifdef PDCDEBUG
	traceon();
#endif
}

void
wrap_traceoff(void)
{
#ifdef PDCDEBUG
	traceoff();
#endif
}
