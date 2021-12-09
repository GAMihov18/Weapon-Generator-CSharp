using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFMiscLib
{
	public class Reader
	{
		public static string? ReadLine(int timeToWait)
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
		public static string? ReadLine(int timeToWait, string timeoutMessage)
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
