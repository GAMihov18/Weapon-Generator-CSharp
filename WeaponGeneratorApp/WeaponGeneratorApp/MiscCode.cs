using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace RFMiscLib
{
	namespace RandomNumber
	{
		public class RAND
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
	class Reader
	{
		public static string ReadLine(int timeToWait)
		{
			int i = 0;
			do
			{
				i++;
				Thread.Sleep(1);
			} while (i <= timeToWait && Console.KeyAvailable == false);
			if (i <= timeToWait)
			{
				return Console.ReadLine();
			}
			else
			{
				return string.Empty;
			}
		}
		public static string ReadLine(int timeToWait, string timeoutMessage)
		{
			int i = 0;
			do
			{
				i++;
				Thread.Sleep(1);
			} while (i <= timeToWait && Console.KeyAvailable == false);
			if (i <= timeToWait)
			{
				return Console.ReadLine();
			}
			else
			{
				return timeoutMessage;
			}
		}
	}
}