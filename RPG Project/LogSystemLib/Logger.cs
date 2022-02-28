namespace LogSystemLib.LogWriting
{
	
	public interface ILogger
	{
		public enum LogSeverity
		{
			Info, Warning, Error, Fatal
		}
		public void LogText(string message);
		
		public void Log(ILogEntry logEntry);
	}

    class Logger : ILogger
	{
		public void Log(string message, ILogger.LogSeverity logSeverity)
		{

		}
		public void Log(string message, ILogger.LogSeverity logSeverity, DateTime dateTime, int callerThreadId, string callerThreadName)
		{

		}
		public void Log(Exception exception, ILogger.LogSeverity logSeverity, DateTime dateTime, int callerThreadId, string callerThreadName)
		{

		}

		public void Log(ILogEntry logEntry)
		{
			throw new NotImplementedException();
		}

		public void LogText(string message)
		{
			throw new NotImplementedException();
		}
	}
}