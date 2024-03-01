using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DraggableBehaviourBase : EntityBehaviourBase<Game>
	{
		[SerializeField] private BaseListener<Game, Position> _positionView;

		private Entity<Game> _entity;
		public override Entity<Game> Entity => _entity;

		public override void CreateEntity(Contexts contexts)
			=> _entity = contexts.Get<Game>().CreateEntity();

		public override void Initialize()
		{
			Entity
				.Is<Draggable>(true)
				.Add<Position, Vector2>(transform.position)
				.AddListener(_positionView)
				;
		}
	}
}