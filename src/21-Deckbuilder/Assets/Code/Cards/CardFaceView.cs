using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class CardFaceView : BaseListener<Game, Face>
	{
		[Inject] private readonly DeckViewConfig _deck;

		[SerializeField] private SpriteRenderer _spriteRenderer;

		public override void OnValueChanged(Entity<Game> entity, Face component)
		{
			_spriteRenderer.sprite = _deck[Card.Face, Card.Suit];
		}

		private CardId Card => Entity.Get<Face>().Value;
	}
}