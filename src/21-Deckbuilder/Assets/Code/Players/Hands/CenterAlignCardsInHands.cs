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
		private readonly HoldersProvider _holders;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _sides;

		[Inject]
		public CenterAlignCardsInHands(Contexts contexts, HoldersProvider holders, ViewConfig viewConfig)
		{
			_contexts = contexts;
			_holders = holders;
			_viewConfig = viewConfig;
			_sides = contexts.GetGroup(Get<Component.Side>());
		}

		public void Execute()
		{
			foreach (var e in _sides)
			{
				var side = e.Get<Component.Side>().Value;
				var cards = _contexts.Get<Game>().GetIndex<HeldBy, Side>().GetEntities(side);
				var hand = _holders[side].Hand;

				var spacing = !_contexts.Get<Game>().Unique.Has<CurrentTurn>()
					? _viewConfig.OnScoringDistance
					: _viewConfig.DistanceBetweenCards;

				var length = cards.Count * spacing;
				var currentX = length * -0.5f + hand.position.x;

				foreach (var card in cards)
				{
					var cardPosition = card.Has<TargetPosition>()
						? card.Get<TargetPosition>().Value
						: card.Get<Position>().Value;

					if (!cardPosition.x.ApproximatelyEquals(currentX))
						card.Replace<TargetPosition, Vector3>(cardPosition.Set(x: currentX));

					currentX += spacing;
				}
			}
		}
	}
}