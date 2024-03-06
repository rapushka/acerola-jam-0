using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class AiBet : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly AiConfig _config;

		public AiBet(Contexts contexts, AiConfig config)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_config = config;
		}

		private Entity<Game> Bank => _contexts.Get<Game>().Unique.GetEntity<Bank>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<CardActionDone>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Ai>() && entity.Is<CardActionDone>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
			{
				if (Random.value >= _config.RaiseBetChance)
				{
					Bank.AddValue<CurrentBet>(_config.RaiseBetStep);
					e.Is<Bet>(true);
					continue;
				}

				if (Random.value >= _config.BetChance)
				{
					e.Is<Bet>(true);
					continue;
				}

				e.Is<Pass>(true);
			}
		}
	}
}