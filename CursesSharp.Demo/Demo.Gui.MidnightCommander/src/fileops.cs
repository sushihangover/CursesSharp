//
// fileops.cs: file operations
//
// Author:
//   Miguel de Icaza (miguel@gnome.org)
//
// Licensed under the MIT X11 license
//
// This file does not contain any UI code, it depends on the interfaces
// for it, that way we can later implement the background operations
// and notifications, or use without MouselessCommander.
//
using System;
using System.IO;
using System.Collections.Generic;
using Mono.Unix;
using Mono.Unix.Native;
using System.Runtime.InteropServices;

namespace MouselessCommander
{
	[Flags]
	public enum OResult
	{
		// In/out values
		Retry = 1,
		Ignore = 2,
		Cancel = 4,
		Skip = 16,

		// in values
		RetryCancel = 5,
		RetryIgnoreCancel = 7,
		RetrySkipCancel = 21
	}

	[Flags]
	public enum TargetExistsAction
	{
		Cancel,
			
		// Actions apply only to this file
		Overwrite,
		Skip,
		Append,

		// Actions apply to this file and any remaining ones
		AlwaysOverwrite,
		AlwaysUpdate,
		AlwaysUpdateOnSizeMismatch,
		AlwaysSkip
	}

	public interface IUserInteraction
	{
		OResult Query (OResult flags, string errormsg, string condition, string file);

		TargetExistsAction TargetExists (string file, DateTime sourceDate, long sourceSize, DateTime targetDate, long targetSize, bool multiple);

		void Error (string msg);
	}

	public interface IProgressInteraction : IUserInteraction
	{
		int Count { get; }
	}

	public class FileOperation : IDisposable
	{
		public enum Result
		{
			Ok,
			Skip,
			Cancel
		}

		protected IProgressInteraction Interaction;
		protected IntPtr io_buffer;
		protected const int COPY_BUFFER_SIZE = 64 * 1024;

		public FileOperation (IProgressInteraction interaction)
		{
			Interaction = interaction;
		}

		public void Dispose ()
		{
			Dispose (true);
			GC.SuppressFinalize (true);
							  
		}

		protected virtual void Dispose (bool disposing)
		{
			if (disposing) {
				// release managed
			}
			
			if (io_buffer != IntPtr.Zero) {
				Marshal.FreeHGlobal (io_buffer);
				io_buffer = IntPtr.Zero;
			}
		}

		protected void AllocateBuffer ()
		{
			if (io_buffer == IntPtr.Zero)
				io_buffer = Marshal.AllocHGlobal (COPY_BUFFER_SIZE);
		}
	}

	public class CopyOperation : FileOperation
	{
		// These require locking
		public int ProcessedFiles;
		public double ProcessedBytes;
		public long CurrentFileSize;
		public long CurrentFileProgress;
		
		TargetExistsAction target_exists_action;
		bool skip;
		Dictionary<string,FilePermissions> dirs_created;

		public CopyOperation (IProgressInteraction interaction) : base (interaction)
		{
			dirs_created = new Dictionary<string,FilePermissions> ();
		}

		Result CopyDirectory (string source_absolute_path, string target_path, FilePermissions protection)
		{
			if (!dirs_created.ContainsKey (target_path)) {
				while (true) {
					int r = Syscall.mkdir (target_path, protection | FilePermissions.S_IRWXU);
					if (r != -1)
						break;
					
					Errno errno = Stdlib.GetLastError ();
					if (errno == Errno.EINTR)
						continue;
					
					if (errno == Errno.EEXIST || errno == Errno.EISDIR)
						break;
					
					var msg = UnixMarshal.GetErrorDescription (errno);
					switch (Interaction.Query (OResult.RetryIgnoreCancel, msg, "While creating \"{0}\"", target_path)) {
					case OResult.Retry:
						continue;
					case OResult.Ignore:
						break;
					case OResult.Cancel:
						return Result.Cancel;
					}
				}
				dirs_created [target_path] = protection;
			}
			
			var udi = new UnixDirectoryInfo (source_absolute_path);
			foreach (var entry in udi.GetFileSystemEntries ()) {
				if (entry.Name == "." || entry.Name == "..")
					continue;

				string source = Path.Combine (source_absolute_path, entry.Name);
				string target = Path.Combine (target_path, entry.Name);
				if (entry.IsDirectory) {
					if (CopyDirectory (source, target, entry.Protection) == Result.Cancel)
						return Result.Cancel;
				} else {
					if (!CopyFile (source, target)) {
						return skip ? Result.Skip : Result.Cancel;
					}
				}
			}
			return Result.Ok;
		}

		bool ShouldRetryOperation (string text, string file)
		{
			Errno errno = Stdlib.GetLastError ();
			if (errno == Errno.EINTR)
				return true;
			return ShouldRetryOperation (UnixMarshal.GetErrorDescription (errno), text, file);
		}

		bool ShouldRetryOperation (string msg, string text, string file)
		{
			var ret = Interaction.Query (OResult.RetrySkipCancel, msg, text, file);
			if (ret == OResult.Retry)
				return true;
			if (ret == OResult.Skip)
				skip = true;
			return false;
		}

