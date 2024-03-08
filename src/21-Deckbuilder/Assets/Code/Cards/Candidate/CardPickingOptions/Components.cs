using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	/// <summary> Add to new entity </summary>
	public sealed class TakeCandidate : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }

	/// <summary> Add to new entity </summary>
	public sealed class BurnCandidate : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity> { }
}