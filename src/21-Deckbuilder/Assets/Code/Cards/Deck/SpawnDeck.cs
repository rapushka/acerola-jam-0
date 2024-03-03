using System;
using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public class SpawnDeck : IExecuteSystem
	{
		private readonly CardsFactory _cardsFactory;
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _startDeal;

		[Inject]
		public SpawnDeck(Contexts contexts, CardsFactory cardsFactory, HoldersProvider holders)
		{
			_cardsFactory = cardsFactory;
			_holders = holders;

			_startDeal = contexts.GetGroup(Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _startDeal)
			{
				var shuffledDeck = ShuffleDeck();

				var height = 0f;
				var cardHeight = 0.002f;

				foreach (var (cardFace, cardSuit) in shuffledDeck)
					_cardsFactory.Create(cardFace, cardSuit, _holders.Deck, height += cardHeight);
			}
		}

		public IEnumerable<(CardFace, CardSuit)> ShuffleDeck()
		{
			var cardFaces = Enum.GetValues(typeof(CardFace)).Cast<CardFace>();
			var cardSuits = Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();

			var subset = from face in cardFaces
			             from suit in cardSuits
			             select (face, suit);

			return subset.Shuffle();
		}
	}
}