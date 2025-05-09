using System;
using System.Text.Json;
using ItemData;


namespace ItemData
{
	public class DamageType
	{
		public string Type { get; set; }
		public bool IsMagical { get; set; }
		public double MultPhysicalDamageMod { get; set; }
		public double MultMagicalDamageMod { get; set; }
	}
}
namespace Loaders
{
	public class DamageTypeLoader
	{

		public List<DamageType> DamageTypes { get; private set; }
		public Dictionary<string, DamageType> DamageTypeDict { get { return damageTypeDict; } }
		Dictionary<string, DamageType> damageTypeDict;
		public DamageTypeLoader()
		{
			DamageTypes = JsonSerializer.Deserialize<List<DamageType>>(File.ReadAllText("./data/damageTypes.json"));
			damageTypeDict = new Dictionary<string, DamageType>();
			foreach (DamageType damageType in DamageTypes)
			{
				damageTypeDict.Add(damageType.Type, damageType);
			}
		}
	}
}

