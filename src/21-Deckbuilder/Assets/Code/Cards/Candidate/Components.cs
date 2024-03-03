using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Candidate : IndexComponent<Code.Side>, IInScope<Game>, IUnique { }
}