//
// mc.cs: Panel controls
//
// Authors:
//   Miguel de Icaza (miguel@gnome.org)
//
// Licensed under the MIT X11 license
//
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using CursesSharp;
using CursesSharp.Gui;
using Mono.Unix;

namespace MouselessCommander
{

	public class Listing : IEnumerable<Listing.FileNode>
	{
		string url;
		FileNode[] nodes;
		Comparison<FileNode> compare;

		public int Count { get; private set; }

		public class FileNode
		{
			public int StartIdx;
			public int Nested;
			public bool Marked;
			public UnixFileSystemInfo Info;

			//
			// Have to use this ugly hack, because Mono.Posix does not
			// return ".." in directory listings.   And creating instances
			// of it, return the parent name, instead of ".."
			//
			public virtual string Name {
				get {
					return Info.Name;
				}
			}

			public FileNode (UnixFileSystemInfo info)
			{
				Info = info;
			}
		}

		public class DirNode : FileNode
		{
			public FileNode[] Nodes;
			public bool Expanded;

			public DirNode (UnixFileSystemInfo info) : base (info)
			{
			}
		}

		public class DirNodeDotDot : DirNode
		{
			public DirNodeDotDot (UnixFileSystemInfo info) : base (info)
			{
			}

			public override string Name {
				get {
					return "..";
				}
			}
		}

		public IEnumerator<FileNode> GetEnumerator ()
		{
			foreach (var a in nodes)
				yield return a;
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			foreach (var a in nodes)
				yield return a;
		}

		FileNode GetNodeAt (int idx, FileNode[] nodes)
		{
			if (nodes == null)
				throw new ArgumentNullException ("nodes");

			for (int i = 0; i < nodes.Length; i++) {
				if (nodes [i].StartIdx == idx)
					return nodes [i];
				if (i + 1 == nodes.Length || nodes [i + 1].StartIdx > idx)
					return GetNodeAt (idx, ((DirNode)nodes [i]).Nodes);
			}
			return null;
		}

		string GetName (int idx, string start, FileNode[] nodes)
		{
			for (int i = 0; i < nodes.Length; i++) {
				if (nodes [i].StartIdx == idx)
					return Path.Combine (start, nodes [i].Name);
				if (i + 1 == nodes.Length || nodes [i + 1].StartIdx > idx)
					return GetName (idx, Path.Combine (start, nodes [i].Name), ((DirNode)nodes [i]).Nodes);
			}
			throw new Exception ("This should not happen");
		}

		string GetPathAt (int idx, FileNode[] nodes)
		{
			for (int i = 0; i < nodes.Length; i++) {
				if (nodes [i].StartIdx == idx)
					return nodes [i].Name;
				if (i + 1 == nodes.Length || nodes [i + 1].StartIdx > idx)
					return Path.Combine (nodes [i].Name, GetPathAt (idx, ((DirNode)nodes [i]).Nodes));
			}
			return null;
		}

		public string GetPathAt (int idx)
		{
			return GetPathAt (idx, nodes);
		}

		public int NodeWithName (string s)
		{
			for (int i = 0; i < nodes.Length; i++) {
				if (nodes [i].Name == s)
					return i;
			}
			return -1;
			
		}

		public FileNode this [int idx] {
			get {
				var x = GetNodeAt (idx, nodes);
				return x;
			}
		}

		FileNode [] PopulateNodes (bool needDotdot, UnixFileSystemInfo[] root)
		{
			var pnodes = new FileNode [root.Length + (needDotdot ? 1 : 0)];
			int i = 0;

			if (needDotdot) {
				pnodes [0] = new DirNodeDotDot (new UnixDirectoryInfo (".."));
				i++;
			}
			
			foreach (var info in root) {
				pnodes [i++] = info.IsDirectory ? new DirNode (info) : new FileNode (info);
			}

			Array.Sort<FileNode> (pnodes, compare);
			return pnodes;
		}

		int UpdateIndexes (FileNode[] nodes, int start, int level)
		{
			foreach (var n in nodes) {
				var dn = n as DirNode;
				n.StartIdx = start++;
				n.Nested = level;
				if (dn != null && dn.Expanded && dn.Nodes != null)
					start = UpdateIndexes (dn.Nodes, start, level + 1);
			}
			return start;
		}

		Listing (string url, UnixFileSystemInfo[] root, Comparison<FileNode> compare)
		{
			this.url = url;
			this.compare = compare;
			nodes = PopulateNodes (url != "/", root);
			Count = UpdateIndexes (nodes, 0, 0);
		}

		public Listing ()
		{
			nodes = new FileNode [0];
		}

