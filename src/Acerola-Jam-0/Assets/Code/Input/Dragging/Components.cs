using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public sealed class Draggable : FlagComponent, IInScope<Game> { }



	public sealed class Pressed : FlagComponent, IInScope<Game> { }

	public sealed class Dropped : FlagComponent, IInScope<Game>, ICleanup<RemoveComponent> { }
}