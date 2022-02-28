using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSystemLib.LogWriting
{
	public interface ILogEntry
	{
		public enum LogSeverity
		{
			Info, Warning, Error, Fatal
		}
		string Name { get; set; }
		public LogSeverity Severity { get; set; }
		string? Message { get; set; }
		DateTime? Date { get; set; }
		int? CallerThreadId { get; set; }
		string? CallerThreadName { get; set; }
		Exception? Exception { get; set; }
	}
	public class LogEntry : ILogEntry
	{
		public string Name { get; set; }
		public ILogEntry.LogSeverity Severity { get; set; }
		public string? Message { get; set; }
		public DateTime? Date { get; set; }
		public int? CallerThreadId { get; set; }
		public string? CallerThreadName { get; set; }
		public Exception? Exception { get; set; }
		public LogEntry(string message = "Unspecified message", ILogEntry.LogSeverity severity = ILogEntry.LogSeverity.Info, string logName = "Unnamed log entry", Exception? exception = null)
		{
			Name = logName;
			Severity= severity;
			Message = message;
			Date = DateTime.Now;
			CallerThreadId = Thread.CurrentThread.ManagedThreadId;
			CallerThreadName = Thread.CurrentThread.Name;
			Exception = exception;
		}
		public override string ToString()
		{
			return $"{Name}:{(int)Severity}:{Message}:{Date}:{CallerThreadId}:{CallerThreadName}";
		}
	}
}
