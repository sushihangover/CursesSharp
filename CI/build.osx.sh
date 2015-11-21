#!/bin/bash
# Clean Native
mdtool build CursesSharp.Native.sln --target:Clean --configuration:Release
mdtool build CursesSharp.Native.sln --target:Clean --configuration:Debug
# Build Native
mdtool build CursesSharp.Native.sln --target:Build --configuration:Release
mdtool build CursesSharp.Native.sln --target:Build --configuration:Debug
# Clean CIL assemblies
xbuild CursesSharp.sln /target:Clean /property:configuration=Release
xbuild CursesSharp.sln /target:Clean /property:configuration=Debug
# Build CIL assemblies
xbuild CursesSharp.sln /target:Build /property:configuration=Release
xbuild CursesSharp.sln /target:Build /property:configuration=Debug

