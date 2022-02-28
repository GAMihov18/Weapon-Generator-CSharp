using System;
using LogSystemLib.LogWriting;
using LogSystemLib.LogReading;
namespace LogViewer
{ 
    
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.Name = "MainThreadViewerThread";
            Logger logger = new Logger();
            logger.Log("this is interesting", ILogEntry.LogSeverity.Info);
        }
    }
}

