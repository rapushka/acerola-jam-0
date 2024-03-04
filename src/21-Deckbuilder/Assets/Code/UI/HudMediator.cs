using TMPro;
using UnityEngine;

namespace Code
{
	public class HudMediator : MonoBehaviour
	{
		[SerializeField] private TMP_Text _playerScoreTextMesh;
		[SerializeField] private GameObject _dealEndScreenRoot;
		[SerializeField] private TMP_Text _dealEndTextMesh;
		[SerializeField] private GameObject _pickCardRoot;

		public int PlayerScore { set => _playerScoreTextMesh.text = value.ToString(); }

		public bool PickCardVisibility { set => _pickCardRoot.gameObject.SetActive(value); }

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