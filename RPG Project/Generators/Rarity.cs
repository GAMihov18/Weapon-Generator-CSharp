using ItemData;
using System;
using System.Text.Json;

namespace ItemData
{
	public class Rariry
	{
		public string? Name { get; set; }
		public double FlatAssemblyDamageMod { get; set; }
		public double MultAssemblyDamageMod { get; set; }
		public double FlatCritRateMod { get; set; }
		public double MultCritRateMod { get; set; }
		public double FlatCritMultMod { get; set; }
		public double MultCritMultMod { get; set; }

		public double FlatAssemblyDefenseMod { get; set; }
		public double MultAssemblyDefenseMod { get; set; }
		public double FlatPercentDamageReductionMod { get; set; }
		public double MultPercentDamageReductionMod { get; set; }
	}
}



namespace Loaders
{
	public class RarityLoader
	{
		public List<Rariry> Rarities { get; private set; }
		public Dictionary<string, Rariry> RarityDict { get { return RaritiesDict; } }
		Dictionary<string, Rariry> RaritiesDict;
		public RarityLoader()
		{
			Rarities = JsonSerializer.Deserialize<List<Rariry>>(File.ReadAllText("./data/rarities.json"));
			RaritiesDict = new Dictionary<string, Rariry>();
			foreach (Rariry damageType in Rarities)
			{
				RaritiesDict.Add(damageType.Name, damageType);
			}
		}
	}

}