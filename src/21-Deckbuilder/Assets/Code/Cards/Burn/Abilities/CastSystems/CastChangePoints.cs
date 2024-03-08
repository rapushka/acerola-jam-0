using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public class CastChangePoints : CastOnBurnAbilityBase
	{
		private readonly Contexts _contexts;

		public CastChangePoints(Contexts contexts)
			: base(contexts)
		{
			_contexts = contexts;
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

					Debug.Log($"add {delta} points for {target}");
				}
			}
		}

		private Entity<Game> GetEntity(Side targetSide)
			=> _contexts.Get<Game>().GetPrimaryIndex<Component.Side, Side>().GetEntity(targetSide);
	}
}