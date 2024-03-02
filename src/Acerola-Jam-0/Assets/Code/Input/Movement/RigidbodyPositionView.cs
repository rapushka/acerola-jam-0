using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class RigidbodyPositionView : BaseListener<Game, Position>
	{
		[SerializeField] private Rigidbody2D _rigidbody2D;

		public override void OnValueChanged(Entity<Game> entity, Position component)
			=> _rigidbody2D.MovePosition(component.Value);
	}
}