using System;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class BurnCard : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _entities;

		public BurnCard(Contexts contexts, ViewConfig viewConfig)
		{
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<ToBurn>());
			_contexts = contexts;
			_viewConfig = viewConfig;
		}

		public void Execute()
		{
			foreach (var card in _entities.GetEntities())
			{
				card.Is<ToBurn>(false);

				var e = _contexts.Get<Game>().CreateEntity();
				e.Add<Waiting, float>(_viewConfig.BurningDuration);
				e.Add<Callback, Action>(Burn);

				continue;

				void Burn()
				{
					card.Is<Burned>(true);
					e.Is<Destroyed>(true);
				}
			}
		}
	}
}