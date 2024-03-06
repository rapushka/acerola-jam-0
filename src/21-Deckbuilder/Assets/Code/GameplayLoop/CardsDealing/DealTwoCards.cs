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
		private readonly DeckProvider _deck;
		private readonly IGroup<Entity<Game>> _deckCards;
		private readonly IGroup<Entity<Game>> _startDeal;

		[Inject]
		public DealTwoCards(Contexts contexts, DeckProvider deck)
		{
			_deck = deck;
			_startDeal = contexts.GetGroup(Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _startDeal)
			{
				foreach (var card in _deck.TakeCards(2))
					card.Add<HeldBy, Side>(Side.Player);

				foreach (var card in _deck.TakeCards(2))
					card.Add<HeldBy, Side>(Side.Dealer);
			}
		}
	}
}