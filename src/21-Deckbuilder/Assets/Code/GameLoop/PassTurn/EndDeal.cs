using System;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public sealed class EndDeal : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;

		public EndDeal(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.EndDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			{
				var playerScore = _contexts.GetPlayer().Get<Score>().Value;
				var dealerScore = _contexts.GetDealer().Get<Score>().Value;

				var result = playerScore.CompareTo(dealerScore) switch
				{
					-1 => "Loose",
					0  => "Draw",
					1  => "Win",
					_  => throw new ArgumentOutOfRangeException(),
				};

				var playerScoreView = playerScore > 21 ? "Busted!" : playerScore.ToString();
				var dealerScoreView = dealerScore > 21 ? "Busted!" : dealerScore.ToString();

				Debug.Log($"{result}. Player: {playerScoreView}. Dealer: {dealerScoreView}");
				Debug.Break();
			}
		}
	}
}