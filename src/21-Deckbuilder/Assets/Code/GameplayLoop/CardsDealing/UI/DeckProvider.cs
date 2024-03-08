using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public class DeckProvider
	{
		private readonly IGroup<Entity<Game>> _deckCards;

		[Inject]
		public DeckProvider(Contexts contexts)
		{
			_deckCards = contexts.GetGroup(AllOf(Get<Card>()).NoneOf(Get<HeldBy>(), Get<ToBurn>(), Get<Burned>()));
		}

		private IOrderedEnumerable<Entity<Game>> Deck
			=> _deckCards.GetEntities().OrderByDescending((c) => c.Get<Order>().Value);

		public Entity<Game> TopCard => TakeCards(1).Single();

		public IEnumerable<Entity<Game>> TakeCards(int count)
			=> Deck.Take(count);
	}
}