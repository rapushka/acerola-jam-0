using Code.Component;
using Code.Scope;
using Entitas.Generic;
using TMPro;
using UnityEngine;

namespace Code
{
	public class StandSign : MonoBehaviour
	{
		[SerializeField] private Color _disabledColor;
		[SerializeField] private Color _standColor;
		[SerializeField] private Color _allInColor;
		[SerializeField] private Color _passColor;
		[SerializeField] private TMP_Text _textMesh;

		public void UpdateState(Entity<Game> dealer)
		{
			(_textMesh.color, _textMesh.text) =
				dealer.Is<AllIn>()   ? (_allInColor, "All-In")
				: dealer.Is<Pass>()  ? (_passColor, "Pass")
				: dealer.Is<Stand>() ? (_standColor, "Stand")
				                       : (_disabledColor, "Stand");
		}
	}
}