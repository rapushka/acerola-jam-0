using System;
using System.Collections.Generic;
using System.Linq;

namespace Code
{
	public static class CardUtils
	{
		public static IEnumerable<CardId> ShuffledDeck() => Deck().Shuffle();

		public static IEnumerable<CardId> Deck()
		{
			var cardFaces = Enum.GetValues(typeof(CardFace)).Cast<CardFace>();
			var cardSuits = Suits();

			var subset = from face in cardFaces
			             from suit in cardSuits
			             select new CardId(face, suit);

			return subset;
		}

		public static IEnumerable<CardId> Deck(CardSuit suit)
		{
			var cardFaces = Enum.GetValues(typeof(CardFace)).Cast<CardFace>();
			return cardFaces.Select((face) => new CardId(face, suit));
		}

		public static IEnumerable<CardSuit> Suits() => Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>();
	}
}