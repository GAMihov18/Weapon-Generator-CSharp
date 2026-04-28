namespace Core;

public class Rarity : IRarity
{
	public IModificationStep<double>[] ModificationSteps { get; }
	public string Name { get; }
}