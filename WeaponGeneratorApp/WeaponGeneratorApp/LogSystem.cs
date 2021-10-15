using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogSystem
{
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
