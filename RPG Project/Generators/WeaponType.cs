using System;
using System.Text.Json;
using ItemData;

namespace ItemData
{
	

	public class WeaponType
	{
		public string Type { get; set; }
		public DamageType MainDamageType { get; set; }
		public double MultPhysicalDamageMod { get; set; }
		public double MultMagicalDamageMod { get; set; }
	}
}

namespace Loaders
{
	class WeaponTypeWrapper
	{
		public string Type { get; set; }
		public string DamageType { get; set; }
		public double MultPhysicalDamageMod { get; set; }
		public double MultMagicalDamageMod { get; set; }
	}
	public class WeaponTypeLoader
	{

		public List<WeaponType> WeaponTypes { get; private set; }
		private List<WeaponTypeWrapper> wrappedWeaponTypes { get; set; }
		public Dictionary<string, WeaponType> WeaponTypeDict { get { return weaponTypeDict; } }
		Dictionary<string, WeaponType> weaponTypeDict;
		public WeaponTypeLoader()
		{
			wrappedWeaponTypes = JsonSerializer.Deserialize<List<WeaponTypeWrapper>>(File.ReadAllText("./data/weaponTypes.json"));
			WeaponTypes = UnwrapWeaponTypes();
			weaponTypeDict = new Dictionary<string, WeaponType>();
			foreach (WeaponType weaponType in WeaponTypes)
			{
				weaponTypeDict[weaponType.Type] = weaponType;
			}

		}
		private List<WeaponType> UnwrapWeaponTypes()
		{
			DamageTypeLoader dtloader = new DamageTypeLoader();
			List<WeaponType> weaponTypes = new List<WeaponType>();
			foreach (WeaponTypeWrapper wrappedWeaponType in wrappedWeaponTypes)
			{
				weaponTypes.Add(new WeaponType()
				{
					Type = wrappedWeaponType.Type,
					MainDamageType = dtloader.DamageTypeDict[wrappedWeaponType.DamageType],
					MultPhysicalDamageMod = wrappedWeaponType.MultPhysicalDamageMod,
					MultMagicalDamageMod = wrappedWeaponType.MultMagicalDamageMod
				});
			}
			return weaponTypes;
		}
	}

}

