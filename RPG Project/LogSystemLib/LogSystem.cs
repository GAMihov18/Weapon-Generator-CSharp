namespace LogSystemLib
{
    public class LogSystem
    {
        private string path;
        private bool append;
        public LogSystem(string path, bool append)
        {
            this.path = path;
            this.append = append;
        }
        public void LogClear()
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