using Code.Component;
using Code.Scope;
using Code.System;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class UpdateStandView : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly StandSign _standSign;
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public UpdateStandView(Contexts contexts, StandSign standSign)
		{
			_contexts = contexts;
			_standSign = standSign;
		}

		private Entity<Game> Dealer => _contexts.GetDealer();

		public void Execute() => _standSign.TurnedOn = Dealer.Is<Stand>();
	}
}