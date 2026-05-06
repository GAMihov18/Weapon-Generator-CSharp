namespace GameCore;

public class WeaponType(string name, double assemblyValueModFlat, double assemblyValueModPercent, double physicalDamageModFlat, double physicalDamageModPercent, double magicalDamageModFlat, double magicalDamageModPercent, double critRateModFlat, double critRateModPercent, double critDamageModFlat, double critDamageModPercent, bool physicalDamageAllowed, bool magicalDamageAllowed )
{
	public string Name => name;
	public double AssemblyValueModFlat => assemblyValueModFlat;
	public double AssemblyValueModPercent => assemblyValueModPercent;
	public double PhysicalDamageModFlat => physicalDamageModFlat;
	public double PhysicalDamageModPercent => physicalDamageModPercent;
	public double MagicalDamageModFlat => magicalDamageModFlat;
	public double MagicalDamageModPercent => magicalDamageModPercent;
	public double CritRateModFlat => critRateModFlat;
	public double CritRateModPercent => critRateModPercent;
	public double CritDamageModFlat => critDamageModFlat;
	public double CritDamageModPercent => critDamageModPercent;
	public bool PhysicalDamageAllowed => physicalDamageAllowed;
	public bool MagicalDamageAllowed => magicalDamageAllowed;
}