using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Sprite = Code.Component.Sprite;

namespace Code
{
	public class SpriteView : BaseListener<Game, Sprite>
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		public override void OnValueChanged(Entity<Game> entity, Sprite component)
			=> _spriteRenderer.sprite = component.Value;
	}
}