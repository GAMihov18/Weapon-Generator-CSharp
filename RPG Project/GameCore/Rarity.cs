namespace GameCore;

public class Rarity(string name, double assemblyValueModFlat, double assemblyValueModPercent, double critRateModFlat, double critRateModPercent,  double critDamageModFlat, double critDamageModPercent, double elementalResistModPercent)
{
	public string Name => name;
	public double AssemblyValueModFlat =>  assemblyValueModFlat;
	public double AssemblyValueModPercent  => assemblyValueModPercent;
	public double CritRateModFlat  => critRateModFlat;
	public double CritRateModPercent  => critRateModPercent;
	public double CritDamageModFlat   => critDamageModFlat;
	public double CritDamageModPercent  => critDamageModPercent;
	public double ElementalResistModPercent => elementalResistModPercent;
}