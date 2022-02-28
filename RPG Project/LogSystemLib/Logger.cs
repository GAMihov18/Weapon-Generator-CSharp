using System.Text;

namespace LogSystemLib.LogWriting
{
	
	public interface ILogger
	{
		string Path { get; }
		public void LogText(string message);
		public void LogClear();
		public void Log(ILogEntry logEntry);
	}

    public class Logger : ILogger
	{
		public string Path { get; set;}
		public Logger()
		{
			Path = "log.txt";
		}
		public Logger(string path)
		{
			Path = path;
		}
		public void Log(string message, ILogEntry.LogSeverity logSeverity)
		{
			LogEntry logEntry = new LogEntry(message,logSeverity);
			Log(logEntry);
		}
		public void Log(Exception exception, ILogEntry.LogSeverity logSeverity)
		{
			LogEntry logEntry = new LogEntry(exception:exception,severity:logSeverity);
			Log(logEntry);
		}

		public void Log(ILogEntry logEntry)
		{
			StreamWriter sw = new StreamWriter(Path);
			sw.Write(logEntry.ToString());
		}

		public void LogText(string text)
		{
			StreamWriter sw = new StreamWriter(Path);
			sw.Write(text);
		}
		public void LogClear()
		{
			StreamWriter sw = new StreamWriter(Path,append:false);
			sw.Write("");
		}
	}
}