using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class DebugName : ValueComponent<string>, IInScope<Game> { }
}