using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Lens : FlagComponent, IInScope<Game> { }

	public sealed class Draggable : FlagComponent, IInScope<Game> { }
}