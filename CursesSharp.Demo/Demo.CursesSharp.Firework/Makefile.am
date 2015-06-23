pkgdata_SCRIPTS = FireworkDemo.exe
scriptsdir = $(bindir)
bin_SCRIPTS = FireworkDemo

EXTRA_DIST = $(FireworkDemo_sources) FireworkDemo.in FireworkDemo.csproj
CLEANFILES = FireworkDemo.exe
DISTCLEANFILES = FireworkDemo

FireworkDemo_sources = Program.cs Properties/AssemblyInfo.cs
FireworkDemo_libs = -r:../CursesSharp/CursesSharp.dll

FireworkDemo_build_sources = $(addprefix $(srcdir)/, $(FireworkDemo_sources))

FireworkDemo.exe: $(FireworkDemo_build_sources)
	$(CSC) -out:$@ $(CSCFLAGS) $(FireworkDemo_libs)	\
	    $(FireworkDemo_build_sources)

