using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class BurnCard : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;

		public BurnCard(Contexts contexts, ViewConfig viewConfig)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<ToBurn>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<ToBurn>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var card in entities)
			{
				var e = _contexts.Get<Game>().CreateEntity();
				e.Add<Waiting, float>(_viewConfig.BurningDuration);
				e.Add<Callback, Action>(Burn);

				continue;

				void Burn()
				{
					card.Is<ToBurn>(false);
					card.Is<Burned>(true);

					e.Is<Destroyed>(true);
				}
			}
		}
	}
}