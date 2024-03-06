using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Money : ValueComponent<int>, IInScope<Game> { }

	public sealed class Bank : FlagComponent, IInScope<Game>, IUnique { }

	public sealed class CurrentBet : ValueComponent<int>, IInScope<Game> { }

	public sealed class MinBet : ValueComponent<int>, IInScope<Game> { }

	/// <summary> Means the current side places the bet == to Bank.CurrentBet </summary>
	public sealed class Bet : FlagComponent, IInScope<Game> { }

	/// <summary> Means the current side passes (i.e. leaves from deal) </summary>
	public sealed class Pass : FlagComponent, IInScope<Game> { }

	public sealed class Winner : FlagComponent, IInScope<Game> { }
}