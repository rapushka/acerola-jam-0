using TMPro;
using UnityEngine;

namespace Code
{
	public class HudMediator : MonoBehaviour
	{
		[SerializeField] private TMP_Text _playerScoreTextMesh;

		public int PlayerScore { set => _playerScoreTextMesh.text = value.ToString(); }
	}
}