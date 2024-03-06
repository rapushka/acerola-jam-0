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
		[SerializeField] private GameObject _turnActionsRoot;
		[SerializeField] private TMP_Text _currentBetTextMesh;

		public int PlayerScore { set => _playerScoreTextMesh.text = value.ToString(); }

		public bool PickCardOptionsVisibility { set => _pickCardRoot.gameObject.SetActive(value); }

		public bool TurnActionsVisibility
		{
			get => _turnActionsRoot.gameObject.activeSelf;
			set => _turnActionsRoot.gameObject.SetActive(value);
		}

		public int CurrentBet { set => _currentBetTextMesh.text = value.ToString(); }

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