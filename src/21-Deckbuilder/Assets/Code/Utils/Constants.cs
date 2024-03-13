namespace Code
{
	public static class Constants
	{
		public const int StartMoney = 1_000; // TODO: it duplicates here and in config now
		public const int BlackJack = 21;

		public const int MinCardValue = 1;
		public const int AverageCardValue = 6;
		public const int MaxCardValue = 11;

		public static class Prefs
		{
			private const string GameplayPrefix = "Gameplay.";

			public const string MaxSavedWinnings = GameplayPrefix + nameof(MaxSavedWinnings);
			public const string TotalSavedWinnings = GameplayPrefix + nameof(TotalSavedWinnings);
		}
	}
}