using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class CurrentTurn : FlagComponent, IInScope<Game>, IUnique { }

	public sealed class StartDeal : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }

	public sealed class EndDeal : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }

	public sealed class KeepPlaying : FlagComponent, IInScope<Game> { }

	public sealed class EndTurn : FlagComponent, IInScope<Game>, ICleanup<RemoveComponent> { }
}