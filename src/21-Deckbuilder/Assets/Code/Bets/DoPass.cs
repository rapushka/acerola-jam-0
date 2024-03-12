using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DoPass : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;

		public DoPass(Contexts contexts) : base(contexts.Get<Game>())
		{
			_contexts = contexts;
		}

		private Entity<Game> Bank => _contexts.Get<Game>().Unique.GetEntity<Bank>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<Pass>());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Pass>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in entities)
			{
				var minBet = Bank.Get<MinBet>().Value;
				Bank.Replace<CurrentBet, int>(minBet);

				side.Is<Bet>(false);
				side.Is<Stand>(true); // TODO: is it?
				side.Is<TurnEnded>(true);
				side.Is<CardActionDone>(false);
			}
		}
	}
}