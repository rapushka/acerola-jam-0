using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public sealed class AiChooseAction : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;

		public AiChooseAction(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Execute()
		{
			var dealer = _contexts.GetDealer();

			if (dealer.Is<CurrentTurn>())
				MakeDecision(dealer);
		}

		private static void MakeDecision(Entity<Game> dealer)
		{
			if (Random.value >= 0.5f)
				dealer.Is<Hit>(true);
			else
				dealer.Is<KeepPlaying>(false);
		}
	}
}