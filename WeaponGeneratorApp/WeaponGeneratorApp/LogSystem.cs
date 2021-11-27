using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogSystem
{

	public class LogEntry
	{
		private SeverityC severity;
		private string message;
		public SeverityC.Values Severity
        {
			get
            {
				return severity.SeverityType;
            }
			set
            {
				severity.SeverityType = value;
            }
        }
		public string Message
        {
			get { return message; }
			set { message = value; }
        }
        public class SeverityC
		{
			private Values severityType;
			public Values SeverityType 
			{ 
				get 
				{ 
					return severityType;
				}
				set
                {
					severityType = value;
                }
			}
			public enum Values
			{
				Text,Info,Warning,Error,Fatal
			}
			public override string ToString()
            {
                switch (severityType)
                {
                    case Values.Text:
                        return "";
                    case Values.Info:
                        return "Info";
                    case Values.Warning:
                        return "Warning";
                    case Values.Error:
                        return "Error";
                    case Values.Fatal:
                        return "Fatal";
                    default:
						throw new InvalidCastException("Invalid severity type given");
                }
            }
		}

	}
	class Log
	{
		private string path;
		private bool append;
		public Log(string path, bool append)
		{
			this.path = path;
			this.append = append;
		}
		public void Clear()
		{
			StreamWriter logFile = new StreamWriter(path, false);
			logFile.Write("");
			logFile.Close();
		}
		public void LogText(string message)
		{
			StreamWriter logFile = new StreamWriter(path, append);
			logFile.WriteLine(message);
			logFile.Close();
		}
		public void LogInfo(string message)
		{
			StreamWriter logFile = new StreamWriter(path, append);
			logFile.WriteLine($"INFO    || {message}");
			logFile.Close();
		}
		public void LogWarning(string message)
		{
			StreamWriter logFile = new StreamWriter(path, append);
			logFile.WriteLine($"WARNING || {message}");
			logFile.Close();
		}
		public void LogError(string message)
		{
			StreamWriter logFile = new StreamWriter(path, append);
			logFile.WriteLine($"ERROR   || {message}");
			logFile.Close();
		}
		public void LogFatal(string message)
		{
			StreamWriter logFile = new StreamWriter(path, append);
			logFile.WriteLine($"FATAL   || {message}");
			logFile.Close();
		}
	}
}
