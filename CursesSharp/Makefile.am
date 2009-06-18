pkglib_SCRIPTS = CursesSharp.dll

EXTRA_DIST = $(CursesSharp_sources) CursesSharp.csproj
CLEANFILES = CursesSharp.dll
DISTCLEANFILES = DefsGen.cs

CursesSharp_generated_sources = DefsGen.cs
CursesSharp_sources = \
	CursesException.cs \
	Internal/CMsAddch.cs \
	Internal/CMsAddchstr.cs \
	Internal/CMsAddstr.cs \
	Internal/CMsAttr.cs \
	Internal/CMsBeep.cs \
	Internal/CMsBkgd.cs \
	Internal/CMsBorder.cs \
	Internal/CMsClear.cs \
	Internal/CMsColor.cs \
	Internal/CMsDebug.cs \
	Internal/CMsDelch.cs \
	Internal/CMsDeleteln.cs \
	Internal/CMsGetch.cs \
	Internal/CMsGetstr.cs \
	Internal/CMsGetyx.cs \
	Internal/CMsInch.cs \
	Internal/CMsInchstr.cs \
	Internal/CMsInitscr.cs \
	Internal/CMsInopts.cs \
	Internal/CMsInsch.cs \
	Internal/CMsInsstr.cs \
	Internal/CMsInstr.cs \
	Internal/CMsKernel.cs \
	Internal/CMsKeyname.cs \
	Internal/CMsMouse.cs \
	Internal/CMsMove.cs \
	Internal/CMsOutopts.cs \
	Internal/CMsOverlay.cs \
	Internal/CMsPad.cs \
	Internal/CMsPanel.cs \
	Internal/CMsRefresh.cs \
	Internal/CMsScrdump.cs \
	Internal/CMsScroll.cs \
	Internal/CMsSlk.cs \
	Internal/CMsTermattr.cs \
	Internal/CMsTouch.cs \
	Internal/CMsUtil.cs \
	Internal/CMsWindow.cs \
	Internal/CursesMethods.cs \
	Internal/InternalException.cs \
	WindowBase.cs \
	Pad.cs \
	Panel.cs \
	Window.cs \
	Curses.cs \
	SoftLabels.cs \
	Stdscr.cs \
	Properties/AssemblyInfo.cs

CursesSharp_build_sources = $(CursesSharp_generated_sources)
CursesSharp_build_sources += $(addprefix $(srcdir)/, $(CursesSharp_sources))

DefsGen.cs: ../AttributeGen/AttributeGen
	../AttributeGen/AttributeGen $@

CursesSharp.dll: $(CursesSharp_build_sources)
	$(CSC) -target:library -out:$@ $(CSCFLAGS) $(CursesSharp_CSCFLAGS) \
		$(CursesSharp_build_sources)

