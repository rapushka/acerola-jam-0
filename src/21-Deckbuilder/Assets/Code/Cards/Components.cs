using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Card : FlagComponent, IInScope<Game> { }

	public sealed class ToBurn : FlagComponent, IInScope<Game> { }

	public sealed class Burned : FlagComponent, IInScope<Game> { }

	public sealed class Face : IndexComponent<CardId>, IInScope<Game>, IEvent<Self> { }

	public sealed class Points : ValueComponent<int>, IInScope<Game> { }

	public sealed class Order : ValueComponent<int>, IInScope<Game> { }
}