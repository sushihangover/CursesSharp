using System.Runtime.InteropServices;

namespace Curses
{
    internal class NativeMethods
    {
        [DllImport("CursesWrapper.dll")]
        internal static extern System.IntPtr wrap_initscr();

        [DllImport("CursesWrapper.dll")]
        internal static extern void wrap_endwin();
    }
}
