using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	/// <summary> Add to Dealer's entity </summary>
	public sealed class DealerNumber : ValueComponent<int>, IInScope<Game> { }

	/// <summary> Add to the new entity </summary>
	public sealed class CreateNewDealer : FlagComponent, IInScope<Game> { }

	public sealed class Bankrupt : FlagComponent, IInScope<Game> { }
}