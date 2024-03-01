using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public sealed class Lens : FlagComponent, IInScope<Game> { }

	public sealed class Draggable : FlagComponent, IInScope<Game> { }

	public sealed class Position : ValueComponent<Vector2>, IInScope<Game>, IEvent<Self> { }

	public sealed class Pressed : FlagComponent, IInScope<Game> { }
}