using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class BindAbilities : IExecuteSystem
	{
		private readonly CardAbilitiesBinder _cardAbilities;
		private readonly IGroup<Entity<Game>> _startDeal;
		private readonly IGroup<Entity<Game>> _cards;

		public BindAbilities(Contexts contexts, CardAbilitiesBinder cardAbilities)
		{
			_cardAbilities = cardAbilities;
			_startDeal = contexts.GetGroup(Get<StartDeal>());
			_cards = contexts.GetGroup(AllOf(Get<Face>()).NoneOf(Get<Destroyed>()));
		}

		public void Execute()
		{
			foreach (var _ in _startDeal)
			foreach (var card in _cards)
			{
				_cardAbilities.Bind(card);
			}
		}
	}
}