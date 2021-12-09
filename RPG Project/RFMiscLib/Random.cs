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

}