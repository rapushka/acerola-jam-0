using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class CardFaceView : BaseListener<Game>, IRegistrableListener<Game, Face>, IRegistrableListener<Game, Suit>
	{
		[Inject] private readonly DeckViewConfig _deck;

		[SerializeField] private SpriteRenderer _spriteRenderer;

		public Entity<Game> Entity { get; private set; }

		public override void Register(Entity<Game> entity)
		{
			Entity = entity;

			entity.AddListener<Face>(this);
			entity.AddListener<Suit>(this);

			if (entity.Has<Face>() && entity.Has<Suit>())
				OnValueChanged(entity, entity.Get<Face>());
		}

		public void OnValueChanged(Entity<Game> entity, Face component) => OnValueChanged();

		public void OnValueChanged(Entity<Game> entity, Suit component) => OnValueChanged();

		private void OnValueChanged()
			=> _spriteRenderer.sprite = _deck[Entity.Get<Face>().Value, Entity.Get<Suit>().Value];
	}
}