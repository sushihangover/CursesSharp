//
// gui.cs: Simple curses-based GUI toolkit, core
//
// Authors:
//   Miguel de Icaza (miguel.de.icaza@gmail.com)
//
// Copyright (C) 2007-2011 Novell (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using CursesSharp;

namespace CursesSharp.Gui {

	/// <summary>
	/// The fill values apply from the given x, y values, they will not do
	/// a full fill, you must compute x, y yourself.
	/// </summary>
	[Flags]
	public enum Fill {
		None = 0,
		Horizontal = 1,
		Vertical = 2
	}

	public delegate void Action ();
	
	/// <summary>
	///   Base class for creating curses widgets
	/// </summary>
	public abstract class Widget {
		/// <summary>
		///    Points to the container of this widget
		/// </summary>
		public Container Container;
		
		/// <summary>
		///    The x position of this widget
		/// </summary>
		public int x;

		/// <summary>
		///    The y position of this widget
		/// </summary>
		public int y;

		/// <summary>
		///    The width of this widget, it is the area that receives mouse events and that must be repainted.
		/// </summary>
		public int w;

		/// <summary>
		///    The height of this widget, it is the area that receives mouse events and that must be repainted.
		/// </summary>
		public int h;
		
		bool can_focus;
		bool has_focus;
		public Fill Fill;
		
		static StreamWriter l;
		
		/// <summary>
		///   Utility function to log messages
		/// </summary>
		/// <remarks>
		///    <para>This is a utility function that you can use to log messages
		///    that will be stored in a file (as curses has taken over the
		///    screen and you can not really log information there).</para>
		///    <para>
		///    The data is written to the file "log2" for now</para>
		/// </remarks>
		public static void Log (string s)
		{
			if (l == null)
				l = new StreamWriter (File.Create ("log2"));
			
			l.WriteLine (s);
			l.Flush ();
		}

		/// <summary>
		///   Utility function to log messages
		/// </summary>
		/// <remarks>
		///    <para>This is a utility function that you can use to log messages
		///    that will be stored in a file (as curses has taken over the
		///    screen and you can not really log information there). </para>
		///    <para>
		///    The data is written to the file "log2" for now</para>
		/// </remarks>
		public static void Log (string s, params object [] args)
		{
			Log (String.Format (s, args));
		}
		
		/// <summary>
		///   Public constructor for widgets
		/// </summary>
		/// <remarks>
		///   <para>
		///      Constructs a widget that starts at positio (x,y) and has width w and height h.
		///      These parameters are used by the methods <see cref="Clear"/> and <see cref="Redraw"/>
		///   </para>
		/// </remarks>
		public Widget (int x, int y, int w, int h)
		{
			this.x = x;
			this.y = y;
			this.w = w;
			this.h = h;
			Container = Terminal.EmptyContainer;
		}

		/// <summary>
		///   Focus status of this widget
		/// </summary>
		/// <remarks>
		///   <para>
		///     This is used typically by derived classes to flag whether
		///     this widget can receive focus or not.    Focus is activated
		///     by either clicking with the mouse on that widget or by using
		////    the tab key.
		///   </para>
		/// </remarks>
		public bool CanFocus {
			get {
				return can_focus;
			}

			set {
				can_focus = value;
			}
		}

		/// <summary>
		///   Gets or sets the current focus status.
		/// </summary>
		/// <remarks>
		///   <para>
		///     A widget can grab the focus by setting this value to true and
		///     the current focus status can be inquired by using this property.
		///   </para>
		/// </remarks>
		public virtual bool HasFocus {
			get {
				return has_focus;
			}

			set {
				has_focus = value;
				Redraw ();
			}
		}

		/// <summary>
		///   Moves inside the first location inside the container
		/// </summary>
		/// <remarks>
		///     <para>This moves the current cursor position to the specified
		///     line and column relative to the container
		///     client area where this widget is located.</para>
		///   <para>The difference between this
		///     method and <see cref="BaseMove"/> is that this
		///     method goes to the beginning of the client area
		///     inside the container while <see cref="BaseMove"/> goes to the first
		///     position that container uses.</para>
		///   <para>
		///     For example, a Frame usually takes up a couple
		///     of characters for padding.   This method would
		///     position the cursor inside the client area,
		///     while <see cref="BaseMove"/> would position
		///     the cursor at the top of the frame.
		///   </para>
		/// </remarks>
		public void Move (int line, int col)
		{
			Container.ContainerMove (line, col);
		}
		

		/// <summary>
		///   Move relative to the top of the container
		/// </summary>
		/// <remarks>
		///     <para>This moves the current cursor position to the specified
		///     line and column relative to the start of the container
		///     where this widget is located.</para>
		///   <para>The difference between this
		///     method and <see cref="Move"/> is that this
		///     method goes to the beginning of the container,
		///     while <see cref="Move"/> goes to the first
		///     position that widgets should use.</para>
		///   <para>
		///     For example, a Frame usually takes up a couple
		///     of characters for padding.   This method would
		///     position the cursor at the beginning of the
		///     frame, while <see cref="Move"/> would position
		///     the cursor within the frame.
		///   </para>
		/// </remarks>
		public void BaseMove (int line, int col)
		{
			Container.ContainerBaseMove (line, col);
		}
		
		/// <summary>
		///   Clears the widget region withthe current color.
		/// </summary>
		/// <remarks>
		///   <para>
		///     This clears the entire region used by this widget.
		///   </para>
		/// </remarks>
		public void Clear ()
		{
			for (int line = 0; line < h; line++){
				BaseMove (y + line, x);
				for (int col = 0; col < w; col++){
					Stdscr.Add (' ');
				}
			}
		}
		
		/// <summary>
		///   Redraws the current widget, must be overwritten.
		/// </summary>
		/// <remarks>
		///   <para>
		///     This method should be overwritten by classes
		///     that derive from Widget.   The default
		///     implementation of this method just fills out
		///     the region with the character 'x'. 
		///   </para>
		///   <para>
		///     Widgets are responsible for painting the
		///     entire region that they have been allocated.
		///   </para>
		/// </remarks>
		public virtual void Redraw ()
		{
			for (int line = 0; line < h; line++){
				Move (y + line, x);
				for (int col = 0; col < w; col++){
					Stdscr.Add ('x');
				}
			}
		}

		/// <summary>
		///   If the widget is focused, gives the widget a
		///     chance to process the keystroke. 
		/// </summary>
		/// <remarks>
		///   <para>
		///     Widgets can override this method if they are
		///     interested in processing the given keystroke.
		///     If they consume the keystroke, they must
		///     return true to stop the keystroke from being
		///     processed by other widgets or consumed by the
		///     widget engine.    If they return false, the
		///     keystroke will be passed out to other widgets
		///     for processing. 
		///   </para>
		/// </remarks>
		public virtual bool ProcessKey (int key)
		{
			return false;
		}

