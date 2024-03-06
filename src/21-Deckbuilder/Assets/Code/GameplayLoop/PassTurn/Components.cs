using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class CurrentTurn : FlagComponent, IInScope<Game>, IUnique { }

	public sealed class StartDeal : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }

	public sealed class EndDeal : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }

	/// <summary> Hit/Stand is done. but there's still a Bet </summary>
	public sealed class CardActionDone : FlagComponent, IInScope<Game>, ICleanup<RemoveComponent> { }

	/// <summary> Action with Card is done AND Bet is placed </summary>
	public sealed class TurnEnded : FlagComponent, IInScope<Game>, ICleanup<RemoveComponent> { }
}