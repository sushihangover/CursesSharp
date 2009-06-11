using System;

namespace Curses
{
    public interface IWindow
    {
        /* addch.h */
        void AddCh(char ch);
        void AddCh(uint ch);
        void MvAddCh(int y, int x, char ch);
        void MvAddCh(int y, int x, uint ch);
        /* addstr.c */
        void AddStr(string str);
        void MvAddStr(int y, int x, string str);
        /* attr.c */
        void AttrSet(uint attr);
        /* clear.c */
        void Erase();
        /* getch.c */
        int GetCh();
        /* initscr.c */
        void Keypad(bool bf);
        void NoDelay(bool bf);
        void Timeout(int delay);
        /* move.c */
        void Move(int y, int x);
        /* refresh.c */
        void Refresh();
    }
}
