using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public sealed class PutSomeCardOnTopOfTheDeck : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly DeckProvider _deckProvider;
		private readonly IGroup<Entity<Game>> _entities;

		public PutSomeCardOnTopOfTheDeck(Contexts contexts, DeckProvider deckProvider)
		{
			_contexts = contexts;
			_deckProvider = deckProvider;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
				Put();
		}

		private void Put()
		{
			var cardID = new CardId(CardFace.Ace, CardSuit.Spades);
			Debug.Log($"cardID = {cardID}");

			var targetCards = _contexts.Get<Game>().GetIndex<Face, CardId>().GetEntities(cardID);
			Debug.Log($"targetCards.Count = {targetCards.Count}");

			foreach (var card in targetCards)
				card.Replace<Order, int>(_deckProvider.Count + 1);
		}
	}
}