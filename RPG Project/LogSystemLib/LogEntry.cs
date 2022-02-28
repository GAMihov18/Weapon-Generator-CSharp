using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogSystemLib.LogWriting
{
	public interface ILogEntry
	{
		string Name { get; set; }
		string? Message { get; set; }
		DateTime? Date { get; set; }
		int? CallerThreadId { get; set; }
		string? CallerThreadName { get; set; }
		Exception? Exception { get; set; }
	}
	public class LogEntry : ILogEntry
	{
		public string Name { get; set; }
		public string? Message { get; set; }
		public DateTime? Date { get; set; }
		public int? CallerThreadId { get; set; }
		public string? CallerThreadName { get; set; }
		public Exception? Exception { get; set; }

		public LogEntry(Exception exception)
		{
			Name = "Exception-generated log entry";
			Message = exception.Message;
			Date = DateTime.Now;
			CallerThreadId = Thread.CurrentThread.ManagedThreadId;
			CallerThreadName = Thread.CurrentThread.Name;
			Exception = exception;
		}
		public LogEntry(string message)
		{
			Name = "Unnamed log entry";
			Message = message;
			Date = DateTime.Now;
			CallerThreadId = Thread.CurrentThread.ManagedThreadId;
			CallerThreadName = Thread.CurrentThread.Name;
			Exception = null;
		}
		public LogEntry(string logName, string message)
		{
			Name = logName;
			Message = message;
			Date = DateTime.Now;
			CallerThreadId = Thread.CurrentThread.ManagedThreadId;
			CallerThreadName = Thread.CurrentThread.Name;
			Exception = null;
		}
		public LogEntry(string logName, string message, Exception exception)
		{
			Name = logName;
			Message = message;
			Date = DateTime.Now;
			CallerThreadId = Thread.CurrentThread.ManagedThreadId;
			CallerThreadName = Thread.CurrentThread.Name;
			Exception = exception;
		}
	}
}
