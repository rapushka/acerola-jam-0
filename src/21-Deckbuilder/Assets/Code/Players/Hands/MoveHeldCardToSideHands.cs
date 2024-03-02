using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public class MoveHeldCardToSideHands : ReactiveSystem<Entity<Game>>
	{
		private readonly HoldersProvider _holders;

		public MoveHeldCardToSideHands(Contexts contexts, HoldersProvider holders)
			: base(contexts.Get<Game>())
		{
			_holders = holders;
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<HeldBy>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Has<HeldBy>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
			{
				var hand = e.Get<HeldBy>().Value is Side.Player ? _holders.PlayerHand : _holders.DealerHand;
				e.Replace<DestinationPosition, Vector3>(hand.position);
			}
		}
	}
}