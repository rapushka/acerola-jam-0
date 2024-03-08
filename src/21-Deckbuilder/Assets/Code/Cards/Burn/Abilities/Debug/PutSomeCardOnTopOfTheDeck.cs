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

		public PutSomeCardOnTopOfTheDeck(Contexts contexts, DeckProvider deckProvider)
		{
			_contexts = contexts;
			_deckProvider = deckProvider;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		private static CardId TargetCard => new(CardFace.Ace, CardSuit.Spades);

		public void Execute()
		{
			foreach (var _ in _entities)
				Put();
		}

		private void Put()
		{
			var targetCards = _contexts.Get<Game>().GetIndex<Face, CardId>().GetEntities(TargetCard);

			foreach (var card in targetCards)
				card.Replace<Order, int>(_deckProvider.Count + 1);
		}
	}
}