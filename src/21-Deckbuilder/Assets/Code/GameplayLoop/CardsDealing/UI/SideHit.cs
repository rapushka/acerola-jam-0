using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public sealed class SideHit : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;
		private readonly IGroup<Entity<Game>> _deckCards;

		public SideHit(Contexts contexts)
		{
			_entities = contexts.GetGroup(Get<Hit>());
			_deckCards = contexts.GetGroup(AllOf(Get<Card>()).NoneOf(Get<HeldBy>()));
		}

		public void Execute()
		{
			foreach (var side in _entities)
			foreach (var card in _deckCards.GetEntities().TakeLast(1))
				card.Replace<HeldBy, Side>(side.Get<Component.Side>().Value);
		}
	}
}