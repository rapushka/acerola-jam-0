using Code.Component;
using Code.System;
using Entitas.Generic;
using UnityEditor;
using UnityEngine;

namespace Code
{
	public class KeepMoneyAndLeaveButton : ToMainMenuButton
	{
		private static int MaxSavedWinnings
		{
			get => PlayerPrefs.GetInt(Constants.Prefs.MaxSavedWinnings, 0);
			set => PlayerPrefs.SetInt(Constants.Prefs.MaxSavedWinnings, value);
		}

		private static int TotalSavedWinnings
		{
			get => PlayerPrefs.GetInt(Constants.Prefs.TotalSavedWinnings, 0);
			set => PlayerPrefs.SetInt(Constants.Prefs.TotalSavedWinnings, value);
		}

		protected override void OnClick()
		{
			SaveWinnings();
			base.OnClick();
		}

		private static void SaveWinnings()
		{
			var player = Contexts.Instance.GetPlayer();

			if (player is null)
				return;

			var winnings = player.Get<Money>().Value - Constants.StartMoney;

			if (MaxSavedWinnings < winnings)
				MaxSavedWinnings = winnings;

			TotalSavedWinnings += winnings;
			PlayerPrefs.Save();
		}

#if UNITY_EDITOR
		[MenuItem("+375/ResetProgress")]
		public static void ResetProgress()
		{
			PlayerPrefs.DeleteKey(Constants.Prefs.TotalSavedWinnings);
			PlayerPrefs.DeleteKey(Constants.Prefs.MaxSavedWinnings);
		}
#endif
	}
}