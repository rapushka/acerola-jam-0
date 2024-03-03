using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Side : PrimaryIndexComponent<Code.Side>, IInScope<Game> { }

	/// <summary> Apply to the cards </summary>
	public sealed class HeldBy : IndexComponent<Code.Side>, IInScope<Game> { }
}