		/// <summary>
		///   Gives widgets a chance to process the given
		///     mouse event. 
		/// </summary>
		/// <remarks>
		///     Widgets can inspect the value of
		///     ev.ButtonState to determine if this is a
		///     message they are interested in (typically
		///     ev.ButtonState &amp; Curses.Event.Button1Clicked).
		/// </remarks>
		public virtual void ProcessMouse ( MouseEvent ev)
		{
		}

		/// <summary>
		///   This method can be overwritten by widgets that
		///     want to provide accelerator functionality
		///     (Alt-key for example).
		/// </summary>
		/// <remarks>
		///   <para>
		///     Before keys are sent to the widgets on the
		///     current Container, all the widgets are
		///     processed and the key is passed to the widgets
		///     to allow some of them to process the keystroke
		///     as a hot-key. </para>
		///  <para>
		///     For example, if you implement a button that
		///     has a hotkey ok "o", you would catch the
		///     combination Alt-o here.  If the event is
		///     caught, you must return true to stop the
		///     keystroke from being dispatched to other
		///     widgets.
		///  </para>
		///  <para>
		///    Typically to check if the keystroke is an
		///     Alt-key combination, you would use
		///     Curses.IsAlt(key) and then Char.ToUpper(key)
		///     to compare with your hotkey.
		///  </para>
		/// </remarks>
		public virtual bool ProcessHotKey (int key)
		{
			return false;
		}

		/// <summary>
		///   This method can be overwritten by widgets that
		///     want to provide accelerator functionality
		///     (Alt-key for example), but without
		///     interefering with normal ProcessKey behavior.
		/// </summary>
		/// <remarks>
		///   <para>
		///     After keys are sent to the widgets on the
		///     current Container, all the widgets are
		///     processed and the key is passed to the widgets
		///     to allow some of them to process the keystroke
		///     as a cold-key. </para>
		///  <para>
		///    This functionality is used, for example, by
		///    default buttons to act on the enter key.
		///    Processing this as a hot-key would prevent
		///    non-default buttons from consuming the enter
		///    keypress when they have the focus.
		///  </para>
		/// </remarks>
		public virtual bool ProcessColdKey (int key)
		{
			return false;
		}
		
		/// <summary>
		///   Moves inside the first location inside the container
		/// </summary>
		/// <remarks>
		///   <para>
		///     A helper routine that positions the cursor at
		///     the logical beginning of the widget.   The
		///     default implementation merely puts the cursor at
		///     the beginning, but derived classes should find a
		///     suitable spot for the cursor to be shown.
		///   </para>
		///   <para>
		///     This method must be overwritten by most
		///     widgets since screen repaints can happen at
		///     any point and it is important to leave the
		///     cursor in a position that would make sense for
		///     the user (as not all terminals support hiding
		///     the cursor), and give the user an impression of
		///     where the cursor is.   For a button, that
		///     would be the position where the hotkey is, for
		///     an entry the location of the editing cursor
		///     and so on.
		///   </para>
		/// </remarks>
		public virtual void PositionCursor ()
		{
			Move (y, x);
		}

		/// <summary>
		///   Method to relayout on size changes.
		/// </summary>
		/// <remarks>
		///   <para>
		///     This method can be overwritten by widgets that
		///     might be interested in adjusting their
		///     contents or children (if they are
		///     containers). 
		///   </para>
		/// </remarks>
		public virtual void DoSizeChanged ()
		{
		}
		
		/// <summary>
		///   Utility function to draw frames
		/// </summary>
		/// <remarks>
		///    Draws a frame with the current color in the
		///    specified coordinates.
		/// </remarks>
		static public void DrawFrame (int col, int line, int width, int height)
		{
			DrawFrame (col, line, width, height, false);
		}

		/// <summary>
		///   Utility function to draw strings that contain a hotkey
		/// </summary>
		/// <remarks>
		///    Draws a string with the given color.   If a character "_" is
		///    found, then the next character is drawn using the hotcolor.
		/// </remarks>
		static public void DrawHotString (string s, uint hotcolor, uint color)
		{
			Stdscr.Attr = color;
			foreach (char c in s){
				if (c == '_'){
					Stdscr.Attr = hotcolor;
					continue;
				}
				Stdscr.Add (c);
				Stdscr.Attr =  color;
			}
		}

		/// <summary>
		///   Utility function to draw frames
		/// </summary>
		/// <remarks>
		///    Draws a frame with the current color in the
		///    specified coordinates.
		/// </remarks>
		static public void DrawFrame (int col, int line, int width, int height, bool fill)
		{
			int b;
			Stdscr.Move (line, col);
			Stdscr.Add (Acs.ULCORNER);
			for (b = 0; b < width-2; b++)
				Stdscr.Add (Acs.HLINE);
			Stdscr.Add (Acs.URCORNER);
			
			for (b = 1; b < height-1; b++){
				Stdscr.Move (line+b, col);
				Stdscr.Add (Acs.VLINE);
				if (fill){
					for (int x = 1; x < width-1; x++)
						Stdscr.Add (' ');
				} else
					Stdscr.Move (line+b, col+width-1);
				Stdscr.Add (Acs.VLINE);
			}
			Stdscr.Move (line + height-1, col);
			Stdscr.Add (Acs.LLCORNER);
			for (b = 0; b < width-2; b++)
				Stdscr.Add (Acs.HLINE);
			Stdscr.Add (Acs.LRCORNER);
		}

		/// <summary>
		///   The color used for rendering an unfocused widget.
		/// </summary>
		public uint ColorNormal {
			get {
				return Container.ContainerColorNormal;
			}
		}

		/// <summary>
		///   The color used for rendering a focused widget.
		/// </summary>
		public uint ColorFocus {
			get {
				return Container.ContainerColorFocus;
			}
		}

		/// <summary>
		///   The color used for rendering the hotkey on an
		///     unfocused widget. 
		/// </summary>
		public uint ColorHotNormal {
			get {
				return Container.ContainerColorHotNormal;
			}
		}

		/// <summary>
		///   The color used to render a hotkey in a focused widget.
		/// </summary>
		public uint ColorHotFocus {
			get {
				return Container.ContainerColorHotFocus;
			}
		}
	}

	/// <summary>
	///   Label widget, displays a string at a given position.
	/// </summary>
	public class Label : Widget {
		protected string text;
		public uint Color = uint.MaxValue;
		
		/// <summary>
		///   Public constructor: creates a label at the given
		///   coordinate with the given string.
		/// </summary>
		public Label (int x, int y, string s) : base (x, y, s.Length, 1)
		{
			text = s;
		}

