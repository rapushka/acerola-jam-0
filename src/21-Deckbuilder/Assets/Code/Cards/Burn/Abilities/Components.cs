using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class ChangeOurPoints : ValueComponent<int>, IInScope<Game> { }

	public sealed class ChangeOpponentPoints : ValueComponent<int>, IInScope<Game> { }

	public sealed class ChangeAllPoints : ValueComponent<int>, IInScope<Game> { }
}