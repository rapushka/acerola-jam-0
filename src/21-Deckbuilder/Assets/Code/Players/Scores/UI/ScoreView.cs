using TMPro;
using UnityEngine;

namespace Code
{
	public class ScoreView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _textMesh;
		[SerializeField] private Color _bustedColor;

		private Color _defaultColor;

		private void Start() => _defaultColor = _textMesh.color;

		public void UpdateValue(int score, bool isBusted)
		{
			_textMesh.text = score.ToString();
			_textMesh.color = isBusted ? _bustedColor : _defaultColor;

			_textMesh.gameObject.SetActive(score != 0);
		}
	}
}