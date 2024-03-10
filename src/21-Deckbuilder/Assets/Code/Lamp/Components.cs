using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Lamp : FlagComponent, IInScope<Game>, IUnique { }

	public sealed class RotationSpeed : ValueComponent<float>, IInScope<Game> { }
}