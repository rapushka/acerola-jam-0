using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class ReflectionBehaviour : EntityBehaviourBase<Game>
	{
		[SerializeField] private BaseListener<Game, VectorFromLight> _view;

		private Entity<Game> _entity;
		public override Entity<Game> Entity => _entity;

		public override void CreateEntity(Contexts contexts)
			=> _entity = contexts.Get<Game>().CreateEntity();

		public override void Initialize()
		{
			Entity
				.Add<DebugName, string>("Reflection")
				.Is<Component.Reflection>(true)
				.AddListener(_view)
				;
		}
	}
}