using Code.Component;
using Code.Scope;
using DG.Tweening;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class BurnCardView : BaseListener<Game, ToBurn>
	{
		[SerializeField] private Renderer[] _renderers;
		[SerializeField] private GameObject[] _objectsToDisable;
		[SerializeField] private Material _burnMaterial;
		[SerializeField] private float _waitBeforeBurn;
		[SerializeField] private float _burnDuration;

		private static readonly int ProgressID = Shader.PropertyToID("_Progress");

		private float Progress
		{
			get => _burnMaterial.GetFloat(ProgressID);
			set => _burnMaterial.SetFloat(ProgressID, value);
		}

		public override void OnValueChanged(Entity<Game> entity, ToBurn component)
		{
			if (!entity.Is<ToBurn>())
				return;

			// ReSharper disable once LocalVariableHidesMember – it hides obsolete property
			foreach (var renderer in _renderers)
				renderer.sharedMaterial = _burnMaterial;

			foreach (var target in _objectsToDisable)
				target.SetActive(false);

			const float startValue = 1f;
			const float endValue = 0f;

			Progress = startValue;
			DOTween.Sequence()
			       .AppendInterval(_waitBeforeBurn)
			       .Append(DOTween.To(() => Progress, (x) => Progress = x, endValue, _burnDuration))
			       .Play();
		}
	}
}