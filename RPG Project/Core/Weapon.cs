namespace Core;

public class Weapon : IWeapon
{
	private double AssemblyValue { get; set; }
	public double PhysicalDamage { get; }
	public double MagicalDamage { get; }
	public float CritChance { get; }
	public float CritDamage { get; }
	public IRarity ItemRarity { get; }
	private IDamageType _physicalDamageType;
	private IDamageType _magicalDamageType;
	public IDamageType MainDamageType { get; }
	public IDamageType SecondaryDamageType { get; }

	private void applyModifiers()
	{
		foreach (var modificationStep in ItemRarity.ModificationSteps)
		{
			
		}
	}
	
}