//
// util.cs: Utility functions and classes
//
// Authors:
//   Miguel de Icaza (miguel@gnome.org)
//
// Licensed under the MIT X11 license
//
using System;
using CursesSharp.Gui;

namespace MouselessCommander
{

	public class BasicInteraction : Dialog, IUserInteraction
	{
		
		public BasicInteraction (string title) : base (68, 12, title)
		{
		}

		public void Error (string msg)
		{
			ErrorDialog.Error (msg);
		}

		public OResult Query (OResult flags, string errormsg, string condition, string file)
		{
			var s = String.Format (condition, file);
			int len = Math.Min (s.Length, Terminal.Cols - 8);

			var d = new Dialog (len, 8, "Error");
			d.ErrorColors ();
			d.Add (new Label (1, 1, errormsg));
			d.Add (new Label (1, 2, String.Format (condition, file.Ellipsize (len - condition.Length))));

			OResult result = OResult.Ignore;
			Button b;
			if ((flags & OResult.Retry) == OResult.Retry) {
				b = new Button (0, 0, "Retry", true);
				b.Clicked += delegate {
					result = OResult.Retry;
					d.Running = false;
				};
				d.Add (b);
			}
			if ((flags & OResult.Ignore) == OResult.Ignore) {
				b = new Button (0, 0, "Ignore", true);
				b.Clicked += delegate {
					result = OResult.Ignore;
					d.Running = false;
				};
				d.Add (b);
			}
			if ((flags & OResult.Cancel) == OResult.Cancel) {
				b = new Button (0, 0, "Cancel", true);
				b.Clicked += delegate {
					result = OResult.Cancel;
					d.Running = false;
				};
				d.Add (b);
			}
			Terminal.Run (d);
			return result;
		}

		void MakeButton (Dialog d, int x, int y, string text, System.Action action)
		{
			Button b = new Button (x, y, text);
			b.Clicked += delegate {
				action ();
				d.Running = false;
			};
			d.Add (b);
		}

		public TargetExistsAction TargetExists (string file, DateTime sourceTime, long sourceSize, DateTime targetTime, long targetSize, bool multiple)
		{
			const int padding = 14;
			const int minEllipse = 22;
			const string fmt = "Target file \"{0}\" already exists";
			TargetExistsAction result = TargetExistsAction.Cancel;
			
			var msg = String.Format (fmt, file);
			if (msg.Length > Terminal.Cols - padding)
				msg = String.Format (fmt, file.Ellipsize (Terminal.Cols - 8 - fmt.Length));
			
			var d = new Dialog (msg.Length + padding, 13 + (multiple ? 3 : 0), "File exists");
			d.ErrorColors ();
			d.Add (new Label (2, 1, msg));
			// TODO: compute what changes actually matter (year, month, day, hour, minute)
			d.Add (new Label (2, 3, String.Format ("Source date: {0}, size {1}", sourceTime, sourceSize)));
			d.Add (new Label (2, 4, String.Format ("Target date: {0}, size {1}", targetTime, targetSize)));
			d.Add (new Label (2, 6, "Override this target?"));
			MakeButton (d, 24, 6, "Yes", () => result = TargetExistsAction.Overwrite);
			MakeButton (d, 32, 6, "No", () => result = TargetExistsAction.Skip);
			MakeButton (d, 39, 6, "Append", () => result = TargetExistsAction.Append);
			if (multiple) {
				d.Add (new Label (2, 8, "Override all targets?"));
				MakeButton (d, 24, 8, "aLl", () => result = TargetExistsAction.AlwaysOverwrite);
				MakeButton (d, 32, 8, "Update", () => result = TargetExistsAction.AlwaysUpdate);
				MakeButton (d, 43, 8, "None", () => result = TargetExistsAction.AlwaysSkip);
				MakeButton (d, 24, 9, "if Size differs", () => result = TargetExistsAction.AlwaysUpdateOnSizeMismatch);
			}
			MakeButton (d, (d.w - 4 - "Cancel".Length) / 2, 8 + (multiple ? 3 : 0), "Cancel", () => {
			});
			Terminal.Run (d);
			return result;
		}
	}

	public class ProgressInteraction : BasicInteraction, IProgressInteraction
	{
		Label filePct, bytesPct, countPct;

		public ProgressInteraction (string title, int fileCount, double? byteCount) : base (title)
		{
			Count = fileCount;
			ByteCount = byteCount;

			Add (new Label (3, 2, "File"));
			Add ((filePct = new Label (30, 2, "")));

			if (Count > 1) {
				Add (new Label (3, 3, "Count"));
				Add ((countPct = new Label (30, 3, "")));
			}

			if (byteCount.HasValue) {
				Add (new Label (3, 4, "Bytes"));
				Add ((bytesPct = new Label (30, 4, "")));
			}

			AddButton (new Button (10, 7, "Cancel"));
		}

		public int Count { get; private set; }

		public double? ByteCount { get; private set; }

		int calls;

		public void UpdateStatus (CopyOperation copyOperation)
		{
			int processedFiles;
			double processedBytes;
			long fileSize, fileProgress;
			
			lock (copyOperation) {
				processedFiles = copyOperation.ProcessedFiles;
				processedBytes = copyOperation.ProcessedBytes;
				fileSize = copyOperation.CurrentFileSize;
				fileProgress = copyOperation.CurrentFileProgress;
			}

			var progress = fileSize > 0 ? (fileProgress / (double)fileSize) : 0.0;
			filePct.Text = String.Format ("Called: {0}", calls++); //pct (progress);
			
			if (Count != 1) {
				progress = processedFiles / (double)Count;
				countPct.Text = pct (progress);
			}
			if (ByteCount.HasValue) {
				progress = processedBytes / ByteCount.Value;
				bytesPct.Text = pct (progress);
			}
			Terminal.Refresh ();
		}

		static string pct (double ratio)
		{
			return String.Format ("{0:g2}", ratio * 100);
		}
	}

	public static class StringExtensions
	{
		public static string Ellipsize (this string source, int width)
		{
			if (source.Length <= width)
				return source;
			return source.Substring (0, width / 2) + "~" + source.Substring (source.Length - 1 - width / 2);
		}
	}
}