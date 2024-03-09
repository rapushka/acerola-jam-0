using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class CancelHitOnMaxCardsInHand : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;
		private readonly IGroup<Entity<Game>> _entities;

		public CancelHitOnMaxCardsInHand(Contexts contexts, HudMediator hud)
		{
			_contexts = contexts;
			_hud = hud;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Hit>());
		}

		private Entity<Game> Rules => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		public void Execute()
		{
			foreach (var side in _entities.GetEntities())
			{
				var cardsInHand = side.GetCards();

				if (cardsInHand.Count() >= Rules.Get<MaxCardsInHand>().Value)
				{
					side.Is<Hit>(false);

					if (side.IsPlayer())
						_hud.Message.ShowError("You already have max count of cards in your hand!");
				}
			}
		}
	}
}