using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.Players
{
	public sealed class EndScoring : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _entities;

		public EndScoring(Contexts contexts, ViewConfig viewConfig) : base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<Scoring>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Scoring>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			var e = _contexts.Get<Game>().CreateEntity();
			e.Add<Waiting, float>(_viewConfig.ScoringDuration);
			e.Add<Callback, Action>(End);
			return;

			void End()
			{
				Debug.Log("end deal");
				_contexts.Get<Game>().CreateEntity().Is<EndDeal>(true);
				_contexts.StopScoring();
				e.Is<Destroyed>(true);
			}
		}
	}
}