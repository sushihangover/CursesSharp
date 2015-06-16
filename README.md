# INTRODUCTION

CursesSharp is a C# wrapper for curses library. 
The latest version of this 'fork'' can be found at [Github](https://github.com/sushihangover/CursesSharp).
The original version can be found at the [SourceForge.net project page](http://sourceforge.net/projects/curses-sharp/).
	
# DOCUMENTATION

CursesSharp consists of a .NET assembly (CursesSharp.dll) and a native wrapper shared library (DLL) which is linked with PDCurses (in Windows) or ncurses  (in Unix-like systems). This wrapper library is called CursesWrapper.dll  in Windows or libCursesWrapper.so in Unix or libCursesWrapper.dylib in OS-X. CursesSharp provides a bit cleaner
API to curses than the original one, although function names remain unchanged for the most part. 

## CursesSharp namespace contains several important classes:

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

## Installing CursesSharp on Windows

### This section needs verification and updating

Original Windows instructions are [here](http://curses-sharp.sourceforge.net/index.php?page=windows)

This document is a description of how to build CursesSharp on Windows. At the time of writing, the build process has only been tested on Windows Vista using Visual Studio 2005 environment.

### 1. PDCurses

CursesSharp requires a curses implementation. On Windows the best choice is PDCurses. Although there are pre-built binary packages available, it is advised to build PDCurses from source, just to be sure that all settings are correct.

First get the source code from [http://pdcurses.sourceforge.net](http://pdcurses.sourceforge.net). In official CursesSharp builds version 3.4 of PDCurses is used. Be sure to download the source code for Windows (the .zip package).

Extract the package. Run the Visual Studio Command Prompt (Start -> Microsoft Visual Studio 2005 -> Visual Studio Tools -> Visual Studio 2005 Command Prompt) and cd to the directory where you extracted the PDCurses sources. Run the following commands:

    cd win32
    nmake -f vcwin32.mak WIDE=Y

After the build process is finished, you will see pdcurses.lib file in the win32 subdirectory. We will use this file in a moment.

### 2. Prepare CursesSharp sources

You will have to obtain CursesSharp sources. You clone it from the following repository:

    https://github.com/sushihangover/CursesSharp.git

Original SVN Repo:

    https://curses-sharp.svn.sourceforge.net/svnroot/curses-sharp/trunk

Create a pdcurses subdirectory in the directory containing CursesSharp sources. Into this subdirectory copy the pdcurses.lib library that you have built in step 1. Also copy curses.h, panel.h and term.h header files from the directory containing PDCurses sources.

### 3. Build CursesSharp
Open the Visual Studio solution file (CursesSharp.sln). Set the appropriate active solution configuration (debug or release, whichever you wish), right-click the "CursesSharp" project and select "Build". In the CursesSharp source directory a subdirectory will be created (debug or release, depending on the configuration you choose) in which there will be CursesWrapper.dll and CursesSharp.dll libraries.

## Installing CursesSharp on Linux

### This section needs verifcation and updating

Original Linux instructions are [here](http://curses-sharp.sourceforge.net/index.php?page=linux)

These are the instructions for building CursesSharp in Linux/Unix-like systems. The build process has been tested in Ubuntu 9.04 and FreeBSD 7.2.

### 0. Prerequisites

1. Subversion - if you intend to build CursesSharp from SVN repository. If you use the source code package, you don't need Subversion.
2. autoconf/automake/libtool - only if you are building from SVN. You don't need these tools if you use the source code package.
3. Standard development tools - a C compiler (e.g. GCC) and GNU make (gmake).
4. Ncurses library and headers (development files) - typically this package is called ncurses-dev.
5. Mono - the .NET runtime and development framework
6. pkg-config - typically required by Mono, but make sure it's installed

### 1. Getting CursesSharp

You will have to obtain CursesSharp sources. You clone it from the following repository:

    https://github.com/sushihangover/CursesSharp.git

Original SVN Repo:

    https://curses-sharp.svn.sourceforge.net/svnroot/curses-sharp/trunk

The following section describes the former case. If you downloaded the source code package, extract it and you may skip to step 4.

### 2. Git clone

Execute the following command:

    git clone https://github.com/sushihangover/CursesSharp.git cursessharp

*You may substitute the final cursessharp for any other directory of your liking.*

### 3. Bootstrapping

In order to proceed with the build, you will have to create the configure script. Cd into the directory containing CursesSharp sources and execute the following command:

    autoreconf -i

### 4. Configure

In the top source directory execute the command:

    ./configure

By default CursesSharp is installed in /usr/local. To change the target directory, which you really should do, you can use the "--prefix=" option:

    ./configure --prefix=target_directory

You can also use other options. For a complete list execute:

    ./configure --help

#### 5. Make

After you executed configure, run (in the same directory):

    make

To compile the source code.

### 6. Installation

Execute the command:

    make install

This will install CursesSharp. Make sure you have appropriate privileges.

### 7. Testing

By default CursesSharp will install a few demonstration programs. At this time, these are: FireworkDemo and RainDemo. You can try running the demos to check if CursesSharp works.


## Installing CursesSharp on OS-X

These are the instructions for building CursesSharp on OS-X. The build process has been tested on 10.10.3 using Apple LLVM version 6.1.0 and a Mono 4.0.1 64-bit build.

### 0. Prerequisites

1. Subversion - if you intend to build CursesSharp from SVN repository. If you use the source code package, you don't need Subversion.
2. autoconf/automake/libtool - only if you are building from SVN. You don't need these tools if you use the source code package.
3. Standard development tools - a C compiler (e.g. GCC) and GNU make (gmake).
4. Ncurses library and headers (development files) - typically this package is called ncurses-dev.
5. Mono - the .NET runtime and development framework
6. pkg-config - typically required by Mono, but make sure it's installed

### 1. Getting CursesSharp

You will have to obtain CursesSharp sources. You clone it from the following repository:

    https://github.com/sushihangover/CursesSharp.git

Original SVN Repo:

    https://curses-sharp.svn.sourceforge.net/svnroot/curses-sharp/trunk

The following section describes the former case. If you downloaded the source code package, extract it and you may skip to step 4.

### 2. Git clone

Execute the following command:

    git clone https://github.com/sushihangover/CursesSharp.git cursessharp

*You may substitute the final cursessharp for any other directory of your liking.*

### 3. Bootstrapping

In order to proceed with the build, you will have to create the configure script. Cd into the directory containing CursesSharp sources and execute the following command:

brew link gettext --force    
autoreconf -if

### 4. Configure

In the top source directory execute the command:

    LIBS="-lncurses -liconv -lpanel" ./configure

By default CursesSharp is installed in /usr/local. To change the target directory,** which you really should do,** you can use the "--prefix=" option:

    # Following all on one line:    
    LIBS="-lncurses -liconv -lpanel" ./configure --prefix=$HOME/cursessharp

You can also use other options. For a complete list execute:

    ./configure --help

#### 5. Make

After you executed configure, run (in the same directory):
    
    #I am using a locally built/installed 64-bit version of mono, so I add it to the path
    export PATH=/Users/administrator/mono/mono-llvm-64/bin:$PATH
    make
    # remove brew's version of gettext 
    brew unlink gettext


To compile the source code.

### 6. Installation

Execute the command:

    make install

This will install CursesSharp. Make sure you have appropriate privileges.

### 7. Testing

By default CursesSharp will install a few demonstration programs. At this time, these are: FireworkDemo and RainDemo. You can try running the demos to check if CursesSharp works.

Running the demos:

Add your cursessharp's bin install location to your path, i.e.

    export PATH=$HOME/cursessharp/bin:$PATH

And you can run them from anywhere:

    RainDemo
    FireworksDemo
    UnicodeDemo

Have fun ;-)

