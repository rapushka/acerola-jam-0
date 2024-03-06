using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Money : ValueComponent<int>, IInScope<Game> { }

	public sealed class Bank : FlagComponent, IInScope<Game>, IUnique { }

	public sealed class CurrentBet : ValueComponent<int>, IInScope<Game> { }

	public sealed class MinBet : ValueComponent<int>, IInScope<Game> { }
}