		void LoadChild (int idx)
		{
			var dn = this [idx] as DirNode;
			string name = GetName (idx, url, nodes);
				
			try {
				var udi = new UnixDirectoryInfo (name);
				dn.Nodes = PopulateNodes (true, udi.GetFileSystemEntries ());
				dn.Expanded = true;
//			} catch (Exception e){
			} catch {
				Console.WriteLine ("Error loading {0}", name);
				// Show error?
				return;
			}
			Count = UpdateIndexes (nodes, 0, 0);
		}

		public void Expand (int idx)
		{
			var node = this [idx] as DirNode;
			if (node == null)
				return;
			if (node.Nodes == null) {
				LoadChild (idx);
			} else {
				node.Expanded = true;
				Count = UpdateIndexes (nodes, 0, 0);
			}
		}

		public void Collapse (int idx)
		{
			var node = this [idx] as DirNode;
			if (node == null)
				return;
			node.Expanded = false;
			foreach (var n in node.Nodes)
				n.Marked = false;
			
			Count = UpdateIndexes (nodes, 0, 0);
		}

		public static Listing LoadFrom (string url, Comparison<FileNode> compare)
		{
			try {
				var udi = new UnixDirectoryInfo (url);
				return new Listing (url, udi.GetFileSystemEntries (), compare);
//			} catch (Exception e) {
			} catch {
				return new Listing ();
			}
		}
	}

	public class Panel : Frame
	{
		static uint ColorDir;
		Shell shell;
		
		SortOrder sort_order = SortOrder.Name;
		const bool group_dirs = true;
		Listing listing;
		int top, selected, marked;
		string current_path;

		static Panel ()
		{
			if (Terminal.UsingColor)
				ColorDir = Attrs.BOLD | Terminal.MakeColor (Colors.WHITE, Colors.BLUE);
			else
				ColorDir = Attrs.NORMAL;
		}

		public enum SortOrder
		{
			Unsorted,
			Name,
			Extension,
			ModifyTime,
			AccessTime,
			ChangeTime,
			Size,
			Inode
		}

		public IEnumerable<Listing.FileNode> Selection ()
		{
			if (marked > 0) {
				foreach (var node in listing) {
					if (node.Marked)
						yield return node;
				}
			} else
				yield return listing [selected];
		}

		public Listing.FileNode SelectedNode { 
			get {
				return listing [selected];
			}
		}

		public string SelectedPath {
			get {
				return Path.Combine (CurrentPath, listing.GetPathAt (selected));
			}
		}

		int CompareNodes (Listing.FileNode a, Listing.FileNode b)
		{
			if (a.Name == "..") {
				return b.Name != ".." ? -1 : 0;
			}
		
			int nl = a.Nested - b.Nested;
			if (nl != 0)
				return nl;

			if (sort_order == SortOrder.Unsorted)
				return 0;
			
			bool adir = a is Listing.DirNode;
			bool bdir = b is Listing.DirNode;

			if (adir ^ bdir) {
				if (adir)
					return -1;
				return 1;
			}

			switch (sort_order) {
			case SortOrder.Name:
				return string.Compare (a.Name, b.Name);
				
			case SortOrder.Extension:
				var sa = Path.GetExtension (a.Name);
				var sb = Path.GetExtension (b.Name);
				return string.Compare (sa, sb);
				
			case SortOrder.ModifyTime:
				return DateTime.Compare (a.Info.LastWriteTimeUtc, b.Info.LastWriteTimeUtc);
				
			case SortOrder.AccessTime:
				return DateTime.Compare (a.Info.LastAccessTimeUtc, b.Info.LastAccessTimeUtc);
				
			case SortOrder.ChangeTime:
				return DateTime.Compare (a.Info.LastStatusChangeTimeUtc, b.Info.LastStatusChangeTimeUtc);
				
			case SortOrder.Size:
				long r = a.Info.Length - b.Info.Length;
				if (r < 0)
					return -1;
				if (r > 0)
					return 1;
				return 0;
				
			case SortOrder.Inode:
				r = a.Info.Inode - b.Info.Inode;
				if (r < 0)
					return -1;
				if (r > 0)
					return 1;
				return 0;
			}
			return 0;
		}

		Panel (Shell shell, string path, int x, int y, int w, int h) : base (x, y, w, h, path)
		{
			this.shell = shell;
			CanFocus = true;
			Capacity = h - 2;
			SetCurrentPath (path, false);
			CurrentPath = path;
		}

		void SetCurrentPath (string path, bool refresh)
		{
			current_path = path;
			Title = Path.GetFullPath (path);
			listing = Listing.LoadFrom (current_path, CompareNodes);
			top = 0;
			selected = 0;
			marked = 0;

			if (refresh)
				Redraw ();
		}

