namespace GameCore;
//TODO Add more properties for armor modifiers once I come up with the values that they will have.
public class ElementType(bool weaponCompatible, bool armorCompatible, bool physicalType, bool magicalType, double physicalDamageModFlat, double physicalDamageModPercent, double magicalDamageModFlat, double magicalDamageModPercent)
{
	public bool WeaponCompatible => weaponCompatible;
	public bool ArmorCompatible => armorCompatible;
	public bool PhysicalType => physicalType;
	public bool MagicalType => magicalType;
	public double WeaponPhysicalDamageModFlat => physicalDamageModFlat;
	public double WeaponPhysicalDamageModPercent => physicalDamageModPercent;
	public double WeaponMagicalDamageModFlat => magicalDamageModFlat;
	public double WeaponMagicalDamageModPercent => magicalDamageModPercent;
}