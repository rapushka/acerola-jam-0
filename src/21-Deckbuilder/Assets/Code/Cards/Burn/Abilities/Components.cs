using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class AddPoints : ValueComponent<int>, IInScope<Game> { }

	public sealed class SubtractPoints : ValueComponent<int>, IInScope<Game> { }
}