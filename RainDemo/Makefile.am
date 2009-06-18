pkglib_SCRIPTS = RainDemo.exe
bin_SCRIPTS = RainDemo

EXTRA_DIST = $(RainDemo_sources) RainDemo.in RainDemo.csproj
CLEANFILES = RainDemo.exe
DISTCLEANFILES = RainDemo

RainDemo_sources = Program.cs Properties/AssemblyInfo.cs
RainDemo_libs = -r:../CursesSharp/CursesSharp.dll

RainDemo_build_sources = $(addprefix $(srcdir)/, $(RainDemo_sources))

RainDemo.exe: $(RainDemo_build_sources)
	$(CSC) $(RainDemo_libs) -out:$@ $(RainDemo_build_sources)

