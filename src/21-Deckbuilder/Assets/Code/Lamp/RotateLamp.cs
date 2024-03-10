using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class RotateLamp : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _cardsToBurn;

		public RotateLamp(Contexts contexts, HoldersProvider holders)
		{
			_contexts = contexts;
			_holders = holders;

			_cardsToBurn = contexts.GetGroup(ScopeMatcher<Game>.Get<ToBurn>());
		}

		private Entity<Game> Lamp => _contexts.Get<Game>().Unique.GetEntity<Lamp>();

		private HoldersProvider.LampHolders LampViewConfig => _holders.Lamp;

		public void Execute()
		{
			var handler
				= _contexts.GetPlayer().Is<CurrentTurn>() ? LampViewConfig.AtPlayer
				: _contexts.GetDealer().Is<CurrentTurn>() ? LampViewConfig.AtOpponent
				                                            : LampViewConfig.Default;

			if (_cardsToBurn.count > 0)
				handler = LampViewConfig.Default;

			Lamp.SetTargetTransform(handler);
		}
	}
}