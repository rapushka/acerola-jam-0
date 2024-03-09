using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class ShadowCardsProvider
	{
		private readonly Contexts _contexts;
		private readonly CardsFactory _cardsFactory;

		[Inject]
		public ShadowCardsProvider(Contexts contexts, CardsFactory cardsFactory)
		{
			_contexts = contexts;
			_cardsFactory = cardsFactory;
		}

		private PrimaryEntityIndex<Game, ShadowCard, Side> Index
			=> _contexts.Get<Game>().GetPrimaryIndex<ShadowCard, Side>();

		public void ChangePoints(Entity<Game> target, int delta)
		{
			var side = target.Get<Component.Side>().Value;
			var shadowCard = Index.HasEntity(side)
				? Index.GetEntity(side)
				: _cardsFactory.CreateShadowCard(side);

			shadowCard.AddValue<Points>(delta);
		}
	}
}