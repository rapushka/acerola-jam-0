using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Rotatable : FlagComponent, IInScope<Game>, IEvent<Self> { }

	public sealed class DeltaRotation : ValueComponent<float>, IInScope<Game>, IEvent<Self> { }
}