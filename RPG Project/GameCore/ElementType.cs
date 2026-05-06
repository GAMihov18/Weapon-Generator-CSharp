namespace GameCore;
//TODO Add more properties for armor modifiers once I come up with the values that they will have.
public class ElementType(bool weaponCompatible, bool armorCompatible, double physicalDamageModFlat, double physicalDamageModPercent, double magicalDamageModFlat, double magicalDamageModPercent)
{
	public bool WeaponCompatible => weaponCompatible;
	public bool ArmorCompatible => armorCompatible;
	public double WeaponPhysicalDamageModFlat => physicalDamageModFlat;
	public double WeaponPhysicalDamageModPercent => physicalDamageModPercent;
	public double WeaponMagicalDamageModFlat => magicalDamageModFlat;
	public double WeaponMagicalDamageModPercent => magicalDamageModPercent;
}