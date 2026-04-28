namespace Core;

public interface IModifier<T>
{
	IModificationStep<T>[]  ModificationSteps { get; }
	
}