using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogSystemLib.LogWriting;

namespace LogSystemLib.LogReading
{
	interface ILogReader
	{
		public string Path { get; }
	}
	public class LogReader : ILogReader
	{
		public string Path { get; set; }
		StringBuilder builder = new StringBuilder();
		public LogReader()
		{
			Path = "log.txt";
		}
	}
}
