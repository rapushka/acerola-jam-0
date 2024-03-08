using System;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class DoneCardActions : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _entities;

		public DoneCardActions(Contexts contexts, ViewConfig viewConfig)
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
			_entities = contexts.GetGroup(AnyOf(Get<BurnCandidate>(), Get<TakeCandidate>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var side = _contexts.Get<Game>().Unique.GetEntity<CurrentTurn>();
				if (e.Is<BurnCandidate>())
				{
					side.Add<Waiting, float>(_viewConfig.BurningDuration);
					side.Add<Callback, Action>(DoEndTurn);
				}
				else
				{
					DoEndTurn();
				}

				continue;

				void DoEndTurn() => side.Is<CardActionDone>(true);
			}
		}
	}
}