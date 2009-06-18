pkglib_SCRIPTS = FireworkDemo.exe
bin_SCRIPTS = FireworkDemo

EXTRA_DIST = $(FireworkDemo_sources) FireworkDemo.in FireworkDemo.csproj
CLEANFILES = FireworkDemo.exe
DISTCLEANFILES = FireworkDemo

FireworkDemo_sources = Program.cs Properties/AssemblyInfo.cs
FireworkDemo_libs = -r:../CursesSharp/CursesSharp.dll

FireworkDemo_build_sources = $(addprefix $(srcdir)/, $(FireworkDemo_sources))

FireworkDemo.exe: $(FireworkDemo_build_sources)
	$(CSC) $(FireworkDemo_libs) -out:$@ $(FireworkDemo_build_sources)

