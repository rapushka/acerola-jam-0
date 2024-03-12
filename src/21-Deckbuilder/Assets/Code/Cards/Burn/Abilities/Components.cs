using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class AbilityTargets : ValueComponent<RelativeSide[]>, IInScope<Game> { }

	public sealed class ChangePoints : ValueComponent<int>, IInScope<Game> { }

	public sealed class DestroyAllSuit : ValueComponent<CardSuit>, IInScope<Game> { }

	public sealed class DestroyAllCardsInHand : FlagComponent, IInScope<Game> { }

	public sealed class ChangePointsThreshold : ValueComponent<int>, IInScope<Game> { }

	public sealed class ChangeMaxCardsInHand : ValueComponent<int>, IInScope<Game> { }

	public sealed class InvokeFlipWinCondition : FlagComponent, IInScope<Game> { }

	public sealed class CanNotBeBurn : FlagComponent, IInScope<Game> { }

	public sealed class DraftCards : ValueComponent<int>, IInScope<Game> { }
}