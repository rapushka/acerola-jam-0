using Code.Component;
using Code.Scope;
using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class HideOnNoMoneyView : BaseListener<Game, Money>
	{
		[SerializeField] private GameObject _target;
		[Header("Tween")]
		[SerializeField] private float _duration = 0.3f;
		[SerializeField] private Vector3 _strength = Vector3.up * 2;
		[SerializeField] private int _vibrato = 5;
		[SerializeField] private float _randomness = 90f;
		[SerializeField] private bool _fadeOut = true;

		public override void OnValueChanged(Entity<Game> entity, Money component)
		{
			_target.transform.DOShakeScale(_duration, _strength, _vibrato, _randomness, _fadeOut);
			_target.SetActive(component.Value > 0);
		}
	}
}