using Code.Component;
using Code.System;
using Entitas.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
	public abstract class ButtonBase : MonoBehaviour
	{
		[SerializeField] private Button _button;

		private void OnEnable() => _button.onClick.AddListener(OnClick);

		private void OnDisable() => _button.onClick.RemoveListener(OnClick);

		protected abstract void OnClick();

		private void Update()
		{
			_button.enabled = Contexts.Instance.GetPlayer().Is<CurrentTurn>();
		}
	}
}