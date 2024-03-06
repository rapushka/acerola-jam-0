using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class TakeCandidate : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }

	public sealed class BurnCandidate : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }
}