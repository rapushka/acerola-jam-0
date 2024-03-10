using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class CenterAlignCards : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HoldersProvider _holders;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _sides;

		[Inject]
		public CenterAlignCards(Contexts contexts, HoldersProvider holders, ViewConfig viewConfig)
		{
			_contexts = contexts;
			_holders = holders;
			_viewConfig = viewConfig;
			_sides = contexts.GetGroup(Get<Component.Side>());
		}

		private bool IsScoring => !_contexts.Get<Game>().Unique.Has<CurrentTurn>();

		public void Execute()
		{
			foreach (var e in _sides)
			{
				var side = e.Get<Component.Side>().Value;
				var cards = e.GetCards();

				var spacing = IsScoring
					? _viewConfig.OnScoringDistance
					: _viewConfig.DistanceBetweenCards;

				var length = (cards.Count - 1) * spacing;
				var currentX = length * -0.5f;

				if (!IsScoring)
					currentX += _holders[side].Hand.position.x;

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