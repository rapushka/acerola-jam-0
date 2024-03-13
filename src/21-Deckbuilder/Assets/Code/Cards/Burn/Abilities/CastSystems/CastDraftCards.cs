using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code.System
{
	public class CastDraftCards : CastOnBurnAbilityBase
	{
		private readonly DeckProvider _deck;

		[Inject]
		public CastDraftCards(Contexts contexts, DeckProvider deck)
			: base(contexts)
		{
			_deck = deck;
		}

		protected override void Cast(IEnumerable<Entity<Game>> burnedCards)
		{
			foreach (var card in burnedCards)
			{
				if (!card.Has<DraftCards>())
					continue;

				var targetSides = card.Get<AbilityTargets>().Value;
				var countOfCards = card.Get<DraftCards>().Value;

				for (var i = 0; i < countOfCards; i++)
				{
					foreach (var targetSide in targetSides)
					{
						foreach (var cardFromDeck in _deck.TakeCards(1))
							cardFromDeck.Replace<HeldBy, Side>(targetSide.AbsoluteSide());
					}
				}
			}
		}
	}
}