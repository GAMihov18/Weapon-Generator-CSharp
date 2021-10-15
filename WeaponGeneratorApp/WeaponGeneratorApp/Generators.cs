using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFMiscLib.RandomNumber;
using LogSystem;
namespace WeaponGeneration
{
	public struct WEAPON_VALUE
	{
		public enum TYPE
		{
			KNIFE, DAGGER, SHORTSWORD, LONGSWORD, BASTARD_SWORD, BOW, POLEARM, SPEAR, TWO_HANDED_SWORD, SHIELD, HAMMER, MACE, WAR_AXE, BATTLE_AXE, RAPIER
		}
		public enum RARITY
		{
			COMMON, UNCOMMON, RARE, ULTRA_RARE, LEGENDARY, MYTHIC, SPECIAL
		}
		public struct DAMAGE_TYPE
		{
			public enum MAIN
			{
				SLASHING, PIERCING, BLUNT, FIRE, WATER, EARTH, AIR, VOID, LUX, PROTECTION
			}
		}
		
		public static string ToString(WEAPON_VALUE.TYPE type)
		{
			switch (type)
			{
				case TYPE.KNIFE:
					return "Knife";
				case TYPE.DAGGER:
					return "Dagger";
				case TYPE.SHORTSWORD:
					return "Short Sword";
				case TYPE.LONGSWORD:
					return "Long Sword";
				case TYPE.BASTARD_SWORD:
					return "Bastard Sword";
				case TYPE.BOW:
					return "Bow";
				case TYPE.POLEARM:
					return "Polearm";
				case TYPE.SPEAR:
					return "Spear";
				case TYPE.TWO_HANDED_SWORD:
					return "Two-handed Sword";
				case TYPE.SHIELD:
					return "Shield";
				case TYPE.HAMMER:
					return "Hammer";
				case TYPE.MACE:
					return "Mace";
				case TYPE.WAR_AXE:
					return "War Axe";
				case TYPE.BATTLE_AXE:
					return "Battle Axe";
				case TYPE.RAPIER:
					return "Rapier";
				default:
					return "Error";

			}
		}
		public static string ToString(WEAPON_VALUE.RARITY rarity)
		{
			switch (rarity)
			{
				case RARITY.COMMON:
					return "Common";
				case RARITY.UNCOMMON:
					return "Uncommon";
				case RARITY.RARE:
					return "Rare";
				case RARITY.ULTRA_RARE:
					return "Ultra Rare";
				case RARITY.LEGENDARY:
					return "Legendary";
				case RARITY.MYTHIC:
					return "Mythic";
				case RARITY.SPECIAL:
					return "Special";
				default:
					return "Error";
			}
		}
		public static string ToString(WEAPON_VALUE.DAMAGE_TYPE.MAIN dType)
		{
			switch (dType)
			{
				case DAMAGE_TYPE.MAIN.SLASHING:
					return "Slashing";
				case DAMAGE_TYPE.MAIN.PIERCING:
					return "Piercing";
				case DAMAGE_TYPE.MAIN.BLUNT:
					return "Bludgeoning";
				case DAMAGE_TYPE.MAIN.FIRE:
					return "Fire";
				case DAMAGE_TYPE.MAIN.WATER:
					return "Water";
				case DAMAGE_TYPE.MAIN.EARTH:
					return "Earth";
				case DAMAGE_TYPE.MAIN.AIR:
					return "Air";
				case DAMAGE_TYPE.MAIN.VOID:
					return "Void";
				case DAMAGE_TYPE.MAIN.LUX:
					return "Lux";
				default:
					return "Error";
			}
		}
	}
	public class Weapon
	{
		private string? name;
		private double assemblyDamage;
		private double physicalDamage;
		private double magicalDamage;
		private double critRate;
		private double critMult;
		private WEAPON_VALUE.TYPE weaponType;
		private WEAPON_VALUE.RARITY rarity;
		private WEAPON_VALUE.DAMAGE_TYPE.MAIN physicalDamageType;
		private WEAPON_VALUE.DAMAGE_TYPE.MAIN magicalDamageType;
		private WEAPON_VALUE.DAMAGE_TYPE.MAIN mainDamageType;
		public string Name
        {
			get { return name; }
			set { name = value; }
        }
		public double AssemblyDamage
		{
			get { return assemblyDamage; }
			set { assemblyDamage = value; }
		}
		public double PhysicalDamage
		{
			get { return physicalDamage; }
			set { physicalDamage = value; }
		}
		public double MagicalDamage
		{
			get { return MagicalDamage; }
			set { MagicalDamage = value; }
		}
		public double CritRate
		{
			get { return critRate; }
			set { critRate = value; }
		}
		public double CritMult
		{
			get { return critMult; }
			set { critMult = value; }
		}
		public WEAPON_VALUE.TYPE WeaponType
		{
			get { return weaponType; }
			set { weaponType = value; }
		}
		public WEAPON_VALUE.RARITY Rarity
		{
			get { return rarity; }
			set { rarity = value; }
		}
		public WEAPON_VALUE.DAMAGE_TYPE.MAIN PhysicalDamageType
		{
			get { return physicalDamageType; }
			set { physicalDamageType = value; }
		}
		public WEAPON_VALUE.DAMAGE_TYPE.MAIN MagicalDamageType
		{
			get { return magicalDamageType; }
			set { magicalDamageType = value; }
		}
		public Weapon()
		{
			assemblyDamage = RAND.getRandDouble(1, 1001);
			critMult = RAND.getRandDouble(1.05, 2.51);
			critRate = RAND.getRandDouble(0.01, 0.21);
			weaponType = (WEAPON_VALUE.TYPE)RAND.getRandInt(0, 15);
			rarity = (WEAPON_VALUE.RARITY)RAND.getRandInt(0, 7);
			SetPhysDamage();
			magicalDamageType = (WEAPON_VALUE.DAMAGE_TYPE.MAIN)RAND.getRandInt(3, 9);
			SetMainDamageType();
			applyRarityMod();
			applyMainDamageMod();
			SetName();
		}
		public Weapon(WEAPON_VALUE.RARITY rarity)
        {
			assemblyDamage = RAND.getRandDouble(1, 1001);
			critMult = RAND.getRandDouble(1.05, 2.51);
			critRate = RAND.getRandDouble(0.01, 0.21);
			weaponType = (WEAPON_VALUE.TYPE)RAND.getRandInt(0, 15);
			this.rarity = rarity;
			SetPhysDamage();
			magicalDamageType = (WEAPON_VALUE.DAMAGE_TYPE.MAIN)RAND.getRandInt(3, 9);
			SetMainDamageType();
			applyRarityMod();
			applyMainDamageMod();
			SetName();
		}
		private void SetPhysDamage()
		{
			switch (weaponType)
			{
				case WEAPON_VALUE.TYPE.KNIFE:
				case WEAPON_VALUE.TYPE.SHORTSWORD:
				case WEAPON_VALUE.TYPE.LONGSWORD:
				case WEAPON_VALUE.TYPE.BASTARD_SWORD:
				case WEAPON_VALUE.TYPE.POLEARM:
				case WEAPON_VALUE.TYPE.TWO_HANDED_SWORD:
				case WEAPON_VALUE.TYPE.BATTLE_AXE:
				case WEAPON_VALUE.TYPE.WAR_AXE:
					physicalDamageType = WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING;
					break;
				case WEAPON_VALUE.TYPE.DAGGER:
				case WEAPON_VALUE.TYPE.BOW:
				case WEAPON_VALUE.TYPE.SPEAR:
				case WEAPON_VALUE.TYPE.RAPIER:
					physicalDamageType = WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING;
					break;
				case WEAPON_VALUE.TYPE.MACE:
				case WEAPON_VALUE.TYPE.HAMMER:
					physicalDamageType = WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT;
					break;
				case WEAPON_VALUE.TYPE.SHIELD:
					break;
				default:
					Exception exc = new Exception("Invalid weapon type");
					throw exc;
			}
		}
		private void SetMainDamageType()
		{
			if (RAND.getRandInt(0, 101) < 50)
				mainDamageType = physicalDamageType;
			else
				mainDamageType = magicalDamageType;
		}
		private void SetName()
		{
			name = $"{WEAPON_VALUE.ToString(rarity)} {WEAPON_VALUE.ToString(weaponType)} of {WEAPON_VALUE.ToString(mainDamageType)}";
		}
		public string GetWeaponData(bool readable)
		{
			if (readable)
			{
				return $"Name: {name}\nAssembly Damage: {assemblyDamage:f2}\nPhysical Damage: {physicalDamage:f2}\nMagical Damage: {magicalDamage:f2}\nCrit Mult: {critMult:p2}\nCrit Rate: {critRate:p2}\nRarity: {WEAPON_VALUE.ToString(rarity)}\nWeapon Type: {WEAPON_VALUE.ToString(weaponType)}\nMain Damage Type: {WEAPON_VALUE.ToString(mainDamageType)}\nPhysical Damage: {WEAPON_VALUE.ToString(physicalDamageType)}\nMagical Damage: {WEAPON_VALUE.ToString(magicalDamageType)}";
			}
			else
			{
				return $"{name}:{assemblyDamage:f2}:{physicalDamage:f2}:{magicalDamage:f2}:{critMult:p}:{critRate:p}:{WEAPON_VALUE.ToString(rarity)}:{WEAPON_VALUE.ToString(weaponType)}:{WEAPON_VALUE.ToString(mainDamageType)}:{WEAPON_VALUE.ToString(physicalDamageType)}:{WEAPON_VALUE.ToString(magicalDamageType)}";
			}
		}
		private void applyRarityMod()
		{
			switch (rarity)
			{
				case WEAPON_VALUE.RARITY.COMMON:
					assemblyDamage *= 0.7;
					critRate *= 0.5;
					critMult *= 1;
					break;
				case WEAPON_VALUE.RARITY.UNCOMMON:
					assemblyDamage += 100;
					assemblyDamage *= 0.9;
					critRate *= 0.6;
					critMult *= 1.08;
					break;
				case WEAPON_VALUE.RARITY.RARE:
					assemblyDamage += 150;
					assemblyDamage *= 1;
					critRate *= 0.8;
					critMult *= 1.2;
					break;
				case WEAPON_VALUE.RARITY.ULTRA_RARE:
					assemblyDamage += 200;
					assemblyDamage *= 1.1;
					critRate *= 0.9;
					critMult *= 1.3;
					break;
				case WEAPON_VALUE.RARITY.LEGENDARY:
					assemblyDamage += 250;
					assemblyDamage *= 1.175;
					critRate *= 1.05;
					critMult *= 1.5;
					break;
				case WEAPON_VALUE.RARITY.MYTHIC:
					assemblyDamage += 300;
					assemblyDamage *= 1.2;
					critRate *= 1.1;
					critMult *= 1.6;
					break;
				case WEAPON_VALUE.RARITY.SPECIAL:
					assemblyDamage += 400;
					assemblyDamage *= 1.3;
					critRate *= 1.2;
					critMult *= 1.7;
					break;
				default:
					break;
			}
		}
		private void applyMainDamageMod()
		{
			switch (mainDamageType)
			{
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING:
					physicalDamage = 1 * assemblyDamage;
					magicalDamage = 0.01 * assemblyDamage;
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING:
					physicalDamage = 0.5 * assemblyDamage;
					magicalDamage = 0.01 * assemblyDamage;
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT:
					physicalDamage = 0.8 * assemblyDamage;
					magicalDamage = 0.01 * assemblyDamage;
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.FIRE:
					magicalDamage = 0.4 * assemblyDamage;
					switch (physicalDamageType)
					{
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING:
							physicalDamage = 0.5 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING:
							physicalDamage = 0.1 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT:
							physicalDamage = 0.4 * assemblyDamage;
							break;
						default:
							break;
					}
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.WATER:
					magicalDamage = 0.4 * assemblyDamage;
					switch (physicalDamageType)
					{
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING:
							physicalDamage = 0.5 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING:
							physicalDamage = 0.1 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT:
							physicalDamage = 0.4 * assemblyDamage;
							break;
						default:
							break;
					}
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.EARTH:
					magicalDamage = 0.4 * assemblyDamage;
					switch (physicalDamageType)
					{
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING:
							physicalDamage = 0.5 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING:
							physicalDamage = 0.1 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT:
							physicalDamage = 0.4 * assemblyDamage;
							break;
						default:
							break;
					}
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.AIR:
					magicalDamage = 0.4 * assemblyDamage;
					switch (physicalDamageType)
					{
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING:
							physicalDamage = 0.5 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING:
							physicalDamage = 0.1 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT:
							physicalDamage = 0.4 * assemblyDamage;
							break;
						default:
							break;
					}
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.VOID:
					magicalDamage = 0.4 * assemblyDamage;
					switch (physicalDamageType)
					{
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING:
							physicalDamage = 0.5 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING:
							physicalDamage = 0.1 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT:
							physicalDamage = 0.4 * assemblyDamage;
							break;
						default:
							break;
					}
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.LUX:
					magicalDamage = 0.4 * assemblyDamage;
					switch (physicalDamageType)
					{
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.SLASHING:
							physicalDamage = 0.5 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PIERCING:
							physicalDamage = 0.1 * assemblyDamage;
							break;
						case WEAPON_VALUE.DAMAGE_TYPE.MAIN.BLUNT:
							physicalDamage = 0.4 * assemblyDamage;
							break;
						default:
							break;
					}
					break;
				case WEAPON_VALUE.DAMAGE_TYPE.MAIN.PROTECTION:
					break;
				default:
					break;
			}
		}
	}
}