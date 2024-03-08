namespace Code
{
	public static class Constants
	{
		public const int StartMoney = 1_000; // TODO: it duplicates here and in config now

		public const int MaxPointThreshold = 21;
		
		public static class Prefs
		{
			private const string GameplayPrefix = "Gameplay.";

			public const string MaxSavedWinnings = GameplayPrefix + nameof(MaxSavedWinnings);
			public const string TotalSavedWinnings = GameplayPrefix + nameof(TotalSavedWinnings);
		}
	}
}