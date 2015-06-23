//
// File viewer
//
// The file viewer can be used as a widget (ViewWidget) or as a
// command that drives the whole viewing system (FullView -- a
// full screen Container)
//
// Supports multiple encodings + raw viewing.
using System;
using System.IO;
using System.Text;
using CursesSharp;
using CursesSharp.Gui;

namespace CursesSharp.Gui
{
	public class FileViewWidget : Widget
	{
		// When in "cooked" mode, this reads encoded text
		StreamReader reader;

		// Encoding used to read
		Encoding encoding;

		// When in raw mode, we read directly from this stream
		Stream source;

		// The top byte displayed by the view
		long top_byte;

		// The first byte in the file that has contents (skipping the BOM)
		long first_file_byte;

		// Whether we are doing a Raw rendering, or a processed one.
		bool Raw;

		// Dirty management
		DateTime dirtystart;
		int dirty;

		bool wrap = true;

		public FileViewWidget (int x, int y, int w, int h, bool raw, Stream source) : base (x, y, w, h)
		{ 
			this.source = source;
			this.Raw = raw;

			CanFocus = true;
			DetectEncoding ();
			top_byte = first_file_byte;
		}

		static Encoding utf8 = new UTF8Encoding (false, false);
		static Encoding utf16le = new UnicodeEncoding (false, false);
		static Encoding utf16be = new UnicodeEncoding (true, false);
		static Encoding utf32le = new UTF32Encoding (false, false);
		static Encoding utf32be = new UTF32Encoding (true, false);

		int GetChar ()
		{
			return Raw ? source.ReadByte () : reader.Read ();
		}

		void DetectEncoding ()
		{
			if (Raw)
				return;

			first_file_byte = 0;
			encoding = utf8;

			// Try to detect the encoding
			var buffer = new byte [4];

			var n = source.Read (buffer, 0, 4);
			if (n == -1)
				return;
			if (n > 1 && buffer [0] == 0xfe && buffer [1] == 0xff) {
				encoding = utf16be;
				first_file_byte = 2;
			} else if (n > 1 && buffer [0] == 0xff && buffer [1] == 0xfe) {
				if (n > 3 && buffer [2] == 0 && buffer [3] == 0) {
					encoding = utf32le;
					first_file_byte = 4;
				} else {
					encoding = utf16le;
					first_file_byte = 2;
				}
			} else if (n > 3 && buffer [0] == 0 && buffer [1] == 0 && buffer [2] == 0xfe && buffer [3] == 0xff) {
				encoding = utf32be;
				first_file_byte = 4;
			}
			if (n > 2 && buffer [0] == 0xef && buffer [1] == 0xbb && buffer [2] == 0xbf) {
				encoding = utf8;
				first_file_byte = 3;
			}
			source.Position = first_file_byte;
			reader = new StreamReader (source, encoding);
		}

		void SetPosition (long position)
		{
			source.Position = position;
			if (Raw)
				return;
			reader.DiscardBufferedData ();
		}

		// Fills with blanks from the current column/row
		// until the end of the widget area
		public void ClearToEnd (int ccol, int crow)
		{
			for (int r = crow; r < h; r++) {
				Move (r + y, ccol + x);
				for (int c = ccol; c < w; c++)
					Stdscr.Add (' ');
				ccol = 0;
			}
		}

		public void ClearToEnd (int ccol)
		{
			for (int c = ccol; c < w; c++)
				Stdscr.Add (' ');
		}

		void DrawStatus ()
		{
			Move (y, x);
			Stdscr.Attr = Container.ContainerColorFocus;
			for (int i = 0; i < w; i++)
				Stdscr.Add (' ');
			Move (y, x);
			Stdscr.Add ("File: FOOBAR");
		}

		public override void Redraw ()
		{
			DrawStatus ();
			DrawView ();
		}

