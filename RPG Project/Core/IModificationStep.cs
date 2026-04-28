using NumberGenerators;

namespace Core;

public interface IModificationStep<out T>
{
	INumberGenerator<double> GeneratorType { get; }
}