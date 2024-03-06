using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class SidesKeepPlaying : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _sides;
		private readonly IGroup<Entity<Game>> _entities;

		public SidesKeepPlaying(Contexts contexts)
		{
			_entities = contexts.GetGroup(Get<StartDeal>());
			_sides = contexts.GetGroup(Get<Component.Side>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			foreach (var side in _sides)
			{
				side.Is<Pass>(false);
				side.Is<TurnEnded>(false);
				side.Is<Stand>(false);
				side.Is<Winner>(false);
			}
		}
	}
}