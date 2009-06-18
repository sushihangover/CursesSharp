#region Copyright 2009 Robert Konklewski

/*
 * CursesSharp
 * 
 * Copyright 2009 Robert Konklewski
 * 
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 * FITNESS FOR A PARTICULAR PURPOSE.  See the GNU Lesser General Public
 * License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * www.gnu.org/licenses/>.
 * 
 */

#endregion

using System;
using System.Diagnostics;
using System.Collections.Generic;
using CursesSharp.Internal;

namespace CursesSharp
{
#if HAVE_CURSES_PANEL
    public class Panel : IDisposable
    {
        private static IDictionary<IntPtr, Panel> allPanels = new Dictionary<IntPtr, Panel>();

        public static Panel BottomPanel
        {
            get { return GetPanel(CursesMethods.panel_above(IntPtr.Zero)); }
        }

        public static Panel TopPanel
        {
            get { return GetPanel(CursesMethods.panel_below(IntPtr.Zero)); }
        }

        public static void UpdatePanels()
        {
            CursesMethods.update_panels();
        }

        private IntPtr handle;
        private Window window;

        public Panel(Window window)
        {
            this.handle = CursesMethods.new_panel(window.Handle);
            this.window = window;
            allPanels.Add(this.handle, this);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.DisposeImpl(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        ~Panel()
        {
#if DEBUG
            Debug.Assert(this.handle == IntPtr.Zero, "Panel not disposed");
#endif
            this.DisposeImpl(false);
        }

        private void DisposeImpl(bool disposing)
        {
            if (this.handle != IntPtr.Zero)
            {
                if (disposing)
                {
                    allPanels.Remove(this.handle);
                }
                CursesMethods.del_panel(this.handle);
                this.handle = IntPtr.Zero;
                this.window = null;
            }
        }

        public Window Window
        {
            get
            {
                return this.window;
            }
            set
            {
                CursesMethods.replace_panel(this.handle, value.Handle);
                this.window = value;
            }
        }

        public Panel AbovePanel
        {
            get { return GetPanel(CursesMethods.panel_above(this.handle)); }
        }

        public Panel BelowPanel
        {
            get { return GetPanel(CursesMethods.panel_below(this.handle)); }
        }

        public bool IsHidden
        {
            get
            {
                return CursesMethods.panel_hidden(this.handle);
            }
            set
            {
                if (value)
                    this.Hide();
                else
                    this.Show();
            }
        }

        public void Show()
        {
            CursesMethods.show_panel(this.handle);
        }

        public void Hide()
        {
            CursesMethods.hide_panel(this.handle);
        }

        public void SetBottom()
        {
            CursesMethods.bottom_panel(this.handle);
        }

        public void SetTop()
        {
            CursesMethods.top_panel(this.handle);
        }

        public void Move(int starty, int startx)
        {
            CursesMethods.move_panel(this.handle, starty, startx);
        }

        private static Panel GetPanel(IntPtr handle)
        {
            if (handle != IntPtr.Zero)
                return allPanels[handle];
            return null;
        }
    }
#endif
}
