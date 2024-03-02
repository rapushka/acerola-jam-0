using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public sealed class Position : ValueComponent<Vector3>, IInScope<Game> { }

	public sealed class DestinationPosition : ValueComponent<Vector3>, IInScope<Game> { }
	
	
}