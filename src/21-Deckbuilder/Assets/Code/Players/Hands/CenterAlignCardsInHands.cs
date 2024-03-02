using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class CenterAlignCardsInHands : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _sides;

		[Inject]
		public CenterAlignCardsInHands(Contexts contexts, HoldersProvider holders, ViewConfig viewConfig)
		{
			_contexts = contexts;
			_viewConfig = viewConfig;
			_sides = contexts.GetGroup(Get<Component.Side>());
		}

		public void Execute()
		{
			foreach (var side in _sides)
			{
				var cards = _contexts.Get<Game>().GetIndex<HeldBy, Side>()
				                     .GetEntities(side.Get<Component.Side>().Value);

				var spacing = _viewConfig.DistanceBetweenCards;
				var length = cards.Count * spacing;
				var currentPosition = length * -0.5f;

				foreach (var card in cards)
				{
					var cardPosition = card.Has<DestinationPosition>()
						? card.Get<DestinationPosition>().Value
						: card.Get<Position>().Value;

					if (!cardPosition.x.ApproximatelyEquals(currentPosition))
						card.Replace<DestinationPosition, Vector3>(cardPosition.Set(x: currentPosition));

					currentPosition += spacing;
				}
			}
		}
	}
}