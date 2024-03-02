using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using Zenject;

namespace Code
{
	public class SpawnDeck : IInitializeSystem
	{
		private readonly CardsFactory _cardsFactory;
		private readonly HoldersProvider _holders;

		[Inject]
		public SpawnDeck(CardsFactory cardsFactory, HoldersProvider holders)
		{
			_cardsFactory = cardsFactory;
			_holders = holders;
		}

		public void Initialize()
		{
			var shuffledDeck = ShuffleDeck();

			var height = 0f;
			var cardHeight = 0.002f;

			foreach (var (cardFace, cardSuit) in shuffledDeck)
				_cardsFactory.Create(cardFace, cardSuit, _holders.Deck, height += cardHeight);
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