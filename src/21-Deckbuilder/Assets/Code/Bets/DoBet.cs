using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class DoBet : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;

		public DoBet(Contexts contexts) : base(contexts.Get<Game>())
		{
			_contexts = contexts;
		}

		private Entity<Game> Bank => _contexts.Get<Game>().Unique.GetEntity<Bank>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<Bet>());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Bet>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in entities)
			{
				var bet = Bank.Get<CurrentBet>().Value;
				Bank.Replace<MinBet, int>(bet);

				var sideMoney = side.Get<Money>().Value;
				if (bet >= sideMoney)
				{
					side.Is<AllIn>(true);
					side.Replace<Money, int>(0);
					Bank.AddValue<Money>(sideMoney);
				}
				else
				{
					side.SubtractValue<Money>(bet);
					Bank.AddValue<Money>(bet);
				}

				side.Is<Bet>(false);
				side.Is<TurnEnded>(true);
			}
		}
	}
}