		public int Capacity { get; private set; }

		public string CurrentPath {
			get {
				return current_path;
			}

			set {
				SetCurrentPath (value, true);
			}
		}

		public override void Redraw ()
		{
			base.Redraw ();
			Stdscr.Attr = ContainerColorNormal;
			int files = listing.Count;
			
			for (int i = 0; i < Capacity; i++) {
				if (i + top >= files)
					break;

				DrawItem (top + i, top + i == selected);
			}
		}

		public override bool HasFocus {
			get {
				return base.HasFocus;
			}

			set {
				if (value)
					shell.CurrentPanel = this;
				base.HasFocus = value;
			}
		}

		public void DrawItem (int nth, bool isSelected)
		{
			char ch;
			
			if (nth >= listing.Count)
				throw new Exception ("overflow");

			isSelected = HasFocus && isSelected;
				
			Move (y + (nth - top) + 1, x + 1);
			
			Listing.FileNode node = listing [nth];
			uint color;

			if (node == null)
				throw new Exception (String.Format ("Problem fetching item {0}", nth));

			if (node.Info.IsDirectory) {
				color = isSelected ? ColorFocus : ColorDir;
				ch = '/';
			} else {
				color = isSelected ? ColorFocus : ColorNormal;
				ch = ' ';
			}
			if (node.Marked)
				color = isSelected ? ColorHotFocus : ColorHotNormal;

			Stdscr.Attr = color;
			for (int i = 0; i < node.Nested; i++)
				Stdscr.Add ("  ");
			Stdscr.Add (ch);
			Stdscr.Add (node.Name);
		}

		public override void DoSizeChanged ()
		{
			base.DoSizeChanged ();

			if (x == 0) {
				w = Terminal.Cols / 2;
			} else {
				w = Terminal.Cols / 2 + Terminal.Cols % 2;
				x = Terminal.Cols / 2;
			}
			
			h = Terminal.Lines - 4;

			Capacity = h - 2;
		}

		public static Panel Create (Shell shell, string kind, int taken)
		{
			var height = Terminal.Lines - taken;
			
			switch (kind) {
			case "left":
				return new Panel (shell, Environment.CurrentDirectory, 0, 1, Terminal.Cols / 2, height);
					
			case "right":
				return new Panel (shell, Environment.GetFolderPath (Environment.SpecialFolder.Personal), Terminal.Cols / 2, 1, Terminal.Cols / 2 + Terminal.Cols % 2, height);
			}
			return null;
		}

		bool MoveDown ()
		{
			if (selected == listing.Count - 1)
				return true;
			
			DrawItem (selected, false);
			selected++;
			if (selected - top >= Capacity) {
				top += Capacity / 2;
				if (top > listing.Count - Capacity)
					top = listing.Count - Capacity;
				Redraw ();
			} else {
				DrawItem (selected, true);
			}
			return true;
		}

		bool MoveUp ()
		{
			if (selected == 0)
				return true;
			
			DrawItem (selected, false);
			selected--;
			if (selected < top) {
				top -= Capacity / 2;
				if (top < 0)
					top = 0;
				Redraw ();
			} else
				DrawItem (selected, true);
			
			return true;
		}

		void PageDown ()
		{
			if (selected == listing.Count - 1)
				return;

			int scroll = Capacity;
			if (top > listing.Count - 2 * Capacity)
				scroll = listing.Count - scroll - top;
			if (top + scroll < 0)
				scroll = -top;
			top += scroll;
			
			if (scroll == 0)
				selected = listing.Count - 1;
			else {
				selected += scroll;
				if (selected > listing.Count)
					selected = listing.Count - 1;
			}
			if (top > listing.Count)
				top = listing.Count - 1;
			Redraw ();
		}

		void PageUp ()
		{
			if (selected == 0)
				return;
			if (top == 0) {
				DrawItem (selected, false);
				selected = 0;
				DrawItem (selected, true);
			} else {
				top -= Capacity;
				selected -= Capacity;

				if (selected < 0)
					selected = 0;
				if (top < 0)
					top = 0;
				Redraw ();
			}
		}

		void MoveTop ()
		{
			selected = 0;
			top = 0;
			Redraw ();
		}

		void MoveBottom ()
		{
			selected = listing.Count - 1;
			top = Math.Max (0, selected - Capacity + 1);
			Redraw ();
		}

		public bool CanExpandSelected {
			get {
				return listing [selected] is Listing.DirNode;
			}
		}

		public void ExpandSelected ()
		{
			var dn = listing [selected] as Listing.DirNode;
			if (dn == null)
				return;

			listing.Expand (selected);
			Redraw ();
		}

