using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumber
{
    public struct RAND
    {
        static Random rnd = new Random();
        public static int getRandInt(int a, int b)
        {
            return rnd.Next(a, b);
        }
        public static double getRandDouble(double a, double b)
        {
            return rnd.NextDouble() * (b - a) + a;
        }
    }
}
