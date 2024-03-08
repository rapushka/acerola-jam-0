using Code.Component;
using Code.Scope;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class ShadowCardView : BaseListener<Game, Points>
	{
		[SerializeField] private TMP_Text[] _textMeshes;

		public override void OnValueChanged(Entity<Game> entity, Points component)
		{
			var delta = component.Value;

			foreach (var textMesh in _textMeshes)
				textMesh.text = delta > 0 ? $"+{delta}" : delta.ToString();
		}
	}
}