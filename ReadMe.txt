--- INTRODUCTION ---

CursesSharp is a C# wrapper for curses library. 
The latest version can be found at the SourceForge.net project page:
	http://sourceforge.net/projects/curses-sharp/


--- DOCUMENTATION ---

CursesSharp consists of a .NET assembly (CursesSharp.dll) and a native wrapper
shared library (DLL) which is linked with PDCurses (in Windows) or ncurses 
(in Unix-like systems). This wrapper library is called CursesWrapper.dll 
in Windows or libCursesWrapper.so in Unix. CursesSharp provides a bit cleaner
API to curses than the original one, although function names remain unchanged
for the most part. 

In the .NET assembly, CursesSharp namespace contains several important classes:
* Defs - contains constants from curses: attribute, color and key definitions
	as well as some macros (COLOR_PAIR, PAIR_NUMBER)
* Curses - the main interface to curses; contains methods global to the library,
	a StdScr property that returns the stdscr window, and as a convenience,
	some window-specific functions that operate on stdscr
* Window - represents a curses window that can be written to, or read from;
	contains wrappers for most of curses functions with names starting with
	w* or mvw*
* CursesException - an exception class, thrown when a curses function
	reports an error

Proper documentation is under construction. Help would be much appreciated.
