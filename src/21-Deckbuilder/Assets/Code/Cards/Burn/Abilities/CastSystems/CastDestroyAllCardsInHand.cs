using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public class CastDestroyAllCardsInHand : CastOnBurnAbilityBase
	{
		private readonly IGroup<Entity<Game>> _cards;

		public CastDestroyAllCardsInHand(Contexts contexts)
			: base(contexts)
		{
			_cards = contexts.GetGroup(ScopeMatcher<Game>.Get<HeldBy>());
		}

		protected override void Cast(IEnumerable<Entity<Game>> burnedCards)
		{
			foreach (var card in burnedCards)
			{
				if (!card.Has<DestroyAllCardsInHand>())
					continue;

				var targets = card.Get<AbilityTargets>().Value;

				foreach (var targetCard in _cards)
				{
					foreach (var relativeSide in targets)
					{
						if (targetCard.Get<HeldBy>().Value == relativeSide.AbsoluteSide())
							targetCard.Is<Destroyed>(true);
					}
				}
			}
		}
	}
}