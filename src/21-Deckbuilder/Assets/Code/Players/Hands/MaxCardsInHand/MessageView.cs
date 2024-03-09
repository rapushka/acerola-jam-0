using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code
{
	public class MessageView : MonoBehaviour
	{
		[SerializeField] private TMP_Text _textMesh;

		[Header("Tweaks")]
		[SerializeField] private float _fadeIn;
		[SerializeField] private float _fadeOut;

		[Header("Shake")]
		[SerializeField] private float _strength;
		[SerializeField] private float _duration;
		[SerializeField] private int _vibrato = 10;
		[SerializeField] private int _randomness = 90;

		[Header("Colors")]
		[SerializeField] private Color _errorColor;

		private Sequence _sequence;

		public void ShowError(string message)
		{
			_sequence?.Kill();

			_textMesh.color = _errorColor;
			_textMesh.text = message;

			_sequence = DOTween.Sequence()
			                   .Append(_textMesh.DOFade(1f, _fadeIn))
			                   .Append(Shake())
			                   .Append(_textMesh.DOFade(0f, _fadeOut))
			                   .Play();
		}

		private Tweener Shake()
			=> _textMesh.transform.DOShakePosition(_duration, _strength, _vibrato, _randomness);
	}
}