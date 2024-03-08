using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class AbilityTargets : ValueComponent<Code.Side[]>, IInScope<Game> { }

	public sealed class ChangePoints : ValueComponent<int>, IInScope<Game> { }
}