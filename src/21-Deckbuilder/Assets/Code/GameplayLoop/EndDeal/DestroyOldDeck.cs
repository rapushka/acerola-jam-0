using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class DestroyOldDeck : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _startDeal;
		private readonly IGroup<Entity<Game>> _cards;

		public DestroyOldDeck(Contexts contexts)
		{
			_startDeal = contexts.GetGroup(Get<Component.StartDeal>());
			_cards = contexts.GetGroup(Get<Component.Card>());
		}

		public void Execute()
		{
			foreach (var _ in _startDeal)
			foreach (var card in _cards.GetEntities())
				card.Destroy();
		}
	}
}