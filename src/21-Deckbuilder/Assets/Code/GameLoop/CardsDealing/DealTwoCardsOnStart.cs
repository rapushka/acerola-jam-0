using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public class DealTwoCardsOnStart : IInitializeSystem
	{
		private readonly IGroup<Entity<Game>> _deckCards;

		[Inject]
		public DealTwoCardsOnStart(Contexts contexts)
		{
			_deckCards = contexts.GetGroup(AllOf(Get<Card>()).NoneOf(Get<HeldBy>()));
		}

		public void Initialize()
		{
			foreach (var card in _deckCards.GetEntities().TakeLast(2))
				card.Add<HeldBy, Side>(Side.Player);

			foreach (var card in _deckCards.GetEntities().TakeLast(2))
				card.Add<HeldBy, Side>(Side.Dealer);
		}
	}
}