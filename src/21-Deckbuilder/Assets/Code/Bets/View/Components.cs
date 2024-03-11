using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class MoneyOf : PrimaryIndexComponent<Side>, IInScope<Game> { }

	/// <summary> Same as the Bet, but stands for visualisation of it </summary>
	public sealed class Transaction : FlagComponent, IInScope<Game> { }
}