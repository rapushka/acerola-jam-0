using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class DestroyBurnedCard : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;

		public DestroyBurnedCard(Contexts contexts)
		{
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Burned>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
				e.Is<Destroyed>(true);
		}
	}
}