		public void CollapseAction ()
		{
			var dn = listing [selected] as Listing.DirNode;

			// If it is a regular file, navigate to the directory
			if (dn == null || dn.Expanded == false) {
				for (int i = selected - 1; i >= 0; i--) {
					if (listing [i] is Listing.DirNode) {
						selected = i;
						if (selected < top)
							top = selected;
						Redraw ();
						return;
					}
				}
				return;
			}

			listing.Collapse (selected);
			Redraw ();
		}

		//
		// Handler for the return key on an item
		//
		void Action ()
		{
			var node = listing [selected] as Listing.DirNode;

			if (node != null)
				ChangeDir (node);
		}

		public void ChangeDir (Listing.DirNode node)
		{
			string focus = node is Listing.DirNodeDotDot ? Path.GetFileName (Title) : null;
			SetCurrentPath (Path.Combine (CurrentPath, listing.GetPathAt (selected)), false);

			if (focus != null) {
				int idx = listing.NodeWithName (focus);
				if (idx != -1) {
					selected = idx;

					// This could use some work to center on going up.
					if (selected >= Capacity) {
						top = selected;
					}
				}
			}
			Redraw ();
		}

		public void Copy (string targetDir)
		{
			const string msg_file = "Copy file \"{0}\" to: ";
			const int dlen = 68;
			const int ilen = dlen - 6;
			var d = new Dialog (dlen, 8, "Copy");

			if (marked > 1)
				d.Add (new Label (1, 0, String.Format ("Copy {0} files", marked)));
			else
				d.Add (new Label (1, 0, String.Format (msg_file, listing.GetPathAt (selected).Ellipsize (ilen - msg_file.Length))));

			bool proceed = false;

			var targetEntry = new Entry (1, 1, ilen, targetDir ?? "");
			d.Add (targetEntry);

			var b = new Button (0, 0, "Ok", true);
			b.Clicked += delegate {
				d.Running = false;
				proceed = true;
			};
			d.AddButton (b);
			b = new Button (0, 0, "Cancel", false);
			b.Clicked += (o, s) => d.Running = false;
			d.AddButton (b);
			
			Terminal.Run (d);
			if (!proceed)
				return;

			if (targetEntry.Text == "") {
				ErrorDialog.Error ("Empty target directory");
				return;
			}
				
			PerformCopy (targetEntry.Text);
		}

		int ComputeTotalFiles ()
		{
			// Later we should change this with a directory scan
			return marked > 0 ? marked : 1;
		}

		void PerformCopy (string targetDir)
		{
			double? total_bytes = null;

			var progress = new ProgressInteraction ("Copying", ComputeTotalFiles (), total_bytes);
			var runstate = Terminal.Begin (progress);
			using (var copyOperation = new CopyOperation (progress)) {
#if !DEBUG
				var timer = Terminal.MainLoop.AddTimeout (TimeSpan.FromSeconds (1), mainloop => {
					progress.UpdateStatus (copyOperation);
					return true;
				});
				Task t = Task.Factory.StartNew (delegate {
#endif
				foreach (var node in Selection ()) {
					bool isDir = node is Listing.DirNode;
					var r = copyOperation.Perform (CurrentPath, listing.GetPathAt (node.StartIdx), isDir, node.Info.Protection, targetDir);
					if (r == FileOperation.Result.Cancel)
						break;
				}

#if !DEBUG
					Terminal.Stop ();
				}, null);
				Terminal.RunLoop (runstate, true);
				Terminal.MainLoop.RemoveTimeout (timer);
#endif
			}
			
			Terminal.End (runstate);
		}

		public override bool ProcessKey (int key)
		{
			var result = true;
			switch (key) {
			case (int) '>' +   Curses.KeyAlt:
				MoveBottom ();
				break;
				
			case (int) '<' + Curses.KeyAlt:
				MoveTop ();
				break;
				
			case Keys.UP:
			case 16: // Control-p
				result = MoveUp ();
				break;
				
			case Keys.DOWN:
			case 14: // Control-n
				result = MoveDown ();
				break;

			case 22: // Control-v
			case Keys.NPAGE:
				PageDown ();
				break;

			case (int) '\n':
				Action ();
				break;
				
			case Keys.PPAGE:
			case (int)'v' + Curses.KeyAlt:
				PageUp ();
				break;

			case Keys.INSERTKEY: //Curses.KeyInsertChar:
			case 20: // Control-t
				if (listing [selected].Name == "..")
					return true;
				listing [selected].Marked = !listing [selected].Marked;
				if (listing [selected].Marked)
					marked++;
				else
					marked--;
				MoveDown ();
				break;
					
			default:
				result = false;
				break;
			}
			if (result)
				Stdscr.Refresh ();
			return result;
		}
	}
}
