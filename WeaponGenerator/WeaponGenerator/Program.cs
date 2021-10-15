using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using WeaponGeneration;
using UI;
using LogSystem;
using RFMiscLib;

namespace WeaponGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Generator";
			Log logFile = new Log("log.txt",true);
			logFile.LogText($"Log created on: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");

			//Menu.MainMenu();
			logFile.LogText("End of log\n----------------------");
		}
	}
}