		bool CopyFile (string source_absolute_path, string target_path)
		{
			bool ret = false;
			bool target_exists = false;
			// Stat target
			Stat tstat;

			lock (this)
				ProcessedFiles++;

			while (Syscall.stat (target_path, out tstat) == 0) {
				if (tstat.st_mode.HasFlag (FilePermissions.S_IFDIR)) {
					if (ShouldRetryOperation ("Target file is a directory", "Source file \"{0}\"",
						    Path.GetFileName (source_absolute_path)))
						continue;
					return false;
				} else {
					target_exists = true;
				}
				break;
			}

			// Open Source
			int source_fd;
			while (true) {
				source_fd = Syscall.open (source_absolute_path, OpenFlags.O_RDONLY, (FilePermissions)0);
				if (source_fd != -1)
					break;

				if (ShouldRetryOperation ("While opening \"{0}\"", target_path))
					continue;
				return false;
			}
			Stat stat;
			while (true) {
				if (Syscall.fstat (source_fd, out stat) != -1)
					break;

				if (ShouldRetryOperation ("While probing for state of \"{0}\"", target_path))
					continue;
				goto close_source;
			}

			// Make sure we are not overwriting the same file
			if (stat.st_dev == tstat.st_dev && stat.st_ino == tstat.st_ino) {
				Interaction.Error ("Can not copy a file into itself");
				skip = true;
				goto close_source;
			}

			lock (this) {
				CurrentFileProgress = 0;
				CurrentFileSize = tstat.st_size;
			}
			
			if (target_exists) {
				if (target_exists_action < TargetExistsAction.AlwaysOverwrite) {
					target_exists_action = Interaction.TargetExists (
						target_path,
						NativeConvert.ToDateTime (stat.st_mtime), stat.st_size,
						NativeConvert.ToDateTime (tstat.st_mtime), tstat.st_size, Interaction.Count > 1);
				}
				
				if (target_exists_action == TargetExistsAction.Cancel)
					goto close_source;
				
				if (target_exists_action == TargetExistsAction.Skip)
					goto close_source;
			}
			
			// Open target
			int target_fd;
			
			switch (target_exists_action) {
			case TargetExistsAction.AlwaysUpdate:
				if (stat.st_mtime > tstat.st_mtime)
					goto case TargetExistsAction.Overwrite;
				skip = true;
				goto close_source;
				
			case TargetExistsAction.AlwaysUpdateOnSizeMismatch:
				if (stat.st_size != tstat.st_size)
					goto case TargetExistsAction.Overwrite;
				skip = true;
				goto close_source;


			// Real cancels are taken care of immediately after the dialog
			// this means: never used, target does not exist.
			case TargetExistsAction.Cancel:
			case TargetExistsAction.AlwaysOverwrite:
			case TargetExistsAction.Overwrite:
				target_fd = Syscall.open (target_path, OpenFlags.O_CREAT | OpenFlags.O_WRONLY, FilePermissions.S_IWUSR);
				break;
				
			case TargetExistsAction.Append:
				target_fd = Syscall.open (target_path, OpenFlags.O_APPEND, FilePermissions.S_IWUSR);
				break;
			default:
				throw new Exception (String.Format ("Internal error: unhandled TargetExistsAction value {0}", target_exists_action));
			}
			
			while (true) {

				if (target_fd != -1)
					break;
				if (ShouldRetryOperation ("While creating \"{0}\"", target_path))
					continue;
				goto close_source;
			}

			AllocateBuffer ();
			long n;

			do {
				while (true) {
					n = Syscall.read (source_fd, io_buffer, COPY_BUFFER_SIZE);
					
					if (n != -1)
						break;

					if (ShouldRetryOperation ("While reading \"{0}\"", Path.GetFileName (source_absolute_path)))
						continue;
					goto close_both;
				}
				while (true) {
					long count = Syscall.write (target_fd, io_buffer, (ulong)n);
					if (count != -1)
						break;
					
					if (ShouldRetryOperation ("While writing \"{0}\"", target_path))
						continue;
					goto close_both;
				}
				lock (this) {
					ProcessedBytes += n;
					CurrentFileSize += n;
				}
			} while (n != 0);

			// File mode
			while (true) {
				n = Syscall.fchmod (target_fd, stat.st_mode);
				if (n == 0)
					break;

				if (ShouldRetryOperation ("Setting permissions on \"{0}\"", target_path))
					continue;

				goto close_both;
			}

			// The following are not considered errors if we can not set them
			ret = true;
			
			// preserve owner and group if running as root
			if (Syscall.geteuid () == 0)
				Syscall.fchown (target_fd, stat.st_uid, stat.st_gid);
			
			// Set file time
			Timeval[] dates = new Timeval [2] {
				new Timeval () { tv_sec = stat.st_atime },
				new Timeval () { tv_sec = stat.st_mtime }
			};
			Syscall.futimes (target_fd, dates);
			
			close_both:
			Syscall.close (target_fd);
			close_source:
			Syscall.close (source_fd);
			return ret;
		}

		public Result Perform (string cwd, string source_path, bool is_dir, FilePermissions protection, string target)
		{
			string source_absolute_path = Path.Combine (cwd, source_path);
			string target_path = Path.Combine (target, source_path);

			if (is_dir)
				return CopyDirectory (source_absolute_path, target_path, protection);
			else if (!CopyFile (source_absolute_path, target_path))
				return skip ? Result.Skip : Result.Cancel;

			return Result.Ok;
		}

		
	}
}