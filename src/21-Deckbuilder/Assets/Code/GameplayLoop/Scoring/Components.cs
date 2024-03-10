using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Scoring : FlagComponent, IInScope<Game>, IUnique { }
}