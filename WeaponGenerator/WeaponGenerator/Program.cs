using System;
using System.Diagnostics;
using System.IO;
using WeaponGeneration;

namespace WeaponGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Weapon weapon;
            StreamWriter writer = new StreamWriter("generated_weapons.txt");
            string a = "Name:Assembly Damage:Physical Damage:Magical Damage:Crit Mult:Crit Rate:Rarity:Weapon Type:Main Damage Type:Physical Damage Type:Magical Damage Type\n";
            using (writer)
            {
                writer.Write(a);
                Stopwatch timer = Stopwatch.StartNew();
                for (int i = 0; i < 1000; i++)
                {
                    weapon = new Weapon();
                    writer.Write(weapon.GetWeaponData(false));
                }
                timer.Stop();
                TimeSpan tm = timer.Elapsed;
                Console.WriteLine("Time elapsed:{0:#0} Minutes, {1:#0} Seconds, {2:##0} Milliseconds", tm.Minutes, tm.Seconds, tm.Milliseconds);
            }
            Console.WriteLine("Press any key to exit application..."); Console.ReadKey();
            
        }
    }
}
