using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class ShowOnDealEnd : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;
		private readonly IGroup<Entity<Game>> _endDeal;

		public ShowOnDealEnd(Contexts contexts)
		{
			_endDeal = contexts.GetGroup(Get<Component.EndDeal>());
			_entities = contexts.GetGroup(Get<Component.ShowOnDealEnd>());
		}

		public void Execute()
		{
			foreach (var _ in _endDeal)
			foreach (var e in _entities)
				e.Replace<Visible, bool>(true);
		}
	}
}