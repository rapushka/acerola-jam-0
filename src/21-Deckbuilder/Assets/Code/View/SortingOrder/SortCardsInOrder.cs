using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class SortCardsInOrder : ReactiveSystem<Entity<Game>>
	{
		private readonly IGroup<Entity<Game>> _sides;

		public SortCardsInOrder(Contexts contexts)
			: base(contexts.Get<Game>())
		{
			_sides = contexts.GetGroup(Get<Component.Side>());
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<HeldBy>().AddedOrRemoved());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in _sides)
			{
				var cards = side.GetCards();
				var sortedCards = cards.Where((c) => c.Has<SortingOrder>()).ToList();

				var maxSoringOrder = 0;

				if (sortedCards.Any())
					maxSoringOrder = sortedCards.Max((c) => c.Get<SortingOrder>().Value);

				foreach (var card in cards.Except(sortedCards))
				{
					if (card.Has<ShadowCard>())
					{
						card.Add<SortingOrder, int>(-1);
						continue;
					}

					card.Add<SortingOrder, int>(++maxSoringOrder);
				}
			}
		}
	}
}