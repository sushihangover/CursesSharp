pkglib_SCRIPTS = UnicodeDemo.exe
bin_SCRIPTS = UnicodeDemo

EXTRA_DIST = $(UnicodeDemo_sources) UnicodeDemo.in UnicodeDemo.csproj
CLEANFILES = UnicodeDemo.exe
DISTCLEANFILES = UnicodeDemo

UnicodeDemo_sources = Program.cs Properties/AssemblyInfo.cs
UnicodeDemo_libs = -r:../CursesSharp/CursesSharp.dll

UnicodeDemo_build_sources = $(addprefix $(srcdir)/, $(UnicodeDemo_sources))

UnicodeDemo.exe: $(UnicodeDemo_build_sources)
	$(CSC) $(UnicodeDemo_libs) -out:$@ $(UnicodeDemo_build_sources)

