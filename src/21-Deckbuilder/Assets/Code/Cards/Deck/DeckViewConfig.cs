using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
	[CreateAssetMenu(fileName = "Deck", menuName = "+375/Deck", order = -100)]
	public class DeckViewConfig : ScriptableObject
	{
		[SerializeField] private List<CardViewConfig> _views;

		public Dictionary<(CardFace, CardSuit), Sprite> Views
			=> _views.ToDictionary((c) => (c.Face, c.Suit), (c) => c.Sprite);

		public Sprite this[CardFace face, CardSuit suit] => Views[(face, suit)];
	}

	[Serializable]
	public class CardViewConfig
	{
		[field: SerializeField] public CardFace Face   { get; private set; }
		[field: SerializeField] public CardSuit Suit   { get; private set; }
		[field: SerializeField] public Sprite   Sprite { get; private set; }
	}
}