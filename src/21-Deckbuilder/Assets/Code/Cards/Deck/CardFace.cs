namespace Code
{
	public enum CardFace
	{
		Number2,
		Number3,
		Number4,
		Number5,
		Number6,
		Number7,
		Number8,
		Number9,
		Number10,
		Jack,
		Queen,
		King,
		Ace,
	}

	public static class CardFaceExtensions
	{
		public static int GetPoints(this CardFace @this)
			=> @this switch
			{
				CardFace.Ace                                     => 11,
				CardFace.Jack or CardFace.Queen or CardFace.King => 10,
				_                                                => (int)@this + 2,
			};
	}
}