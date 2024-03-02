using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class ReflectionView : BaseListener<Game, VectorFromLight>
	{
		[SerializeField] private Reflection _reflection;

		public override void OnValueChanged(Entity<Game> entity, VectorFromLight component)
		{
			_reflection.UpdateVertexes(component.Value);
		}
	}
}