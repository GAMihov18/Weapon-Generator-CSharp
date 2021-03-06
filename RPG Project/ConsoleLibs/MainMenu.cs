using LogSystemLib.LogWriting;
using Generators.WeaponGenerators;
namespace ConsoleLibs
{
    public class Menus
    {
        public static void Main()
        {
            Console.Clear();
            Console.Write($"     Main Menu     \n" +
                          $"1. Generate players(WIP)\n" +
                          $"2. Generate weapons(WIP, functional)\n" +
                          $"3. Generate armors(WIP)\n" +
                          $"0. Exit\n");
            int temp;
            switch (Console.ReadLine())
            {
                case "1":
                    Main();
                    break;
                case "2":
                    Console.Clear();
                    Logger log = new Logger("weapon_generator.txt");
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
                    Main();
                    break;
                case "3":
                    Main();
                    break;
                case "0":
                    Console.WriteLine("\nExiting App");
                    break;
                default:
                    Console.Clear();
                    Console.Write("Wrong input, returning to main menu");
                    Main();
                    break;
            }
        }
    }
}