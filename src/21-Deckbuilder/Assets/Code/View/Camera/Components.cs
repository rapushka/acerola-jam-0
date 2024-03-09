using Code.Scope;
using Entitas.Generic;

namespace Code.Component
{
	public sealed class Camera : ValueComponent<UnityEngine.Camera>, IInScope<Game>, IUnique { }
}