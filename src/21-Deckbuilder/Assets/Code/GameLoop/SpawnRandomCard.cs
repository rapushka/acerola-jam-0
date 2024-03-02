using System;
using Code.Component;
using Entitas;
using Entitas.Generic;
using Zenject;
using Random = UnityEngine.Random;
using Sprite = UnityEngine.Sprite;

namespace Code
{
	public class SpawnRandomCard : IInitializeSystem
	{
		private readonly DeckViewConfig _deck;
		private readonly IResourcesProvider _resources;

		[Inject]
		public SpawnRandomCard(Contexts contexts, DeckViewConfig deck, IResourcesProvider resources)
		{
			_deck = deck;
			_resources = resources;
		}

		public void Initialize()
		{
			var cardFace = (CardFace)Random.Range(0, Enum.GetValues(typeof(CardFace)).Length);
			var cardSuit = (CardSuit)Random.Range(0, Enum.GetValues(typeof(CardSuit)).Length);

			var card = _resources.SpawnCardView().Entity;
			card.Add<Face, CardFace>(cardFace);
			card.Add<Suit, CardSuit>(cardSuit);
			card.Replace<Component.Sprite, Sprite>(_deck[cardFace, cardSuit]);
		}
	}
}