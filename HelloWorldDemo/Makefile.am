pkgdata_SCRIPTS = HelloWorldDemo.exe
scriptsdir = $(bindir)
bin_SCRIPTS = HelloWorldDemo

EXTRA_DIST = $(HelloWorldDemo_sources) HelloWorldDemo.in HelloWorldDemo.csproj
CLEANFILES = HelloWorldDemo.exe
DISTCLEANFILES = HelloWorldDemo

HelloWorldDemo_sources = Program.cs Properties/AssemblyInfo.cs
HelloWorldDemo_libs = -r:../CursesSharp/CursesSharp.dll

HelloWorldDemo_build_sources = $(addprefix $(srcdir)/, $(HelloWorldDemo_sources))

HelloWorldDemo.exe: $(HelloWorldDemo_build_sources)
	$(CSC) -out:$@ $(CSCFLAGS) $(HelloWorldDemo_libs)	\
	    $(HelloWorldDemo_build_sources)

