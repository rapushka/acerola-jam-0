using System;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Random = UnityEngine.Random;

namespace Code.System
{
	public sealed class AiTurnAction : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly AiConfig _config;
		private readonly IGroup<Entity<Game>> _entities;

		public AiTurnAction(Contexts contexts, AiConfig config)
		{
			_contexts = contexts;
			_config = config;
		}

		private bool HasCandidate => _contexts.Get<Game>().Unique.Has<Candidate>();

		public void Execute()
		{
			var dealer = _contexts.GetDealer();

			if (dealer.Is<CurrentTurn>() && !HasCandidate && !dealer.Has<Waiting>())
				MakeDecision(dealer);
		}

		private void MakeDecision(Entity<Game> dealer)
		{
			dealer.Add<Waiting, float>(_config.TurnActionThinkingDuration);
			dealer.Add<Callback, Action>(Decide);
			return;

			void Decide()
			{
				if (Random.value >= 0.5f)
					dealer.Is<Hit>(true);
				else
					dealer.Is<KeepPlaying>(false);
			}
		}
	}
}