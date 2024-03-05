using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class EndTurn : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;

		public EndTurn(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(AnyOf(Get<BurnCandidate>(), Get<TakeCandidate>()));
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			{
				var side = _contexts.Get<Game>().Unique.GetEntity<CurrentTurn>();
				side.Is<Component.EndTurn>(true);
			}
		}
	}
}