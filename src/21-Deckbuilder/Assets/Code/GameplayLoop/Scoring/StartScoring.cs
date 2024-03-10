using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class StartScoring : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;

		public StartScoring(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<EndDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
				_contexts.StartScoring();
		}
	}
}