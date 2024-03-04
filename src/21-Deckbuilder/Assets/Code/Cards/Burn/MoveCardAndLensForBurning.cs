using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class MoveCardAndLensForBurning : ReactiveSystem<Entity<Game>>
	{
		private readonly HoldersProvider _holders;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _lenses;

		public MoveCardAndLensForBurning(Contexts contexts, HoldersProvider holders, ViewConfig viewConfig)
			: base(contexts.Get<Game>())
		{
			_holders = holders;
			_viewConfig = viewConfig;
			_lenses = contexts.GetGroup(Get<Lens>());
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<ToBurn>().AddedOrRemoved());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var card in entities)
			{
				card.SetTargetTransform(_holders.BurnCard);

				if (card.Has<Waiting>())
					continue;

				card.Add<Waiting, float>(_viewConfig.BurningDuration);
				card.Add<Callback, Action>(SendCard);
				continue;

				void SendCard()
				{
					card.Replace<MovementSpeed, float>(_viewConfig.BurnedCardFlipMovementSpeed).RemoveOnReach();
					card.SetTargetTransform(_holders.BurnedCard);
				}
			}

			foreach (var lens in _lenses)
			{
				lens.SetTargetTransform(_holders.BurnLoupe);

				if (lens.Has<Waiting>())
					continue;

				lens.Add<Waiting, float>(_viewConfig.BurningDuration);
				lens.Add<Callback, Action>(SendLens);
				continue;

				void SendLens() => lens.SetTargetTransform(_holders.DefaultLens);
			}
		}
	}
}