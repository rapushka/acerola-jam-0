namespace Code
{
	public class CardId
	{
		public CardFace Face;
		public CardSuit Suit;

		public CardId(CardFace face, CardSuit suit)
		{
			Face = face;
			Suit = suit;
		}

		public override string ToString()
		{
			var face = Face.ToString().Replace("Number", string.Empty);
			var sign = Suit.Sign();

			return $"{face} of {sign}";
		}
	}
}