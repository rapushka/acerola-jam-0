using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class FlipDealerCardsOnDealEnd : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;
		private readonly IGroup<Entity<Game>> _cards;

		public FlipDealerCardsOnDealEnd(Contexts contexts)
		{
			_entities = contexts.GetGroup(Get<Component.EndDeal>());
			_cards = contexts.GetGroup(Get<HeldBy>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			foreach (var card in _cards)
			{
				if (card.Get<HeldBy>().Value is Side.Owneress)
					card.FlipCard();
			}
		}
	}
}