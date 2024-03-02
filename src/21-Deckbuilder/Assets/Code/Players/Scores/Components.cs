using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Score : ValueComponent<int>, IInScope<Game> { }
}