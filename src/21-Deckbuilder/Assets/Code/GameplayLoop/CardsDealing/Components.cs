using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	/// <summary> Side draws a card </summary>
	public sealed class Hit : FlagComponent, IInScope<Game>, ICleanup<RemoveComponent> { }

	/// <summary> Side skips this turn. But they still have got to place a bet </summary>
	public sealed class Stand : FlagComponent, IInScope<Game> { }
}