using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class ShowOnDealEnd : FlagComponent, IInScope<Game> { }

	public sealed class Visible : ValueComponent<bool>, IInScope<Game>, IEvent<Self> { }

	public sealed class Destroyed : FlagComponent, IInScope<Game>, ICleanup<DestroyEntity>, IEvent<Self> { }
}