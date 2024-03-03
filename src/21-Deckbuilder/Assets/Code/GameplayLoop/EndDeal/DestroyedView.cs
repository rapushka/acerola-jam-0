using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DestroyedView : BaseListener<Game, Destroyed>
	{
		[SerializeField] private GameObject _target;

		public override void OnValueChanged(Entity<Game> entity, Destroyed component) => Destroy(_target);
	}
}