#Installing Curses Sharp on Windows

This is the old Windows installation documentation. Looking for Contributors in this area.

#Old docs:

Installing Curses Sharp on Windows
This document is a description of how to build Curses Sharp on Windows. At the time of writing, the build process has only been tested on Windows Vista using Visual Studio 2005 environment.

1. PDCurses
Curses Sharp requires a curses implementation. On Windows the best choice is PDCurses. Although there are pre-built binary packages available, it is advised to build PDCurses from source, just to be sure that all settings are correct.

First get the source code from http://pdcurses.sourceforge.net. In official Curses Sharp builds version 3.4 of PDCurses is used. Be sure to download the source code for Windows (the .zip package).

Extract the package. Run the Visual Studio Command Prompt (Start -> Microsoft Visual Studio 2005 -> Visual Studio Tools -> Visual Studio 2005 Command Prompt) and cd to the directory where you extracted the PDCurses sources. Run the following commands:

cd win32
nmake -f vcwin32.mak WIDE=Y
After the build process is finished, you will see pdcurses.lib file in the win32 subdirectory. We will use this file in a moment.

2. Prepare Curses Sharp sources
You will have to obtain Curses Sharp sources. You can download it or get a checkout with Subversion from the following repository:

https://curses-sharp.svn.sourceforge.net/svnroot/curses-sharp/trunk
Create a pdcurses subdirectory in the directory containing Curses Sharp sources. Into this subdirectory copy the pdcurses.lib library that you have built in step 1. Also copy curses.h, panel.h and term.h header files from the directory containing PDCurses sources.

3. Build Curses Sharp
Open the Visual Studio solution file (CursesSharp.sln). Set the appropriate active solution configuration (debug or release, whichever you wish), right-click the "CursesSharp" project and select "Build". In the Curses Sharp source directory a subdirectory will be created (debug or release, depending on the configuration you choose) in which there will be CursesWrapper.dll and CursesSharp.dll libraries.