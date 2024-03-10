using TMPro;
using UnityEngine;

namespace Code
{
	public class WinningsView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _textMesh;

		private static int MaxWinnings   => PlayerPrefs.GetInt(Constants.Prefs.MaxSavedWinnings, 0);
		private static int TotalWinnings => PlayerPrefs.GetInt(Constants.Prefs.TotalSavedWinnings, 0);

		private void Start() => _textMesh.text = $"Winnings\nMax: {MaxWinnings}\nTotal: {TotalWinnings}";
	}
}