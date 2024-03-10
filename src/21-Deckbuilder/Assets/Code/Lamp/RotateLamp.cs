using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class RotateLamp : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _cardsToBurn;

		public RotateLamp(Contexts contexts, ViewConfig viewConfig)
		{
			_contexts = contexts;
			_viewConfig = viewConfig;

			_cardsToBurn = contexts.GetGroup(ScopeMatcher<Game>.Get<ToBurn>());
		}

		private Entity<Game> Lamp => _contexts.Get<Game>().Unique.GetEntity<Lamp>();

		private ViewConfig.LampView LampViewConfig => _viewConfig.Lamp;

		public void Execute()
		{
			var rotation
				= _contexts.GetPlayer().Is<CurrentTurn>() ? LampViewConfig.PlayerRotation
				: _contexts.GetPlayer().Is<CurrentTurn>() ? LampViewConfig.OpponentRotation
				                                            : LampViewConfig.DefaultRotation;

			if (_cardsToBurn.count > 0)
				rotation = LampViewConfig.DefaultRotation;

			Lamp.SetXRotation(rotation);
		}
	}
}