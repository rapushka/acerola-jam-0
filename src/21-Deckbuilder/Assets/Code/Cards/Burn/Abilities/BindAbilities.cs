using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

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
			_startDeal = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
			_cards = contexts.GetGroup(ScopeMatcher<Game>.Get<Face>());
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