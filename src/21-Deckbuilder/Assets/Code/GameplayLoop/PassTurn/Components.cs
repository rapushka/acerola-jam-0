using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class CurrentTurn : FlagComponent, IInScope<Game>, IUnique { }

	/// <summary> Side ends with their current hand </summary>
	public sealed class Stand : FlagComponent, IInScope<Game> { }

	public sealed class StartDeal : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }

	public sealed class EndDeal : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }
}