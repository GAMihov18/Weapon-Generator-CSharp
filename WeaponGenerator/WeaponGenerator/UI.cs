using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using LogSystem;
using WeaponGeneration;
using static WeaponGeneration.WEAPON_VALUE;

namespace UI
{
    public class Menu
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.Write($"     Main Menu     \n" +
                          $"1. Generate players(WIP)\n" +
                          $"2. Generate weapons(WIP, functional)\n" +
                          $"3. Generate armors(WIP)\n" +
                          $"0. Exit\n");
            int temp;
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    MainMenu();
                    break;
                case '2':
                    Console.Clear();
                    Log log = new Log("weapon_generator.txt", true);
                    log.LogClear();
                    Console.Write($"How many weapons do you want to generate? ");
                    temp = int.Parse(Console.ReadLine());
                    log.LogText($"Name:Assembly Damage:Physical Damage:Magical Damage:Crit Mult:Crit Rate:Rarity:Weapon Type:Main Damage Type:Physical Damage:Magical Damage:");
                    for (int i = 0; i < temp; i++)
                    {
                        Weapon w = new Weapon();
                        log.LogText(w.GetWeaponData(false));
                    }
                    Console.Clear();
                    Console.Write($"Successfully generated {temp} weapons.\nCheck .exe directory for a file"); Thread.Sleep(1000);
                    MainMenu();
                    break;
                case '3':
                    MainMenu();
                    break;
                case '0':
                    Console.WriteLine("\nExiting App");
                    break;
                default:
                    break;
            }
        }
    }
}
