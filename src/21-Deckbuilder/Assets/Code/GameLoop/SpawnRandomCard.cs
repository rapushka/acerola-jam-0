using System;
using Code.Component;
using Entitas;
using Zenject;
using Random = UnityEngine.Random;

namespace Code
{
	public class SpawnRandomCard : IInitializeSystem
	{
		private readonly IResourcesProvider _resources;

		[Inject]
		public SpawnRandomCard(IResourcesProvider resources)
		{
			_resources = resources;
		}

		public void Initialize()
		{
			var cardFace = (CardFace)Random.Range(0, Enum.GetValues(typeof(CardFace)).Length);
			var cardSuit = (CardSuit)Random.Range(0, Enum.GetValues(typeof(CardSuit)).Length);

			var card = _resources.SpawnCardView().Entity;
			card.Add<Face, CardFace>(cardFace);
			card.Add<Suit, CardSuit>(cardSuit);
			// card.Replace<Component.Sprite, Sprite>(_deck[cardFace, cardSuit]);
		}
	}
}