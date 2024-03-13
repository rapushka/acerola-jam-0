using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class SortingOrderView : BaseListener<Game, SortingOrder>
	{
		[SerializeField] private List<SpriteRenderer> _spriteRenderers;

		public override void OnValueChanged(Entity<Game> entity, SortingOrder component)
		{
			foreach (var spriteRenderer in _spriteRenderers)
				spriteRenderer.sortingOrder = component.Value;
		}
	}
}