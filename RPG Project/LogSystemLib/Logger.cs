namespace LogSystemLib.LogWriting
{
	
	public interface ILogger
	{
		string Path { get; }
		public void LogText(string message);
		
		public void Log(ILogEntry logEntry);
	}

    class Logger : ILogger
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
			StreamWriter writer = new StreamWriter(Path);
			writer.WriteLine(logEntry.ToString());
			writer.Close();
		}

		public void LogText(string text)
		{
			StreamWriter writer = new StreamWriter(Path);
			writer.WriteLine(text);
			writer.Close();
		}
	}
}