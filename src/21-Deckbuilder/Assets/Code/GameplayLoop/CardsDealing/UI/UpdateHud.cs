using System.Linq;
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
		private readonly IGroup<Entity<Game>> _timers;

		[Inject]
		public UpdateHud(Contexts contexts, HudMediator hud)
		{
			_contexts = contexts;
			_hud = hud;
			_timers = contexts.GetGroup(ScopeMatcher<Game>.Get<Waiting>());
		}

		public void Execute()
		{
			var isOurTurn = _contexts.GetPlayer().Is<CurrentTurn>();
			var waitingForSomething = _timers.GetEntities().Any();

			if (!isOurTurn || waitingForSomething)
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