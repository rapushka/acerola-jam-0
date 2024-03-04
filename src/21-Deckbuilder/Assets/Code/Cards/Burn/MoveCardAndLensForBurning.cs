using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code.System
{
	public sealed class MoveCardAndLensForBurning : IExecuteSystem
	{
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _cards;
		private readonly IGroup<Entity<Game>> _lenses;

		[Inject]
		public MoveCardAndLensForBurning(Contexts contexts, HoldersProvider holdersProvider)
		{
			_holders = holdersProvider;
			_cards = contexts.GetGroup(ScopeMatcher<Game>.Get<ToBurn>());
			_lenses = contexts.GetGroup(ScopeMatcher<Game>.Get<Lens>());
		}

		public void Execute()
		{
			foreach (var candidate in _cards)
			{
				var target = _holders.BurnCard;

				candidate.Replace<TargetPosition, Vector3>(target.position);
				candidate.Replace<TargetRotation, Quaternion>(target.rotation);
			}

			foreach (var lens in _lenses)
			{
				var target = _holders.BurnLoupe;

				lens.Replace<TargetPosition, Vector3>(target.position);
				lens.Replace<TargetRotation, Quaternion>(target.rotation);
			}
		}
	}
}