# CursesSharp

![](http://sushihangover.github.io/images/FireworksDemo.gif)

## INTRODUCTION

CursesSharp is a C# wrapper for curses library. 
The latest version of this 'fork'' can be found at [Github](https://github.com/sushihangover/CursesSharp).
The original version can be found at the [SourceForge.net project page](http://sourceforge.net/projects/curses-sharp/).

![RainDemo](http://sushihangover.github.io/images/RainDemo.gif )
	
## DOCUMENTATION

CursesSharp consists of a .NET assembly (CursesSharp.dll) and a native wrapper shared library (DLL) which is linked with PDCurses (in Windows) or ncurses  (in Unix-like systems). This wrapper library is called CursesWrapper.dll  in Windows or libCursesWrapper.so in Unix or libCursesWrapper.dylib in OS-X. CursesSharp provides a bit cleaner
API to curses than the original one, although function names remain unchanged for the most part. 

![](http://sushihangover.github.io/images/UnicodeDemo.gif)

### CursesSharp namespace contains several important classes:

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

*Documentation is (always) under construction. Help would be much appreciated.*

### Installing CursesSharp on OS-X

These are the instructions for building CursesSharp on OS-X. 

The build process has been tested on:

* OS-X 10.10.5
* Apple LLVM version 7.0.0 (clang-700.1.76)
* Mono JIT compiler version 4.2.1 64-bit build.

### 0. Prerequisites

The native library is now built as a 'fat' library so either a Mono 32-bit or 64-bit build can be used.

**$> file libCursesWrapper.so**

	libCursesWrapper.so: Mach-O universal binary with 2 architectures
	libCursesWrapper.so (for architecture i386):	Mach-O dynamically linked shared library i386
	libCursesWrapper.so (for architecture x86_64):	Mach-O 64-bit dynamically linked shared library x86_64

<!--A **64-bit build of Mono** as the the native shared library (so/dylib) is of ARCH type x64_86. 

**If you are running the default 32-bit Mono install, you will have to build the native library as ARCH i386. Currently there is not an included build process for this.
**
-->
### 1. Getting CursesSharp

You will have to obtain CursesSharp sources. You clone it from the following repository:

    https://github.com/sushihangover/CursesSharp.git


#### 2. Make the Native Library

	mdtool build CursesSharp.Native.sln --target:Build --configuration:Release
	mdtool build CursesSharp.Native.sln --target:Build --configuration:Debug

#### 3. Make the C# Libraries and Demos

	xbuild CursesSharp.sln /target:Clean
	xbuild CursesSharp.sln /target:Build

## Installing CursesSharp on Linux

### This section needs verifcation and updating

Original Linux instructions are [here](http://curses-sharp.sourceforge.net/index.php?page=linux)

## Installing CursesSharp on Windows

Refer the original Windows project, source code and instructions are [here](http://curses-sharp.sourceforge.net/index.php?page=windows)


Have fun ;-)