		void DrawView ()
		{
			int col = 0;
			bool skip_until_newline = false;

			Stdscr.Attr = Container.ContainerColorNormal;
			Move (y + 1, x);
			SetPosition (top_byte);
			for (int row = 0; row < h;) {
				int c = GetChar ();
				switch (c) {
				/* End of file */
				case -1:
					ClearToEnd (col, row);
					row = h;
					continue;

				case 10:
					ClearToEnd (col);
					col = 0;
					row++;
					skip_until_newline = false;
					Move (y + row, x + col);
					continue;

				case 9:
					for (int nc = (col / 8 + 1) * 8; col < nc; col++)
						Stdscr.Add (' ');

					continue;

				case 13:
					continue;
				}

				// Control chars or unicode > 0xffff
				if (c < 32 || c > 0xffff)
					c = '.';

				if (skip_until_newline)
					continue;

				Stdscr.Add ((char)c);
				col++;
				if (col > w) {
					if (Wrap) {
						col = 0;
						row++;
					} else
						skip_until_newline = true;
				}
			}
		}

		public bool Wrap {
			get {
				return wrap;
			}
			set {
				wrap = value;
				Redraw ();
			}
		}

		int ReadChar ()
		{
			if (Raw || encoding == utf8)
				return source.ReadByte ();

			var a = source.ReadByte ();
			var b = source.ReadByte ();
			if (a == -1 || b == -1)
				return -1;

			if (encoding == utf16le)
				return b << 8 | a;
			if (encoding == utf16be)
				return a << 8 | b;

			var c = source.ReadByte ();
			var d = source.ReadByte ();
			if (c == -1 || d == -1)
				return -1;

			if (encoding == utf32be)
				return (a << 24) | (b << 16) | (c << 8) | d;
			return (d << 24) | (c << 16) | (b << 8) | a;
		}

		int ReadChar (long position)
		{
			source.Position = position;
			return ReadChar ();
		}

		int ScanSize ()
		{
			if (Raw || encoding == utf8)
				return 1;
			if (encoding == utf16be || encoding == utf16le)
				return 2;
			if (encoding == utf32be || encoding == utf32le)
				return 4;
			return 1;
		}

		// We can not use the StreamReader here
		//
		// Returns the new file offset where we start displaying, or -1 if we can not
		// scroll further.
		long ScanForward (long start, int lines)
		{
			SetPosition (start);

			for (int line = 0; line < lines;) {
				int b = ReadChar ();

				if (b == -1)
					return -1;

				if (b == '\n')
					line++;
			}
			return source.Position;
		}

		long WrappedScanForward (long start, int lines)
		{
			SetPosition (start);

			int col = 0;
			for (int line = 0; line < lines;) {
				int b = ReadChar ();

				switch (b) {
				case -1:
					return -1;
				case '\n':
					col = 0;
					line++;
					break;
				case '\r':
								// ignore;
					break;
				case '\t':
					col = (col / 8 + 1) * 8;
					if (col > w) {
						line++;
						col = col - w;
					}
					break;
				default:
					col++;
					break;
				}
				if (col == w) {
					col = 0;
					line++;
				}
			}
			return source.Position;
		}


		// We can not use the StreamReader here
		//
		// Returns the new file offset where we start displaying, or -1 if we can not
		// scroll further.
		long ScanBackward (long start, int lines)
		{
			int scan_size = ScanSize ();
			long scan = start - scan_size;

			for (int line = 0; line < lines && scan > first_file_byte;) {
				while (scan > first_file_byte) {
					int b = ReadChar (scan - scan_size);
					if (b == -1)
						return first_file_byte;
					if (b == '\n') {
						if (++line == lines)
							return scan;
						scan -= scan_size;
						break;
					} 
					scan -= scan_size;
				}
			}
			return scan;
		}

		// Counts the lenght of the string between [start,end) assuming that
		// @start is the first column and that there are no new-lines embedded
		int CountLength (long start, long end)
		{
			int len = 0;

			for (long pos = start; pos < end; pos++) {
				int b = ReadChar (pos);
				switch (b) {
				case -1:
					return len;
				case '\r':
				case '\n': // this really should not be called with newlines in the range
					continue;
				case '\t':
					len = (len / 8 + 1) * 8;
					continue;
				default:
					len++;
					break;
				}
			}
			return len;
		}

