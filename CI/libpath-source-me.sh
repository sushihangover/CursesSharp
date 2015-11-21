#!/bin/bash
# source this file to add native library to your library loader path
[[ "${BASH_SOURCE[0]}" != "${0}" ]] && SOURCED=1 || SOURCED=0
if [ $SOURCED -eq 1 ]
then
	export LD_LIBRARY_PATH=${PWD}/CursesSharp.Native/bin/Debug
	export DYLD_FALLBACK_LIBRARY_PATH=${PWD}/CursesSharp.Native/bin/Debug
	echo LD_LIBRARY_PATH $LD_LIBRARY_PATH
	echo DYLD_FALLBACK_LIBRARY_PATH $DYLD_FALLBACK_LIBRARY_PATH
else
	echo This script needs to be called via "source"
fi
