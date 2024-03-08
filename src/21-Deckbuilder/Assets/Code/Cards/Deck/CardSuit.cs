using System;

namespace Code
{
	public enum CardSuit
	{
		/// <summary> ♣ </summary>
		Clubs,
		/// <summary> ♦ </summary>
		Diamonds,
		/// <summary> ♥ </summary>
		Hearts,
		/// <summary> ♠ </summary>
		Spades,
	}

	public static class CardSuitExtensions
	{
		public static string Sign(this CardSuit @this)
			=> @this switch
			{
				CardSuit.Clubs    => "♣",
				CardSuit.Diamonds => "♦",
				CardSuit.Hearts   => "♥",
				CardSuit.Spades   => "♠",
				_                 => throw new ArgumentOutOfRangeException(nameof(@this), @this, null)
			};
	}
}