using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class CardsFactory
	{
		private readonly IResourcesProvider _resources;

		[Inject]
		public CardsFactory(IResourcesProvider resources)
		{
			_resources = resources;
		}

		public Entity<Game> Create(CardFace cardFace, CardSuit cardSuit, Transform parent, float height)
		{
			var cardView = _resources.SpawnCardView(parent, height);
			var card = cardView.Entity;
			card.Is<Card>(true);
			card.Add<Face, CardFace>(cardFace);
			card.Add<Suit, CardSuit>(cardSuit);
			card.Add<Position, Vector3>(cardView.transform.position);
			card.Add<Rotation, Quaternion>(cardView.transform.rotation);

			return card;
		}
	}
}