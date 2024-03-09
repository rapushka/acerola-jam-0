using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	/// <summary> Those card, which exist only to +/- some points. Gain from other card's abilities </summary>
	public sealed class ShadowCard : PrimaryIndexComponent<Code.Side>, IInScope<Game> { }
}