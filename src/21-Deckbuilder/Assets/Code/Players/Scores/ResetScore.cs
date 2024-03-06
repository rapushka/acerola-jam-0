using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.Players
{
	public sealed class ResetScore : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;
		private readonly IGroup<Entity<Game>> _sides;

		public ResetScore(Contexts contexts)
		{
			_entities = contexts.GetGroup(Get<StartDeal>());
			_sides = contexts.GetGroup(Get<Score>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			foreach (var e in _sides)
				e.Replace<Score, int>(0);
		}
	}
}