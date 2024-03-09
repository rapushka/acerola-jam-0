using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public class CastDestroyAllSuit : CastOnBurnAbilityBase
	{
		private readonly IGroup<Entity<Game>> _cards;

		public CastDestroyAllSuit(Contexts contexts)
			: base(contexts)
		{
			_cards = contexts.GetGroup(ScopeMatcher<Game>.Get<Face>());
		}

		protected override void Cast(IEnumerable<Entity<Game>> burnedCards)
		{
			foreach (var card in burnedCards)
			{
				if (!card.Has<DestroyAllSuit>())
					continue;

				var suit = card.Get<DestroyAllSuit>().Value;

				foreach (var target in _cards)
				{
					if (target.Get<Face>().Value.Suit == suit)
						target.Is<Destroyed>(true);
				}
			}
		}
	}
}