using System;
using System.Diagnostics;
using System.IO;
using WeaponGeneration;
using UI;
namespace WeaponGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StreamWriter logFile = new StreamWriter("log.txt");
            StreamWriter weaponLog = new StreamWriter("generated_weapons.txt");
            using (logFile)
            {
                logFile.WriteLine($"|| Log created on: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}");

                Menu.MainMenu();

                logFile.WriteLine("----------------------");
            }

        }
    }
}