		public Label (int x, int y, string s, params object [] args) : base (x, y, String.Format (s, args).Length, 1)
		{
			text = String.Format (s, args);
		}
		
		public override void Redraw ()
		{
			if (Color != uint.MaxValue)
				Stdscr.Attr =  Color;
			else
				Stdscr.Attr =  ColorNormal;

			Move (y, x);
			Stdscr.Add (text);
		}


		/// <summary>
		///   The text displayed by this widget.
		/// </summary>
		public virtual string Text {
			get {
				return text;
			}
			set {
				Stdscr.Attr =  (ColorNormal);
				Move (y, x);
				for (int i = 0; i < text.Length; i++)
					Stdscr.Add (' ');
				text = value;
				Redraw ();
			}
		}
	}

	/// <summary>
	///   A label that can be trimmed to a given position
	/// </summary>
	/// <remarks>
	///   Just like a label, but it can be trimmed to a given
	///   position if the text being displayed overflows the
	///   specified width. 
	/// </remarks>
	public class TrimLabel : Label {
		string original;
		
		/// <summary>
		///   Public constructor.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public TrimLabel (int x, int y, int w, string s) : base (x, y, s)
		{
			original = s;

			SetString (w, s);
		}

		void SetString (int w, string s)
		{
			if ((Fill & Fill.Horizontal) != 0)
				w = Container.w - Container.Border * 2 - x;
			
			this.w = w;
			if (s.Length > w){
				if (w < 5)
					text = s.Substring (0, w);
				else {
					text = s.Substring (0, w/2-2) + "..." + s.Substring (s.Length - w/2+1);
				}
			} else
				text = s;
		}

		public override void DoSizeChanged ()
		{
			if ((Fill & Fill.Horizontal) != 0)
				SetString (0, original);
		}

		/// <summary>
		///   The text displayed by this widget.
		/// </summary>
		public override string Text {
			get {
				return original;
			}

			set {
				SetString (w, value);
				base.Text = text;
			}
		}
	}
	
	/// <summary>
	///   Text data entry widget
	/// </summary>
	/// <remarks>
	///   The Entry widget provides Emacs-like editing
	///   functionality,  and mouse support.
	/// </remarks>
	public class Entry : Widget {
		string text, kill;
		int first, point;
		uint color;
		bool used;
		
		/// <summary>
		///   Changed event, raised when the text has clicked.
		/// </summary>
		/// <remarks>
		///   Client code can hook up to this event, it is
		///   raised when the text in the entry changes.
		/// </remarks>
		public event EventHandler Changed;
		
		/// <summary>
		///   Public constructor.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public Entry (int x, int y, int w, string s) : base (x, y, w, 1)
		{
			if (s == null)
				s = "";
			
			text = s;
			point = s.Length;
			first = point > w ? point - w : 0;
			CanFocus = true;
			Color = Terminal.ColorDialogFocus;
		}

		/// <summary>
		///   Sets or gets the text in the entry.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public string Text {
			get {
				return text;
			}

			set {
				text = value;
				if (point > text.Length)
					point = text.Length;
				first = point > w ? point - w : 0;
				Redraw ();
			}
		}

		/// <summary>
		///   Sets the secret property.
		/// </summary>
		/// <remarks>
		///   This makes the text entry suitable for entering passwords. 
		/// </remarks>
		public bool Secret { get; set; }

		/// <summary>
		///    The color used to display the text
		/// </summary>
		public uint Color {
			get { return color; }
			set { color = value; Container.Redraw (); }
		}

		/// <summary>
		///    The current cursor position.
		/// </summary>
		public int CursorPosition { get { return point; }}
		
		/// <summary>
		///   Sets the cursor position.
		/// </summary>
		public override void PositionCursor ()
		{
			Move (y, x+point-first);
		}
		
		public override void Redraw ()
		{
			Stdscr.Attr =  color;
			Move (y, x);
			
			for (int i = 0; i < w; i++){
				int p = first + i;

				if (p < text.Length){
					Stdscr.Add (Secret ? '*' : text [p]);
				} else
					Stdscr.Add (' ' );
			}
			PositionCursor ();
		}

		void Adjust ()
		{
			if (point < first)
				first = point;
			else if (first + point >= w)
				first = point - (w / 3);
			Redraw ();
			Stdscr.Refresh ();
		}

		void SetText (string new_text)
		{
			text = new_text;
			if (Changed != null)
				Changed (this, EventArgs.Empty);
		}
		
		public override bool ProcessKey (int key)
		{
			switch (key){
			case 127:
			case Keys.BACKSPACE:
				if (point == 0)
					return true;
				
				SetText (text.Substring (0, point - 1) + text.Substring (point));
				point--;
				Adjust ();
				break;

			case Keys.HOME:
			case 1: // Control-a, Home
				point = 0;
				Adjust ();
				break;

			case Keys.LEFT:
			case 2: // Control-b, back character
				if (point > 0){
					point--;
					Adjust ();
				}
				break;

			case 4: // Control-d, Delete
				if (point == text.Length)
					break;
				SetText (text.Substring (0, point) + text.Substring (point+1));
				Adjust ();
				break;
				
			case 5: // Control-e, End
				point = text.Length;
				Adjust ();
				break;

			case Keys.RIGHT:
			case 6: // Control-f, forward char
				if (point == text.Length)
					break;
				point++;
				Adjust ();
				break;

			case 11: // Control-k, kill-to-end
				kill = text.Substring (point);
				SetText (text.Substring (0, point));
				Adjust ();
				break;

			case 25: // Control-y, yank
				if (kill == null)
					return true;
				
				if (point == text.Length){
					SetText (text + kill);
					point = text.Length;
				} else {
					SetText (text.Substring (0, point) + kill + text.Substring (point));
					point += kill.Length;
				}
				Adjust ();
				break;

			case (int) 'b' + Curses.KeyAlt:
				int bw = WordBackward (point);
				if (bw != -1)
					point = bw;
				Adjust ();
				break;

			case (int) 'f' + Curses.KeyAlt:
				int fw = WordForward (point);
				if (fw != -1)
					point = fw;
				Adjust ();
				break;
			
			default:
				// Ignore other control characters.
				if (key < 32 || key > 255)
					return false;

				if (used){
					if (point == text.Length){
						SetText (text + (char) key);
					} else {
						SetText (text.Substring (0, point) + (char) key + text.Substring (point));
					}
					point++;
				} else {
					SetText ("" + (char) key);
					first = 0;
					point = 1;
				}
				used = true;
				Adjust ();
				return true;
			}
			used = true;
			return true;
		}

