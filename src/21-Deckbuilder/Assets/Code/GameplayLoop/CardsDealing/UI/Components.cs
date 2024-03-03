using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	/// <summary> Stands for side drawing a card </summary>
	public sealed class Hit : FlagComponent, IInScope<Game>, ICleanup<RemoveComponent> { }
}