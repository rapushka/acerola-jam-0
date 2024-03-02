using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Face : ValueComponent<CardFace>, IInScope<Game> { }

	public sealed class Suit : ValueComponent<CardSuit>, IInScope<Game> { }

	public sealed class Sprite : ValueComponent<UnityEngine.Sprite>, IInScope<Game>, IEvent<Self> { }
}