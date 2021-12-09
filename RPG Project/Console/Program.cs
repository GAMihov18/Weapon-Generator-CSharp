using System;
using ConsoleLibs;
using LogSystemLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Generator";
            LogSystem logFile = new LogSystem("log.txt", true);
            logFile.LogText($"Log created on: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");

            //Menu.MainMenu();
            logFile.LogText("End of log\n----------------------");
        }
    }
}
