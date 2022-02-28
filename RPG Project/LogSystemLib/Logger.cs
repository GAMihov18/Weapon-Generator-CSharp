namespace LogSystemLib.LogWriting
{
	
	public interface ILogger
	{
		string Path { get; }
		public void LogText(string message);
		public void LogClear();
		public void Log(ILogEntry logEntry);
		public bool IsFileAvailable();
	}

    public class Logger : ILogger
	{
		public string Path { get; set;}
		Thread? listenerThread;
		public Logger()
		{
			Path = "log.txt";
			StartListenerThread();
		}
		public Logger(string path)
		{
			Path = path;
			StartListenerThread();
		}
		private void StartListenerThread()
		{
			Thread listenerThread = new Thread(FileAvailabilityListener);
			listenerThread.Name = "FileAvailabilityListener";
			listenerThread.Start();
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
		public void LogClear()
		{
			StreamWriter writer = new StreamWriter(Path, append: false);
			writer.WriteLine("");
			writer.Close();
		}
		private void FileAvailabilityListener()
		{
			Mutex mutex = new Mutex(false, "LoggerFileSync");
			while (true)
			{
				if (IsFileAvailable())
				{
					mutex.WaitOne();
					Thread.Sleep(1000);
					mutex.ReleaseMutex();
				}
			}
		}
		public bool IsFileAvailable()
		{
			StreamWriter writer = new StreamWriter(Path, append: true);
			try
			{
				writer.WriteLine("");
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}