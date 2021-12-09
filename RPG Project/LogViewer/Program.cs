using System;
namespace LogViewer
{ 
    class Program
    {
        static void Main()
        {
            string path = @"C:\Users\georg\source\repos\GAMihov18\Weapon-Generator-CSharp\RPG Project\WindowsApp\bin\Debug\net6.0-windows\generated_weapons.txt";
            TextReader logFile = new StreamReader(path);

            while (true)
            {
                Console.Write(logFile.ReadToEnd());
            }
        }
    }
}

