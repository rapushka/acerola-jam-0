using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code.System
{
	public class CastFlipWinCondition : CastOnBurnAbilityBase
	{
		private readonly Contexts _contexts;

		[Inject]
		public CastFlipWinCondition(Contexts contexts)
			: base(contexts)
		{
			_contexts = contexts;
		}

		private Entity<Game> Rules => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		protected override void Cast(IEnumerable<Entity<Game>> burnedCards)
		{
			foreach (var card in burnedCards)
			{
				if (!card.Has<InvokeFlipWinCondition>())
					continue;

				Rules.Is<FlipWinCondition>(true);
			}
		}
	}
}