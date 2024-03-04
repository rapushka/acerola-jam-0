using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Card : FlagComponent, IInScope<Game> { }

	public sealed class ToBurn : FlagComponent, IInScope<Game> { }

	public sealed class Face : ValueComponent<CardFace>, IInScope<Game>, IEvent<Self> { }

	public sealed class Suit : ValueComponent<CardSuit>, IInScope<Game>, IEvent<Self> { }
}