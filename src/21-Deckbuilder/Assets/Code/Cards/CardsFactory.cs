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
			var card = _resources.SpawnCardView(parent, height).Entity;
			card.Add<Face, CardFace>(cardFace);
			card.Add<Suit, CardSuit>(cardSuit);

			return card;
		}
	}
}