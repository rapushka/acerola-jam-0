using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class PutSomeCardOnTopOfTheDeck : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly DeckProvider _deckProvider;
		private readonly IGroup<Entity<Game>> _entities;

		private int _counter = 1;

		public PutSomeCardOnTopOfTheDeck(Contexts contexts, DeckProvider deckProvider)
		{
			_contexts = contexts;
			_deckProvider = deckProvider;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			{
				PutFirst((CardFace.Ace, CardSuit.Hearts));
				PutFirst((CardFace.Jack, CardSuit.Diamonds));
			}
		}

		private void PutFirst(CardId targetCard)
		{
			var targetCards = _contexts.Get<Game>().GetIndex<Face, CardId>().GetEntities(targetCard);

			foreach (var card in targetCards)
				card.Replace<Order, int>(_deckProvider.Count + _counter++);
		}
	}
}