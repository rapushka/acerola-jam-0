using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.Component
{
	public sealed class Rotation : ValueComponent<Quaternion>, IInScope<Game>, IEvent<Self> { }

	public sealed class TargetRotation : ValueComponent<Quaternion>, IInScope<Game> { }
}