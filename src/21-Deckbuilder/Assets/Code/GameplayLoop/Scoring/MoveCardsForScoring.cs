using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class MoveCardsForScoring : IExecuteSystem
	{
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _entities;
		private readonly IGroup<Entity<Game>> _cards;

		[Inject]
		public MoveCardsForScoring(Contexts contexts, HoldersProvider holders)
		{
			_holders = holders;
			_entities = contexts.GetGroup(Get<Component.EndDeal>());
			_cards = contexts.GetGroup(Get<Component.HeldBy>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			foreach (var card in _cards)
			{
				var side = card.Get<Component.HeldBy>().Value;
				card.SetTargetTransform(_holders[side].CardScoring);
			}
		}
	}
}