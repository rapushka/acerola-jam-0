using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Rules : FlagComponent, IInScope<Game>, IUnique { }

	public sealed class MaxPointsThreshold : ValueComponent<int>, IInScope<Game> { }

	public sealed class MaxCardsInHand : ValueComponent<int>, IInScope<Game> { }
}