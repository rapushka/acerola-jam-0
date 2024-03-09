namespace Code
{
	public struct CardId
	{
		public CardFace Face;
		public CardSuit Suit;

		public CardId(CardFace face, CardSuit suit)
		{
			Face = face;
			Suit = suit;
		}

		public static implicit operator CardId((CardFace, CardSuit ) tuple)
			=> new(tuple.Item1, tuple.Item2);

		public static implicit operator (CardFace, CardSuit)(CardId cardId)
			=> (cardId.Face, cardId.Suit);

		public void Deconstruct(out CardFace face, out CardSuit suit)
		{
			face = Face;
			suit = Suit;
		}

		public override string ToString()
		{
			var face = Face.ToString().Replace("Number", string.Empty);
			var sign = Suit.Sign();

			return $"{face} of {sign}";
		}
	}
}