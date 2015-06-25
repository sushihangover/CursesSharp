//
// mc.cs: Main program
//
// Authors:
//   Miguel de Icaza (miguel@gnome.org)
//
// Licensed under the MIT X11 license
//
using System;
using System.IO;
using CursesSharp;
using CursesSharp.Gui;

namespace MouselessCommander
{

	public class Shell : Container
	{
		public Panel CurrentPanel;
		Panel left, right;
		ButtonBar bar;
		MenuBar menu;
		Label prompt;
		Entry entry;
		
		string[] bar_labels = new string [] {
			"", "", "View", "", "Copy", "RenMov", "", "", "PullDn"
		};

		MenuBarItem[] mc_menu = new MenuBarItem [] {
			new MenuBarItem ("Left", new MenuItem [] {
				new MenuItem ("_Listing Mode...", null, null),
				new MenuItem ("_Sort order...", null, null),
				new MenuItem ("_Filter...", null, null),
				new MenuItem ("_Rescan", "Control-r", null),
			}),
			new MenuBarItem ("File", new MenuItem [] {
				new MenuItem ("_Menu", "F2", null),
				new MenuItem ("_View", "F3", null),
				new MenuItem ("_Edit", "F4", null),
				new MenuItem ("_Copy", "F5", null),
				new MenuItem ("_Rename/Move", "F6", null),
				new MenuItem ("_Make directory", "F7", null),
				new MenuItem ("_Delete", "F8", null),
				null,
				new MenuItem ("_Toggle section", "Control-t", null),
				new MenuItem ("_Select", "Alt-+, +", null),
				new MenuItem ("_Unselect", "Alt-\\, -", null),
				new MenuItem ("_Reverse Selection", "Alt-*, *", null),
				null,
				new MenuItem ("_Quit", "F10", null)
			}),
			new MenuBarItem ("Command", new MenuItem [] {
				new MenuItem ("_Find File", "Alt-?", null),
				new MenuItem ("_Swap panels", "Control-u", null),
				new MenuItem ("Switch _Panels on/off", "Control-o", null),
				new MenuItem ("_Compare Directories", "Control-x d", null),
				new MenuItem ("Show Directory S_izes", "F6", null),
				null,
				new MenuItem ("_Command History", null, null),
				new MenuItem ("_Directory Hotlist", "Control-\\", null),
				null,
				new MenuItem ("_Toggle section", "Control-t", null),
				new MenuItem ("_Select", "Alt-+, +", null),
				new MenuItem ("_Unselect", "Alt-\\, -", null),
				new MenuItem ("_Reverse Selection", "Alt-*, *", null),
				null,
				new MenuItem ("_Quit", "F10", null)
			}),
			new MenuBarItem ("Options", null),
			new MenuBarItem ("Right", new MenuItem [] {
				new MenuItem ("_Listing Mode...", null, null),
				new MenuItem ("_Sort order...", null, null),
				new MenuItem ("_Filter...", null, null),
				new MenuItem ("_Rescan", "C-r", null),
			})
		};

		public Panel OtherPanel {
			get {
				if (left == CurrentPanel)
					return right;
				return left;
			}
		}

		public override bool ProcessHotKey (int key)
		{
			if (entry.CursorPosition == 0) {
				if ((key == '>' || key == Keys.RIGHT) && CurrentPanel.CanExpandSelected) {
					CurrentPanel.ExpandSelected ();
					return true;
				}
				if ((key == '<' || key == Keys.LEFT)) {
					CurrentPanel.CollapseAction ();
					return true;
				}
			}
			if (key == 12) { // Control-l
				Terminal.Refresh ();
				return true;
			}

			return base.ProcessHotKey (key);
		}

		void RunCommand ()
		{
			if (!entry.Text.StartsWith ("cd ")) {
				entry.Text = "";
				return;
			}

			string path = entry.Text.Substring (3);
			if (!Directory.Exists (path))
				return;

			CurrentPanel.CurrentPath = path;
			entry.Text = "";
		}

		public override bool ProcessKey (int key)
		{
			if (key == '\n' && entry.Text.Length > 0) {
				RunCommand ();
				return true;
			}
			
			if (base.ProcessKey (key))
				return true;

			if (entry.ProcessKey (key))
				return true;
			
			return false;
		}

		public Shell () : base (0, 0, Terminal.Cols, Terminal.Lines)
		{
			SetupGUI ();
		}

		public override void DoSizeChanged ()
		{
			base.DoSizeChanged ();
			entry.y = Terminal.Lines - 2;
			entry.w = Terminal.Cols - prompt.Text.Length;
		}

		void View (string file)
		{
		}

		void SetupGUI ()
		{
//			var height = Terminal.Lines - 4;

			left = Panel.Create (this, "left", 4);
			right = Panel.Create (this, "right", 4);
			bar = new ButtonBar (bar_labels);
			menu = new MenuBar (mc_menu);
			prompt = new Label (0, Terminal.Lines - 2, "bash$ acción ") {
				Color = Terminal.ColorBasic
			};
			entry = new Entry (prompt.Text.Length, Terminal.Lines - 2, Terminal.Cols - prompt.Text.Length, "") {
				Color = Terminal.ColorBasic,
				CanFocus = false,
			};
			
			bar.Action += delegate (int n) {
				switch (n) {
				case 3:
					var selected = CurrentPanel.SelectedNode;
					if (selected is Listing.DirNode)
						CurrentPanel.ChangeDir (selected as Listing.DirNode);
					else {
						Stream stream;
						try {
							stream = File.OpenRead (CurrentPanel.SelectedPath);
						} catch {
							ErrorDialog.Error ("Could not open file", CurrentPanel.SelectedPath);
							return;
						}
						FullView.Show (stream);

						stream.Dispose ();
					}
					break;
				case 5:
					CurrentPanel.Copy (OtherPanel.CurrentPath);
					break;
					
				case 9:
					menu.Activate (0);
					break;

				case 10:
					var r = MessageBox.Query (56, 7, "Midnight Commander NG", "Do you really want to quit?", "Yes", "No");
					Running &= r != 0;
					break;
					
				default:
					break;
				}
			};

			Add (left);
			Add (right);
			Add (bar);
			Add (menu);
			Add (prompt);
			Add (entry);

			SetFocus (left);
		}

		[System.Runtime.InteropServices.DllImportAttribute ("libc")]
		extern static void setlocale (int code, string str);

		static void Main ()
		{
			setlocale (6, "");
			Terminal.Init (false);
					
			var s = new Shell ();
			Terminal.Run (s);
		}
	}
}
