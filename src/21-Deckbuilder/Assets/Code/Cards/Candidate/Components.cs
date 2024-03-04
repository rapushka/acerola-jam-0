using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Candidate : ValueComponent<Code.Side>, IInScope<Game>, IUnique { }
}