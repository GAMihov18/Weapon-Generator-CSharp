namespace RFMiscLib
{
	namespace RandomNumber
	{
		public static class RAND
		{
			static Random rnd = new Random();
			public static int getRandInt(int lowerBracket, int upperBracket)
			{
				return rnd.Next(lowerBracket, upperBracket);
			}
			public static double getRandDouble(double lowerBracket, double upperBracket)
			{
				return rnd.NextDouble() * (upperBracket - lowerBracket) + lowerBracket;
			}
		}
	}
}