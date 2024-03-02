using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public sealed class VectorFromLight : ValueComponent<Vector2>, IInScope<Game>, IEvent<Self> { }

	public sealed class Reflection : FlagComponent, IInScope<Game> { }
}