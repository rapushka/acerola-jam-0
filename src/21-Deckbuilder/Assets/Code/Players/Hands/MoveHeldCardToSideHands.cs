using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public class MoveHeldCardToSideHands : IExecuteSystem
	{
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _entities;

		public MoveHeldCardToSideHands(Contexts contexts, HoldersProvider holders)
		{
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<HeldBy>());
			_holders = holders;
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var hand = e.Get<HeldBy>().Value is Side.Player ? _holders.PlayerHand : _holders.DealerHand;

				e.Replace<DestinationPosition, Vector3>(hand.position);
			}
		}
	}
}