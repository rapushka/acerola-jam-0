using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public sealed class Position : ValueComponent<Vector2>, IInScope<Game>, IEvent<Self> { }

	public sealed class ActualPosition : ValueComponent<Vector2>, IInScope<Game>, IEvent<Self> { }
}