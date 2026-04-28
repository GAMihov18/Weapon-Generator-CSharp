namespace Core;
//TODO
public interface IWeapon
{
	double PhysicalDamage { get; }
	double MagicalDamage { get; }
	float CritChance { get; }
	float CritDamage { get; }
	IRarity ItemRarity { get; }
	
	IDamageType MainDamageType { get; }
	IDamageType SecondaryDamageType { get; }
}