		long WrappedScanBackward (long start, int lines)
		{
			//int scan_size = ScanSize ();
			long scan = start;

			for (int line = 0; line < lines && scan > first_file_byte;) {
				var previous_line = ScanBackward (scan, 1);
				int chars = CountLength (previous_line, scan);
				int linecount = chars == 0 ? 1 : (chars + w - 1) / w;

				if (line + linecount <= lines) {
					scan = previous_line;
					line += linecount;
					continue;
				}
				return WrappedScanForward (previous_line, linecount - (lines - line));
			}
			return scan;
		}

		void SetTopByte (long newpos)
		{
			if (dirty == 0)
				dirtystart = DateTime.UtcNow;
			dirty++;
			top_byte = newpos;
		}

		// Invoke this method instead of Redraw+refresh, as this takes care of updating while
		// scrolling fast.
		void UpdateView ()
		{
			if (Terminal.MainLoop.EventsPending ()) {
				if (dirty < 10 && (DateTime.UtcNow - dirtystart) < TimeSpan.FromMilliseconds (500)) {
					Log ("Skipped update, dirty={0} time={1}", dirty, DateTime.UtcNow - dirtystart);
					return;
				}
			}
			// to test the dirty system:
			// System.Threading.Thread.Sleep (500);
			Redraw ();
			Stdscr.Refresh ();
			dirty = 0;
		}

		long Scan (long from, int lines)
		{
			if (!Raw)
				reader.DiscardBufferedData ();
			if (lines > 0)
				return Wrap ? WrappedScanForward (from, lines) : ScanForward (from, lines);
			
			return Wrap ? WrappedScanBackward (from, -lines) : ScanBackward (from, -lines);
		}

		void Scroll (int lines)
		{
			Log ("Scroll: {0}", lines);
			long newpos = Scan (top_byte, lines);
			Log ("Scroll: {0} top_byte={1} newpos={2}", lines, top_byte, newpos);
			if (newpos == -1)
				return;
			SetTopByte (newpos);
			UpdateView ();
		}

		void GoTop ()
		{
			SetTopByte (first_file_byte);
			Redraw ();
			Stdscr.Refresh ();
		}

		void GoBottom ()
		{
			long last = source.Length;
			SetPosition (last);
			var newtop = Scan (last > 0 ? last - 1 : 0, -h + 1);
			if (newtop == -1)
				return;
			SetTopByte (newtop);
			Redraw ();
			Stdscr.Refresh ();
		}

		public override bool ProcessKey (int key)
		{
			switch (key) {
			// page down: space bar, control-v, page down:
			case 32: 
			case 22:
			case Keys.NPAGE:
				Scroll (h - 1);
				break;

			// down-arrow, control-n
			case Keys.DOWN:
			case 14:
				Scroll (1);
				break;

			// backspace, page-up, Alt-V
			case 8:
			case Keys.PPAGE:
			case Curses.KeyAlt + 'v':
				Scroll (-(h - 1));
				break;

			// cursor, control-p
			case Keys.UP:
			case 16:
				Scroll (-1);
				break;

			case Keys.HOME:
			case Curses.KeyAlt + '<':
				GoTop ();
				break;

			case Keys.END:
			case Curses.KeyAlt + '>':
				GoBottom ();
				break;
			default:
				return false;
			}
			return true;
		}
	}

	public class FullView : Container
	{
		FileViewWidget view;
		ButtonBar bar;

		string[] bar_labels = {
			"", "Wrap", "Quit", "", "", "", "", "", "", "Quit"
		};

		void SetWrap (bool wrap)
		{
			if (view.Wrap) {
				view.Wrap = false;
				bar_labels [1] = "Wrap";
			} else {
				view.Wrap = true;
				bar_labels [1] = "Unwrap";
			}
			Stdscr.Refresh ();
		}

		public FullView (Stream source) : base (0, 0, Terminal.Cols, Terminal.Lines)
		{
			view = new FileViewWidget (0, 0, Terminal.Cols, Terminal.Lines - 1, false, source);
			bar = new ButtonBar (bar_labels);
			bar.Action += delegate (int n) {
				switch (n) {
				case 2:
					SetWrap (!view.Wrap);
					break;
				case 3:
				case 10:
					Running = false;
					break;
				}
			};

			Add (view);
			Add (bar);
		}

		static public void Show (Stream source)
		{
			var full = new FullView (source);
			Terminal.Run (full);
		}
	}
}

