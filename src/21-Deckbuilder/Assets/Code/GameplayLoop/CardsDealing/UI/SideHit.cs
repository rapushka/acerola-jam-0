using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public sealed class SideHit : IExecuteSystem
	{
		private readonly DeckProvider _deck;
		private readonly IGroup<Entity<Game>> _entities;

		public SideHit(Contexts contexts, DeckProvider deck)
		{
			_deck = deck;
			_entities = contexts.GetGroup(Get<Hit>());
		}

		public void Execute()
		{
			foreach (var side in _entities)
			foreach (var card in _deck.TakeCards(1))
				card.Replace<Candidate, Side>(side.Get<Component.Side>().Value);
		}
	}
}