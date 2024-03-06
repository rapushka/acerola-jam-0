using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public sealed class WinnersGetBank : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _endDeal;
		private readonly IGroup<Entity<Game>> _winners;

		public WinnersGetBank(Contexts contexts)
		{
			_contexts = contexts;
			_endDeal = contexts.GetGroup(Get<EndDeal>());
			_winners = contexts.GetGroup(Get<Winner>());
		}

		private Entity<Game> Bank => _contexts.Get<Game>().Unique.GetEntity<Bank>();

		public void Execute()
		{
			foreach (var _ in _endDeal)
			{
				var winnersCount = _winners.count;
				var bankMoney = Bank.Get<Money>().Value;

				if (winnersCount != 0)
				{
					var sidePrize = bankMoney / winnersCount;

					foreach (var winner in _winners)
						winner.AddValue<Money>(sidePrize);
				}

				Bank.Replace<Money, int>(0);
			}
		}
	}
}