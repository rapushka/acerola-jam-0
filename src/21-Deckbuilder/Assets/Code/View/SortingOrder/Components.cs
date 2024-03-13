using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class SortingOrder : ValueComponent<int>, IInScope<Game>, IEvent<Self> { }
}