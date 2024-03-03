using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class ShowOnDealEnd : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;

		public ShowOnDealEnd(Contexts contexts)
		{
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.ShowOnDealEnd>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
				e.Replace<Visible, bool>(true);
		}
	}
}