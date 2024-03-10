using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class EndScoringOnStartDeal : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;

		public EndScoringOnStartDeal(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
				_contexts.StopScoring();
		}
	}
}