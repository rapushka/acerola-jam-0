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
		[Header("Place a Bet window")]
		[SerializeField] private GameObject _placeBetWindowRoot;
		[SerializeField] private TMP_Text _currentBetTextMesh;
		[SerializeField] private TMP_Text _minBetTextMesh;
		[SerializeField] private TMP_Text _statusTextMesh;
		[SerializeField] private GameObject _looseScreenRoot;
		[SerializeField] private GameObject _winScreenRoot;

		public int PlayerScore { set => _playerScoreTextMesh.text = value.ToString(); }

		public bool PickCardOptionsVisibility { set => _pickCardRoot.gameObject.SetActive(value); }

		public bool TurnActionsVisibility
		{
			get => _turnActionsRoot.gameObject.activeSelf;
			set => _turnActionsRoot.gameObject.SetActive(value);
		}

		public bool IsPlaceBetWindowVisible
		{
			get => _placeBetWindowRoot.gameObject.activeSelf;
			set => _placeBetWindowRoot.gameObject.SetActive(value);
		}

		public int CurrentBet { set => _currentBetTextMesh.text = value.ToString(); }
		public int MinBet     { set => _minBetTextMesh.text = $"Min Bet: {value}"; }

		public  string StatusText        { set => _statusTextMesh.text = value; }
		private bool   DealEndVisibility { set => _dealEndScreenRoot.gameObject.SetActive(value); }

		public void ShowDealEndScreen(string message)
		{
			_dealEndTextMesh.text = message;
			DealEndVisibility = true;
		}

		public void HideDealEndScreen() => DealEndVisibility = false;

		public void ShowLooseScreen()
		{
			HideAll();
			_looseScreenRoot.SetActive(true);
		}

		public void ShowWinScreen()
		{
			HideAll();
			_winScreenRoot.SetActive(true);
		}

		public void HideWinAndLooseScreens()
		{
			_winScreenRoot.SetActive(false);
			_looseScreenRoot.SetActive(false);
		}

		private void HideAll()
		{
			PickCardOptionsVisibility = false;
			TurnActionsVisibility = false;
			IsPlaceBetWindowVisible = false;
			DealEndVisibility = false;
		}
	}
}