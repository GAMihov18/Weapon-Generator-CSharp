using System;
using ConsoleLibs;
using LogSystemLib.LogWriting;
using Loaders;
using System.Text.Json;
namespace ConsoleApp
{
	class Program
	{
		static void Main()
		{
			Console.Title = "Generator";
			Logger logFile = new Logger("log.txt");
			logFile.LogText($"Log created on: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");

			//Menus.Main();
			DamageTypeLoader dtLoader = new DamageTypeLoader();

			WeaponTypeLoader wtLoader = new WeaponTypeLoader();

			RarityLoader rarityLoader = new RarityLoader();
			

			logFile.LogText("End of log\n----------------------");
		}
	}
}
