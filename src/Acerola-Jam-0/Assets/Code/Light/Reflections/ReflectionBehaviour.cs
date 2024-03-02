using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class ReflectionBehaviour : EntityBehaviourBase<Game>
	{
		private Entity<Game> _entity;
		public override Entity<Game> Entity => _entity;

		public override void CreateEntity(Contexts contexts)
			=> _entity = contexts.Get<Game>().CreateEntity();

		public override void Initialize()
		{
			Entity
				.Add<DebugName, string>("Reflection")
				.Is<Component.Reflection>(true)
				;
		}
	}
}