using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class LensBehaviour : EntityBehaviourBase
	{
		private Entity<Game> _entity;

		public override void CreateEntity(Contexts contexts)
			=> _entity = contexts.Get<Game>().CreateEntity();

		public override void Initialize()
		{
			_entity
				.Is<Lens>(true)
				.Is<Draggable>(true)
				;
		}
	}
}