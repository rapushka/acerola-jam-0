using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public abstract class ButtonBase : MonoBehaviour
	{
		[SerializeField] private Button _button;

		protected Button Button => _button;

		private void OnEnable() => Button.onClick.AddListener(OnClick);

		private void OnDisable() => Button.onClick.RemoveListener(OnClick);

		protected abstract void OnClick();
	}
}