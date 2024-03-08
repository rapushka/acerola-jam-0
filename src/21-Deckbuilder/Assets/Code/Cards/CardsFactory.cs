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
		private readonly HoldersProvider _holders;

		[Inject]
		public CardsFactory(IResourcesProvider resources, HoldersProvider holders)
		{
			_resources = resources;
			_holders = holders;
		}

		public Entity<Game> Create(CardFace face, CardSuit suit, float height, int order)
		{
			var cardView = _resources.SpawnCardView(_holders.Deck, height);
			var card = cardView.Entity;
			card.Is<Card>(true);
			card.Add<DebugName, string>("card");
			card.Add<Face, CardId>(new CardId(face, suit));
			card.Add<Position, Vector3>(cardView.transform.position);
			card.Add<Rotation, Quaternion>(cardView.transform.rotation);
			card.Add<Points, int>(face.GetPoints());
			card.Add<Order, int>(order);

			return card;
		}

		public Entity<Game> CreateShadowCard(Side owner)
		{
			var parent = _holders[owner].ShadowCardSpawn;

			var cardView = _resources.SpawnShadowCardView(parent);
			var card = cardView.Entity;
			card.Add<DebugName, string>("shadow card");
			card.Is<Card>(true);
			card.Add<ShadowCard, Side>(owner);
			card.Add<Position, Vector3>(cardView.transform.position);
			card.Add<Rotation, Quaternion>(cardView.transform.rotation);
			card.Add<Points, int>(0);
			card.Add<Order, int>(int.MaxValue);
			card.Add<HeldBy, Side>(owner);

			return card;
		}
	}
}