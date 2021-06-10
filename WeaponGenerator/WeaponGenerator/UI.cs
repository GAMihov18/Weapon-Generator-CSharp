using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class Menu
    {
        public static void MainMenu()
        {
            Console.Write($"     Main Menu     \n" +
                          $"1. Generate players(WIP)\n" +
                          $"2. Generate weapons(WIP, functional)\n" +
                          $"3. Generate armors(WIP)\n" +
                          $"\n" +
                          $"\n" +
                          $"\n" +
                          $"0. Exit\n");

            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '0':
                    Console.WriteLine("\nPress any key to exit application..."); Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
