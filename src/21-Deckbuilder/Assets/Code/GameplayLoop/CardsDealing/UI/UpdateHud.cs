using Code.Component;
using Code.Scope;
using Code.System;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class UpdateHud : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;

		[Inject]
		public UpdateHud(Contexts contexts, HudMediator hud)
		{
			_contexts = contexts;
			_hud = hud;
		}

		public void Execute()
		{
			var isOurTurn = _contexts.GetPlayer().Is<CurrentTurn>();

			if (!isOurTurn)
			{
				_hud.TurnActionsVisibility = false;
				_hud.PickCardOptionsVisibility = false;
				return;
			}

			var hasCandidate = _contexts.Get<Game>().Unique.Has<Candidate>();
			_hud.TurnActionsVisibility = !hasCandidate;
			_hud.PickCardOptionsVisibility = hasCandidate;
		}
	}
}