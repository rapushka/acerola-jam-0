using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public class DealTwoCards : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _deckCards;
		private readonly IGroup<Entity<Game>> _startDeal;

		[Inject]
		public DealTwoCards(Contexts contexts)
		{
			_deckCards = contexts.GetGroup(AllOf(Get<Card>()).NoneOf(Get<HeldBy>()));
			_startDeal = contexts.GetGroup(Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _startDeal)
			{
				foreach (var card in _deckCards.GetEntities().TakeLast(2))
					card.Add<HeldBy, Side>(Side.Player);

				foreach (var card in _deckCards.GetEntities().TakeLast(2))
					card.Add<HeldBy, Side>(Side.Dealer);
			}
		}
	}
}