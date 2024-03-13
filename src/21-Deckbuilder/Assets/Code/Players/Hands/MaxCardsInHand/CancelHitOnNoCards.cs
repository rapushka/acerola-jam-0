using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class CancelHitOnNoCards : IExecuteSystem
	{
		private readonly HudMediator _hud;
		private readonly DeckProvider _deck;
		private readonly IGroup<Entity<Game>> _entities;

		public CancelHitOnNoCards(Contexts contexts, HudMediator hud, DeckProvider deck)
		{
			_hud = hud;
			_deck = deck;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Hit>());
		}

		public void Execute()
		{
			foreach (var side in _entities.GetEntities())
			{
				if (!_deck.HasCards)
				{
					side.Is<Hit>(false);

					if (side.IsPlayer())
						_hud.Message.ShowError("The deck ran out of cards!");
				}
			}
		}
	}
}