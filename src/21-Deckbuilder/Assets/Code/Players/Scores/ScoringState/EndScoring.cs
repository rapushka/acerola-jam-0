using System;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.Players
{
	public sealed class EndScoring : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _entities;

		public EndScoring(Contexts contexts, ViewConfig viewConfig)
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Scoring>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			{
				var e = _contexts.Get<Game>().CreateEntity();
				e.Add<Waiting, float>(_viewConfig.ScoringDuration);
				e.Add<Callback, Action>(End);
				continue;

				void End()
				{
					_contexts.Get<Game>().CreateEntity().Is<EndDeal>(true);
					_contexts.StopScoring();
					e.Is<Destroyed>(true);
				}
			}
		}
	}
}