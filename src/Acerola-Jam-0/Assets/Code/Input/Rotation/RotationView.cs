using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class RotationView : BaseListener<Game, DeltaRotation>
	{
		[SerializeField] private Rigidbody2D _rigidbody;

		public override void OnValueChanged(Entity<Game> entity, DeltaRotation component)
		{
			_rigidbody.SetRotation(_rigidbody.rotation + component.Value);
		}
	}
}