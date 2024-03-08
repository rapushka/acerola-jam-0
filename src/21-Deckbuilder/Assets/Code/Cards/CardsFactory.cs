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

		public Entity<Game> Create(CardFace face, CardSuit suit, Transform parent, float height, int order)
		{
			var cardView = _resources.SpawnCardView(parent, height);
			var card = cardView.Entity;
			card.Is<Card>(true);
			card.Add<Face, CardId>(new CardId(face, suit));
			card.Add<Position, Vector3>(cardView.transform.position);
			card.Add<Rotation, Quaternion>(cardView.transform.rotation);
			card.Add<Points, int>(face.GetPoints());
			card.Add<Order, int>(order);

			return card;
		}
	}
}