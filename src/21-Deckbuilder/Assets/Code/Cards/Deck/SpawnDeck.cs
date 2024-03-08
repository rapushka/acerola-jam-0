using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public class SpawnDeck : IExecuteSystem
	{
		private readonly CardsFactory _cardsFactory;
		private readonly IGroup<Entity<Game>> _startDeal;

		[Inject]
		public SpawnDeck(Contexts contexts, CardsFactory cardsFactory)
		{
			_cardsFactory = cardsFactory;

			_startDeal = contexts.GetGroup(Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _startDeal)
			{
				var shuffledDeck = CardUtils.ShuffledDeck();

				var height = 0f;
				var cardHeight = 0.002f;
				var counter = 1;

				foreach (var (cardFace, cardSuit) in shuffledDeck)
				{
					height += cardHeight;
					_cardsFactory.Create(cardFace, cardSuit, height, counter);
					counter++;
				}
			}
		}
	}
}