using Code.Component;
using Code.Scope;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class MoneyView : BaseListener<Game, Money>
	{
		[SerializeField] private TMP_Text _textMesh;

		public override void OnValueChanged(Entity<Game> entity, Money component)
			=> _textMesh.text = component.Value.ToString();
	}
}