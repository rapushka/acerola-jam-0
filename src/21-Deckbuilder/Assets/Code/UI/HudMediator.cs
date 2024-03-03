using TMPro;
using UnityEngine;

namespace Code
{
	public class HudMediator : MonoBehaviour
	{
		[SerializeField] private TMP_Text _playerScoreTextMesh;
		[SerializeField] private GameObject _dealEndScreenRoot;
		[SerializeField] private TMP_Text _dealEndTextMesh;

		public int PlayerScore { set => _playerScoreTextMesh.text = value.ToString(); }

		private bool DealEndVisibility { set => _dealEndScreenRoot.gameObject.SetActive(value); }

		public void ShowDealEndScreen(string message)
		{
			_dealEndTextMesh.text = message;
			DealEndVisibility = true;
		}

		public void HideDealEndScreen()
		{
			DealEndVisibility = false;
		}
	}
}