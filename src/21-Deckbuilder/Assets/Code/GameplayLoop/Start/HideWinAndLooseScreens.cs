using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public class HideWinAndLooseScreens : IExecuteSystem
	{
		private readonly HudMediator _hud;
		private readonly IGroup<Entity<Game>> _entities;

		public HideWinAndLooseScreens(Contexts contexts, HudMediator hud)
		{
			_hud = hud;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
				_hud.HideWinAndLooseScreens();
		}
	}
}