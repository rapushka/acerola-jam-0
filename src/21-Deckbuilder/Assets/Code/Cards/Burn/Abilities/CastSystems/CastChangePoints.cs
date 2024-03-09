using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code.System
{
	public class CastChangePoints : CastOnBurnAbilityBase
	{
		private readonly Contexts _contexts;
		private readonly ShadowCardsProvider _shadowCardsProvider;

		[Inject]
		public CastChangePoints(Contexts contexts, ShadowCardsProvider shadowCardsProvider)
			: base(contexts)
		{
			_contexts = contexts;
			_shadowCardsProvider = shadowCardsProvider;
		}

		protected override void Cast(IEnumerable<Entity<Game>> burnedCards)
		{
			foreach (var card in burnedCards)
			{
				if (!card.Has<ChangePoints>())
					continue;

				var targetSides = card.Get<AbilityTargets>().Value;
				var delta = card.Get<ChangePoints>().Value;

				foreach (var targetSide in targetSides)
				{
					var target = GetEntity(targetSide);

					_shadowCardsProvider.ChangePoints(target, delta);
				}
			}
		}

		private Entity<Game> GetEntity(Side targetSide)
			=> _contexts.Get<Game>().GetPrimaryIndex<Component.Side, Side>().GetEntity(targetSide);
	}
}