		int WordForward (int p)
		{
			if (p >= text.Length)
				return -1;

			int i = p;
			if (Char.IsPunctuation (text [p]) || Char.IsWhiteSpace (text[p])){
				for (; i < text.Length; i++){
					if (Char.IsLetterOrDigit (text [i]))
					    break;
				}
				for (; i < text.Length; i++){
					if (!Char.IsLetterOrDigit (text [i]))
					    break;
				}
			} else {
				for (; i < text.Length; i++){
					if (!Char.IsLetterOrDigit (text [i]))
					    break;
				}
			}
			if (i != p)
				return i;
			return -1;
		}

		int WordBackward (int p)
		{
			if (p == 0)
				return -1;

			int i = p-1;
			if (i == 0)
				return 0;
			
			if (Char.IsPunctuation (text [i]) || Char.IsSymbol (text [i]) || Char.IsWhiteSpace (text[i])){
				for (; i >= 0; i--){
					if (Char.IsLetterOrDigit (text [i]))
						break;
				}
				for (; i >= 0; i--){
					if (!Char.IsLetterOrDigit (text[i]))
						break;
				}
			} else {
				for (; i >= 0; i--){
					if (!Char.IsLetterOrDigit (text [i]))
						break;
				}
			}
			i++;
			
			if (i != p)
				return i;

			return -1;
		}
		
		
		public override void ProcessMouse (MouseEvent ev)
		{
			if ((ev.State & MouseState.BUTTON1_CLICKED) == 0)
				return;

			Container.SetFocus (this);

			// We could also set the cursor position.
			point = first + (ev.X - x);
			if (point > text.Length)
				point = text.Length;
			if (point < first)
				point = 0;
			
			Container.Redraw ();
			Container.PositionCursor ();
		}
	}

	/// <summary>
	///   Button widget
	/// </summary>
	/// <remarks>
	///   Provides a button that can be clicked, or pressed with
	///   the enter key and processes hotkeys (the first uppercase
	///   letter in the button becomes the hotkey).
	/// </remarks>
	public class Button : Widget {
		string text;
		string shown_text;
		char hot_key;
		int  hot_pos = -1;
		bool is_default;
		
		/// <summary>
		///   Clicked event, raised when the button is clicked.
		/// </summary>
		/// <remarks>
		///   Client code can hook up to this event, it is
		///   raised when the button is activated either with
		///   the mouse or the keyboard.
		/// </remarks>
		public event EventHandler Clicked;

		/// <summary>
		///   Public constructor, creates a button based on
		///   the given text at position 0,0
		/// </summary>
		/// <remarks>
		///   The size of the button is computed based on the
		///   text length.   This button is not a default button.
		/// </remarks>
		public Button (string s) : this (0, 0, s) {}
		
		/// <summary>
		///   Public constructor, creates a button based on
		///   the given text.
		/// </summary>
		/// <remarks>
		///   If the value for is_default is true, a special
		///   decoration is used, and the enter key on a
		///   dialog would implicitly activate this button.
		/// </remarks>
		public Button (string s, bool is_default) : this (0, 0, s, is_default) {}
		
		/// <summary>
		///   Public constructor, creates a button based on
		///   the given text at the given position.
		/// </summary>
		/// <remarks>
		///   The size of the button is computed based on the
		///   text length.   This button is not a default button.
		/// </remarks>
		public Button (int x, int y, string s) : this (x, y, s, false) {}
		
		/// <summary>
		///   The text displayed by this widget.
		/// </summary>
		public string Text {
			get {
				return text;
			}

			set {
				text = value;
				if (is_default)
					shown_text = "[< " + value + " >]";
				else
					shown_text = "[ " + value + " ]";

				hot_pos = -1;
				hot_key = (char) 0;
				int i = 0;
				foreach (char c in shown_text){
					if (Char.IsUpper (c)){
						hot_key = c;
						hot_pos = i;
						break;
					}
					i++;
				}
			}
		}

		/// <summary>
		///   Public constructor, creates a button based on
		///   the given text at the given position.
		/// </summary>
		/// <remarks>
		///   If the value for is_default is true, a special
		///   decoration is used, and the enter key on a
		///   dialog would implicitly activate this button.
		/// </remarks>
		public Button (int x, int y, string s, bool is_default)
			: base (x, y, s.Length + 4 + (is_default ? 2 : 0), 1)
		{
			CanFocus = true;

			this.is_default = is_default;
			Text = s;
		}

		public override void Redraw ()
		{
			Stdscr.Attr =  (HasFocus ? ColorFocus : ColorNormal);
			Move (y, x);
			Stdscr.Add (shown_text);

			if (hot_pos != -1){
				Move (y, x + hot_pos);
				Stdscr.Attr =  (HasFocus ? ColorHotFocus : ColorHotNormal);
				Stdscr.Add (hot_key);
			}
		}

		public override void PositionCursor ()
		{
			Move (y, x + hot_pos);
		}

		bool CheckKey (int key)
		{
			if (Char.ToUpper ((char)key) == hot_key){
				Container.SetFocus (this);
				if (Clicked != null)
					Clicked (this, EventArgs.Empty);
				return true;
			}
			return false;
		}
			
		public override bool ProcessHotKey (int key)
		{
			int k = Curses.IsAlt (key);
			if (k != 0)
				return CheckKey (k);

			return false;
		}

		public override bool ProcessColdKey (int key)
		{
			if (is_default && key == '\n'){
				if (Clicked != null)
					Clicked (this, EventArgs.Empty);
				return true;
			}
			return CheckKey (key);
		}

		public override bool ProcessKey (int c)
		{
			if (c == '\n' || c == ' ' || Char.ToUpper ((char)c) == hot_key){
				if (Clicked != null)
					Clicked (this, EventArgs.Empty);
				return true;
			}
			return false;
		}

		public override void ProcessMouse (MouseEvent ev)
		{
			if ((ev.State & MouseState.BUTTON1_CLICKED) != 0){
				Container.SetFocus (this);
				Container.Redraw ();
				if (Clicked != null)
					Clicked (this, EventArgs.Empty);
			}
		}
	}

	public class CheckBox : Widget {
		string text;
		int hot_pos = -1;
		char hot_key;
		
		/// <summary>
		///   Toggled event, raised when the CheckButton is toggled.
		/// </summary>
		/// <remarks>
		///   Client code can hook up to this event, it is
		///   raised when the checkbutton is activated either with
		///   the mouse or the keyboard.
		/// </remarks>
		public event EventHandler Toggled;

		/// <summary>
		///   Public constructor, creates a CheckButton based on
		///   the given text at the given position.
		/// </summary>
		/// <remarks>
		///   The size of CheckButton is computed based on the
		///   text length. This CheckButton is not toggled.
		/// </remarks>
		public CheckBox (int x, int y, string s) : this (x, y, s, false)
		{
		}

		/// <summary>
		///   Public constructor, creates a CheckButton based on
		///   the given text at the given position and a state.
		/// </summary>
		/// <remarks>
		///   The size of CheckButton is computed based on the
		///   text length. 
		/// </remarks>
		public CheckBox (int x, int y, string s, bool is_checked) : base (x, y, s.Length + 4, 1)
		{
			Checked = is_checked;
			Text = s;

			CanFocus = true;
		}

		/// <summary>
		///    The state of the checkbox.
		/// </summary>
		public bool Checked { get; set; }

		/// <summary>
		///   The text displayed by this widget.
		/// </summary>
		public string Text {
			get {
				return text;
			}

			set {
				text = value;

				int i = 0;
				hot_pos = -1;
				hot_key = (char) 0;
				foreach (char c in text){
					if (Char.IsUpper (c)){
						hot_key = c;
						hot_pos = i;
						break;
					}
					i++;
				}
			}
		}
		
		public override void Redraw ()
		{
			Stdscr.Attr =  (ColorNormal);
			Move (y, x);
			Stdscr.Add (Checked ? "[X] " : "[ ] ");
			Stdscr.Attr =  (HasFocus ? ColorFocus : ColorNormal);
			Move (y, x + 3);
			Stdscr.Add (Text);
			if (hot_pos != -1){
				Move (y, x + 3 + hot_pos);
				Stdscr.Attr =  (HasFocus ? ColorHotFocus : ColorHotNormal);
				Stdscr.Add (hot_key);
			}
			PositionCursor();
		}

		public override void PositionCursor ()
		{
			Move (y, x + 1);
		}

		public override bool ProcessKey (int c)
		{
			if (c == ' '){
				Checked = !Checked;

				if (Toggled != null)
					Toggled (this, EventArgs.Empty);

				Redraw();
				return true;
			}
			return false;
		}

		public override void ProcessMouse (MouseEvent ev)
		{
			if ((ev.State & MouseState.BUTTON1_CLICKED) != 0){
				Container.SetFocus (this);
				Container.Redraw ();

				Checked = !Checked;
				
				if (Toggled != null)
					Toggled (this, EventArgs.Empty);
				Redraw ();
			}
		}
	}
	
	/// <summary>
	///   Model for the <see cref="ListView"/> widget.
	/// </summary>
	/// <remarks>
	///   Consumers of the <see cref="ListView"/> widget should
	///   implement this interface
	/// </remarks>
	public interface IListProvider {
		/// <summary>
		///   Number of items in the model.
		/// </summary>
		/// <remarks>
		///   This should return the number of items in the
		///   model. 
		/// </remarks>
		int Items { get; }

		/// <summary>
		///   Whether the ListView should allow items to be
		///   marked. 
		/// </summary>
		bool AllowMark { get; }

		/// <summary>
		///   Whether the given item is marked.
		/// </summary>
		bool IsMarked (int item);

		/// <summary>
		///   This should render the item at the given line,
		///   col with the specified width.
		/// </summary>
		void Render (int line, int col, int width, int item);

		/// <summary>
		///   Callback: this is the way that the model is
		///   hooked up to its actual view. 
		/// </summary>
		void SetListView (ListView target);

		/// <summary>
		///   Allows the model to process the given keystroke.
		/// </summary>
		/// <remarks>
		///   The model should return true if the key was
		///   processed, false otherwise.
		/// </remarks>
		bool ProcessKey (int ch);

		/// <summary>
		///   Callback: invoked when the selected item has changed.
		/// </summary>
		void SelectedChanged ();
	}
	
	/// <summary>
	///   A Listview widget.
	/// </summary>
	/// <remarks>
	///   This widget renders a list of data.   The actual
	///   rendering is implemented by an instance of the class
	///   IListProvider that must be supplied at construction time.
	/// </remarks>
	public class ListView : Widget {
		int items;
		int top;
		int selected;
		bool allow_mark;
		IListProvider provider;
		
		/// <summary>
		///   Public constructor.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public ListView (int x, int y, int w, int h, IListProvider provider) : base (x, y, w, h)
		{
			CanFocus = true;

			this.provider = provider;
			provider.SetListView (this);
			items = provider.Items;
			allow_mark = provider.AllowMark;
		}
		
		/// <summary>
		///   This method can be invoked by the model to
		///   notify the view that the contents of the model
		///   have changed.
		/// </summary>
		/// <remarks>
		///   Invoke this method to invalidate the contents of
		///   the ListView and force the ListView to repaint
		///   the contents displayed.
		/// </remarks>
		public void ProviderChanged ()
		{
			if (provider.Items != items){
				items = provider.Items;
				if (top > items){
					if (items > 1)
						top = items-1;
					else
						top = 0;
				}
				if (selected > items){
					if (items > 1)
						selected = items - 1;
					else
						selected = 0;
				}
			}
			Redraw ();
		}

		void SelectedChanged ()
		{
			provider.SelectedChanged ();
		}
		
		public override bool ProcessKey (int c)
		{
			int n;

			switch (c){
			case 16: // Control-p
			case Keys.UP:
				if (selected > 0){
					selected--;
					if (selected < top)
						top = selected;
					SelectedChanged ();
					Redraw ();
					return true;
				} else
					return false;

			case 14: // Control-n
			case Keys.DOWN:
				if (selected+1 < items){
					selected++;
					if (selected >= top + h){
						top++;
					}
					SelectedChanged ();
					Redraw ();
					return true;
				} else 
					return false;

			case 22: //  Control-v
			case Keys.NPAGE:
				n = (selected + h);
				if (n > items)
					n = items-1;
				if (n != selected){
					selected = n;
					if (items >= h)
						top = selected;
					else
						top = 0;
					SelectedChanged ();
					Redraw ();
				}
				return true;
				
			case Keys.PPAGE:
				n = (selected - h);
				if (n < 0)
					n = 0;
				if (n != selected){
					selected = n;
					top = selected;
					SelectedChanged ();
					Redraw ();
				}
				return true;

			default:
				return provider.ProcessKey (c);
			}
		}

		public override void PositionCursor ()
		{
			Move (y + (selected-top), x);
		}

		public override void Redraw ()
		{
			for (int l = 0; l < h; l++){
				Move (y + l, x);
				int item = l + top;

				if (item >= items){
					Stdscr.Attr =  (ColorNormal);
					for (int c = 0; c < w; c++)
						Stdscr.Add (' ');
					continue;
				}

				bool marked = allow_mark ? provider.IsMarked (item) : false;

				if (item == selected){
					if (marked)
						Stdscr.Attr =  (ColorHotNormal);
					else
						Stdscr.Attr =  (ColorFocus);
				} else {
					if (marked)
						Stdscr.Attr =  (ColorHotFocus);
					else
						Stdscr.Attr =  (ColorNormal);
				}
				provider.Render (y + l, x, w, item);
			}
			PositionCursor ();
		}

		/// <summary>
		///   Returns the index of the currently selected item.
		/// </summary>
		public int Selected {
			get {
				if (items == 0)
					return -1;
				return selected;
			}

			set {
				if (value >= items)
					throw new ArgumentException ("value");

				selected = value;
				Redraw ();
			}
		}
		
		public override void ProcessMouse (MouseEvent ev)
		{
			if ((ev.State & MouseState.BUTTON1_CLICKED) == 0)
				return;

			ev.X -= x;
			ev.Y -= y;

			if (ev.Y < 0)
				return;
			if (ev.Y+top >= items)
				return;
			selected = ev.Y - top;
			SelectedChanged ();
			
			Redraw ();
		}
	}
	
	/// <summary>
	///   Container widget, can host other widgets.
	/// </summary>
	/// <remarks>
	///   This implements the foundation for other containers
	///   (like Dialogs and Frames) that can host other widgets
	///   inside their boundaries.   It provides focus handling
	///   and event routing.
	/// </remarks>
	public class Container : Widget, IEnumerable {
		List<Widget> widgets = new List<Widget> ();
		Widget focused = null;
		public bool Running;
	
		public uint ContainerColorNormal;
		public uint ContainerColorFocus;
		public uint ContainerColorHotNormal;
		public uint ContainerColorHotFocus;

		public int Border;
		
		static Container ()
		{
		}

		public IEnumerator GetEnumerator ()
		{
			return widgets.GetEnumerator ();
		}
		
		/// <summary>
		///   Public constructor.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public Container (int x, int y, int w, int h) : base (x, y, w, h)
		{
			ContainerColorNormal = Terminal.ColorNormal;
			ContainerColorFocus = Terminal.ColorFocus;
			ContainerColorHotNormal = Terminal.ColorHotNormal;
			ContainerColorHotFocus = Terminal.ColorHotFocus;
		}

		/// <summary>
		///   Called on top-level container before starting up.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public virtual void Prepare ()
		{
		}

		/// <summary>
		///   Used to redraw all the children in this container.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public void RedrawChildren ()
		{
			foreach (Widget w in widgets){
				// Poor man's clipping.
				if (w.x >= this.w - Border * 2)
					continue;
				if (w.y >= this.h - Border * 2)
					continue;
				
				w.Redraw ();
			}
		}
		
		public override void Redraw ()
		{
			RedrawChildren ();
		}
		
		public override void PositionCursor ()
		{
			if (focused != null)
				focused.PositionCursor ();
		}

		/// <summary>
		///   Focuses the specified widget in this container.
		/// </summary>
		/// <remarks>
		///   Focuses the specified widge, taking the focus
		///   away from any previously focused widgets.   This
		///   method only works if the widget specified
		///   supports being focused.
		/// </remarks>
		public void SetFocus (Widget w)
		{
			if (!w.CanFocus)
				return;
			if (focused == w)
				return;
			if (focused != null)
				focused.HasFocus = false;
			focused = w;
			focused.HasFocus = true;
			Container wc = w as Container;
			if (wc != null)
				wc.EnsureFocus ();
			focused.PositionCursor ();
		}

		/// <summary>
		///   Focuses the first possible focusable widget in
		///   the contained widgets.
		/// </summary>
		public void EnsureFocus ()
		{
			if (focused == null)
				FocusFirst();
		}
		
		/// <summary>
		///   Focuses the first widget in the contained widgets.
		/// </summary>
		public void FocusFirst ()
		{
			foreach (Widget w in widgets){
				if (w.CanFocus){
					SetFocus (w);
					return;
				}
			}
		}

		/// <summary>
		///   Focuses the last widget in the contained widgets.
		/// </summary>
		public void FocusLast ()
		{
			for (int i = widgets.Count; i > 0; ){
				i--;

				Widget w = (Widget) widgets [i];
				if (w.CanFocus){
					SetFocus (w);
					return;
				}
			}
		}

		/// <summary>
		///   Focuses the previous widget.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public bool FocusPrev ()
		{
			if (focused == null){
				FocusLast ();
				return true;
			}
			int focused_idx = -1;
			for (int i = widgets.Count; i > 0; ){
				i--;
				Widget w = (Widget)widgets [i];

				if (w.HasFocus){
					Container c = w as Container;
					if (c != null){
						if (c.FocusPrev ())
							return true;
					}
					focused_idx = i;
					continue;
				}
				if (w.CanFocus && focused_idx != -1){
					focused.HasFocus = false;

					Container c = w as Container;
					if (c != null && c.CanFocus){
						c.FocusLast ();
					} 
					SetFocus (w);
					return true;
				}
			}
			if (focused != null){
				focused.HasFocus = false;
				focused = null;
			}
			return false;
		}

		/// <summary>
		///   Focuses the next widget.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public bool FocusNext ()
		{
			if (focused == null){
				FocusFirst ();
				return focused != null;
			}
			int n = widgets.Count;
			int focused_idx = -1;
			for (int i = 0; i < n; i++){
				Widget w = (Widget)widgets [i];

				if (w.HasFocus){
					Container c = w as Container;
					if (c != null){
						if (c.FocusNext ())
							return true;
					}
					focused_idx = i;
					continue;
				}
				if (w.CanFocus && focused_idx != -1){
					focused.HasFocus = false;

					Container c = w as Container;
					if (c != null && c.CanFocus){
						c.FocusFirst ();
					} 
					SetFocus (w);
					return true;
				}
			}
			if (focused != null){
				focused.HasFocus = false;
				focused = null;
			}
			return false;
		}

		/// <summary>
		///   Returns the base position for child widgets to
		///   paint on.   
		/// </summary>
		/// <remarks>
		///   This method is typically overwritten by
		///   containers that want to have some padding (like
		///   Frames or Dialogs).
		/// </remarks>
		public virtual void GetBase (out int row, out int col)
		{
			row = 0;
			col = 0;
		}
		
		public virtual void ContainerMove (int row, int col)
		{
			if (Container != Terminal.EmptyContainer && Container != null)
				Container.ContainerMove (row + y, col + x);
			else
				Stdscr.Move (row + y, col + x);
		}
		
		public virtual void ContainerBaseMove (int row, int col)
		{
			if (Container != Terminal.EmptyContainer && Container != null)
				Container.ContainerBaseMove (row + y, col + x);
			else
				Stdscr.Move (row + y, col + x);
		}
		
		/// <summary>
		///   Adds a widget to this container.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public virtual void Add (Widget w)
		{
			widgets.Add (w);
			w.Container = this;
			if (w.CanFocus)
				this.CanFocus = true;
		}

		/// <summary>
		///   Removes all the widgets from this container.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public virtual void RemoveAll ()
		{
			foreach (Widget w in widgets)
				Remove (w);
		}

		/// <summary>
		///   Removes a widget from this container.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public virtual void Remove (Widget w)
		{
			if (w == null)
				return;
			
			widgets.Remove (w);
			w.Container = null;
			
			if (widgets.Count < 1)
				this.CanFocus = false;
		}

		public override bool ProcessKey (int key)
		{
			if (focused != null){
				if (focused.ProcessKey (key))
					return true;
			}
			return false;
		}

		public override bool ProcessHotKey (int key)
		{
			if (focused != null)
				if (focused.ProcessHotKey (key))
					return true;
			
			foreach (Widget w in widgets){
				if (w == focused)
					continue;
				
				if (w.ProcessHotKey (key))
					return true;
			}
			return false;
		}

		public override bool ProcessColdKey (int key)
		{
			if (focused != null)
				if (focused.ProcessColdKey (key))
					return true;
			
			foreach (Widget w in widgets){
				if (w == focused)
					continue;
				
				if (w.ProcessColdKey (key))
					return true;
			}
			return false;
		}

		public override void ProcessMouse (MouseEvent ev)
		{
			int bx, by;

			GetBase (out bx, out by);
			ev.X -= x;
			ev.Y -= y;
			
			foreach (Widget w in widgets){
				int wx = w.x + bx;
				int wy = w.y + by;

				if ((ev.X < wx) || (ev.X > (wx + w.w)))
					continue;

				if ((ev.Y < wy) || (ev.Y > (wy + w.h)))
					continue;
				
				ev.X -= bx;
				ev.Y -= by;

				w.ProcessMouse (ev);
				return;
			}			
		}
		
		public override void DoSizeChanged ()
		{
			foreach (Widget widget in widgets){
				widget.DoSizeChanged ();

				if ((widget.Fill & Fill.Horizontal) != 0){
					widget.w = w - (Border*2) - widget.x;
				}

				if ((widget.Fill & Fill.Vertical) != 0)
					widget.h = h - (Border * 2) - widget.y;
			}
		}

		/// <summary>
		///   Raised when the size of this container changes.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public event EventHandler SizeChangedEvent;
		
		/// <summary>
		///   This method is invoked when the size of this
		///   container changes. 
		/// </summary>
		/// <remarks>
		/// </remarks>
		public void SizeChanged ()
		{
			if (SizeChangedEvent != null)
				SizeChangedEvent (this, EventArgs.Empty);
			DoSizeChanged ();
		}
	}

	/// <summary>
	///   Framed-container widget.
	/// </summary>
	/// <remarks>
	///   A container that provides a frame around its children,
	///   and an optional title.
	/// </remarks>
	public class Frame : Container {
		public string Title;

		/// <summary>
		///   Creates an empty frame, with the given title
		/// </summary>
		/// <remarks>
		/// </remarks>
		public Frame (string title) : this (0, 0, 0, 0, title)
		{
		}
		
		/// <summary>
		///   Public constructor, a frame, with the given title.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public Frame (int x, int y, int w, int h, string title) : base (x, y, w, h)
		{
			Title = title;
			Border++;
		}

		public override void GetBase (out int row, out int col)
		{
			row = 1;
			col = 1;
		}
		
		public override void ContainerMove (int row, int col)
		{
			base.ContainerMove (row + 1, col + 1);
		}

		public override void Redraw ()
		{
			Stdscr.Attr =  (ContainerColorNormal);
			Clear ();
			
			Widget.DrawFrame (x, y, w, h);
			Stdscr.Attr =  (Container.ContainerColorNormal);
			Stdscr.Move (y, x + 1);
			if (HasFocus)
				Stdscr.Attr =  (Terminal.ColorDialogNormal);
			if (Title != null){
				Stdscr.Add (' ');
				Stdscr.Add (Title);
				Stdscr.Add (' ');
			}
			RedrawChildren ();
		}

		public override void Add (Widget w)
		{
			base.Add (w);
		}
	}

	/// <summary>
	///   A Dialog is a container that can also have a number of
	///   buttons at the bottom
	/// </summary>
	/// <remarks>
	///   <para>Dialogs are containers that can have a set of buttons at
	///   the bottom.   Dialogs are automatically centered on the
	///   screen, and on screen changes the buttons are
	///   relaid out.</para>
	/// <para>
	///   To make the dialog box run until an option has been
	///   executed, you would typically create the dialog box and
	///   then call Application.Run on the Dialog instance.
	/// </para>
	/// </remarks>
	public class Dialog : Frame {
		int button_len;
		List<Button> buttons;

		const int button_space = 3;
		
		/// <summary>
		///   Public constructor.
		/// </summary>
		/// <remarks>
		/// </remarks>
		public Dialog (int w, int h, string title)
			: base ((Terminal.Cols - w) / 2, (Terminal.Lines-h)/3, w, h, title)
		{
			ContainerColorNormal = Terminal.ColorDialogNormal;
			ContainerColorFocus = Terminal.ColorDialogFocus;
			ContainerColorHotNormal = Terminal.ColorDialogHotNormal;
			ContainerColorHotFocus = Terminal.ColorDialogHotFocus;

			Border++;
		}

		/// <summary>
		///   Makes the default style for the dialog use the error colors.
		/// </summary>
		public void ErrorColors ()
		{
			ContainerColorNormal = Terminal.ColorError;
			ContainerColorFocus = Terminal.ColorErrorFocus;
			ContainerColorHotFocus = Terminal.ColorErrorHotFocus;
			ContainerColorHotNormal = Terminal.ColorErrorHot;
		}
		
		public override void Prepare ()
		{
			LayoutButtons ();
		}

		void LayoutButtons ()
		{
			if (buttons == null)
				return;
			
			int p = (w - button_len) / 2;
			
			foreach (Button b in buttons){
				b.x = p;
				b.y = h - 5;

				p += b.w + button_space;
			}
		}

		/// <summary>
		///   Adds a button to the dialog
		/// </summary>
		/// <remarks>
		/// </remarks>
		public void AddButton (Button b)
		{
			if (buttons == null)
				buttons = new List<Button> ();
			
			buttons.Add (b);
			button_len += b.w + button_space;

			Add (b);
		}
		
		public override void GetBase (out int row, out int col)
		{
			base.GetBase (out row, out col);
			row++;
			col++;
		}
		
		public override void ContainerMove (int row, int col)
		{
			base.ContainerMove (row + 1, col + 1);
		}

		public override void Redraw ()
		{
			Stdscr.Attr =  (ContainerColorNormal);
			Clear ();

			Widget.DrawFrame (x + 1, y + 1, w - 2, h - 2);
			Stdscr.Move (y + 1, x + (w - Title.Length) / 2);
			Stdscr.Add (' ');
			Stdscr.Attr =  (Terminal.ColorDialogHotNormal);
			Stdscr.Add (Title);
			Stdscr.Add (' ');
			RedrawChildren ();
		}

		public override bool ProcessKey (int key)
		{
			if (key == 27){
				Running = false;
				return true;
			}

			return base.ProcessKey (key);
		}

		public override void DoSizeChanged ()
		{
			base.DoSizeChanged ();
			
			x = (Terminal.Cols - w) / 2;
			y = (Terminal.Lines-h) / 3;

			LayoutButtons ();
		}
	}

	public class MenuItem {
		public MenuItem (string title, string help, Action action)
		{
			Title = title ?? "";
			Help = help ?? "";
			Action = action;
			Width = Title.Length + Help.Length + 1;
		}
		public string Title { get; set; }
		public string Help { get; set; }
		public Action Action { get; set; }
		public int Width { get; set; }
	}
	
	public class MenuBarItem {
		public MenuBarItem (string title, MenuItem [] children) 
		{
			Title = title ?? "";
			Children = children;
		}

		public string Title { get; set; }
		public MenuItem [] Children { get; set; }
		public int Current { get; set; }
	}
	
	public class MenuBar : Container {
		public MenuBarItem [] Menus { get; set; }
		int selected;
		Action action;
		
		public MenuBar (MenuBarItem [] menus) : base (0, 0, Terminal.Cols, 1)
		{
			Menus = menus;
			CanFocus = false;
			selected = -1;
		}

		/// <summary>
		///   Activates the menubar
		/// </summary>
		public void Activate (int idx)
		{
			if (idx < 0 || idx > Menus.Length)
				throw new ArgumentException ("idx");

			action = null;
			selected = idx;

			foreach (var m in Menus)
				m.Current = 0;
			
			Terminal.Run (this);
			selected = -1;
			Container.Redraw ();
			
			if (action != null)
				action ();
		}

		void DrawMenu (int idx, int col, int line)
		{
			int max = 0;
			var menu = Menus [idx];

			if (menu.Children == null)
				return;

			foreach (var m in menu.Children){
				if (m == null)
					continue;
				
				if (m.Width > max)
					max = m.Width;
			}
			max += 4;
			DrawFrame (col + x, line, max, menu.Children.Length + 2, true);
			for (int i = 0; i < menu.Children.Length; i++){
				var item = menu.Children [i];

				Move (line + 1 + i, col + 1);
				Stdscr.Attr =  (item == null ? Terminal.ColorFocus : i == menu.Current ? Terminal.ColorMenuSelected : Terminal.ColorMenu);
				for (int p = 0; p < max - 2; p++)
					Stdscr.Add (item == null ? Acs.HLINE : ' ');

				if (item == null)
					continue;
				
				Move (line + 1 + i, col + 2);
				DrawHotString (item.Title,
					       i == menu.Current ? Terminal.ColorMenuHotSelected : Terminal.ColorMenuHot,
					       i == menu.Current ? Terminal.ColorMenuSelected : Terminal.ColorMenu);

				// The help string
				var l = item.Help.Length;
				Move (line + 1 + i, col + x + max - l - 2);
				Stdscr.Add (item.Help);
			}
		}
		
		public override void Redraw ()
		{
			Move (y, 0);
			Stdscr.Attr =  (Terminal.ColorFocus);
			for (int i = 0; i < Terminal.Cols; i++)
				Stdscr.Add (' ');

			Move (y, 1);
			int pos = 0;
			for (int i = 0; i < Menus.Length; i++){
				var menu = Menus [i];
				if (i == selected){
					DrawMenu (i, pos, y+1);
					Stdscr.Attr =  (Terminal.ColorMenuSelected);
				} else
					Stdscr.Attr =  (Terminal.ColorFocus);

				Move (y, pos);
				Stdscr.Add (' ');
				Stdscr.Add (menu.Title);
				Stdscr.Add (' ');
				if (HasFocus && i == selected)
					Stdscr.Attr =  (Terminal.ColorMenuSelected);
				else
					Stdscr.Attr =  (Terminal.ColorFocus);
				Stdscr.Add ("  ");
				
				pos += menu.Title.Length + 4;
			}
			PositionCursor ();
		}

		public override void PositionCursor ()
		{
			int pos = 0;
			for (int i = 0; i < Menus.Length; i++){
				if (i == selected){
					pos++;
					Move (y, pos);
					return;
				} else {
					pos += Menus [i].Title.Length + 4;
				}
			}
			Move (y, 0);
		}

		void Selected (MenuItem item)
		{
			Running = false;
			action = item.Action;
		}
		
		public override bool ProcessKey (int key)
		{
			switch (key){
			case Keys.UP:
				if (Menus [selected].Children == null)
					return false;

				int current = Menus [selected].Current;
				do {
					current--;
					if (current < 0)
						current = Menus [selected].Children.Length-1;
				} while (Menus [selected].Children [current] == null);
				Menus [selected].Current = current;
				
				Redraw ();
				Stdscr.Refresh ();
				return true;
				
			case Keys.DOWN:
				if (Menus [selected].Children == null)
					return false;

				do {
					Menus [selected].Current = (Menus [selected].Current+1) % Menus [selected].Children.Length;
				} while (Menus [selected].Children [Menus [selected].Current] == null);
				
				Redraw ();
				Stdscr.Refresh ();
				break;
				
			case Keys.LEFT:
				selected--;
				if (selected < 0)
					selected = Menus.Length-1;
				break;
			case Keys.RIGHT:
				selected = (selected + 1) % Menus.Length;
				break;

			case '\n':
				if (Menus [selected].Children == null)
					return false;

				Selected (Menus [selected].Children [Menus [selected].Current]);
				break;

			case 27:
			case 3:
				Running = false;
				break;

			default:
				if ((key >= 'a' && key <= 'z') || (key >= 'A' && key <= 'Z') || (key >= '0' && key <= '9')){
					char c = Char.ToUpper ((char)key);

					if (Menus [selected].Children == null)
						return false;
					
					foreach (var mi in Menus [selected].Children){
						int p = mi.Title.IndexOf ('_');
						if (p != -1 && p+1 < mi.Title.Length){
							if (mi.Title [p+1] == c){
								Selected (mi);
								return true;
							}
						}
					}
				}
				    
				return false;
			}
			Container.Redraw ();
			Stdscr.Refresh ();
			return true;
		}
	}
}
