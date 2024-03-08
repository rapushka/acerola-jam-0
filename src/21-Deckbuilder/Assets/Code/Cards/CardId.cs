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

		public override string ToString()
		{
			var face = Face.ToString().Replace("Number", string.Empty);
			var sign = Suit.Sign();

			return $"{face} of {sign}";
		}
	}
}