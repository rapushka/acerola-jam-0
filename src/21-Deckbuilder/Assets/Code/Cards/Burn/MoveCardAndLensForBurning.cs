using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
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
				var cardTarget = _holders.BurnCard;
				card.Replace<TargetPosition, Vector3>(cardTarget.position);
				card.Replace<TargetRotation, Quaternion>(cardTarget.rotation);
			}

			foreach (var lens in _lenses)
			{
				var lensTarget = _holders.BurnLoupe;
				lens.Replace<TargetPosition, Vector3>(lensTarget.position);
				lens.Replace<TargetRotation, Quaternion>(lensTarget.rotation);

				if (lens.Has<Waiting>())
					continue;

				lens.Add<Waiting, float>(_viewConfig.BurningDuration);
				lens.Add<Callback, Action>(SendLens);
				continue;

				void SendLens()
				{
					lens.Replace<TargetPosition, Vector3>(_holders.DefaultLens.position);
					lens.Replace<TargetRotation, Quaternion>(_holders.DefaultLens.rotation);
				}
			}
		}
	}
}