using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class CurrentTurn : FlagComponent, IInScope<Game>, IUnique { }

	/// <summary> Side ends with their current hand </summary>
	public sealed class Stand : FlagComponent, IInScope<Game>, ICleanup<RemoveComponent> { }
}