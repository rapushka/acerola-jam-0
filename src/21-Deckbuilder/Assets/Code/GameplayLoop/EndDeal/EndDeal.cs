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
		private readonly IGroup<Entity<Game>> _sides;

		public EndDeal(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.EndDeal>());
			_sides = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.Side>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			{
				var playerScore = _contexts.GetPlayer().Get<Score>().Value;
				var dealerScore = _contexts.GetDealer().Get<Score>().Value;

				playerScore = playerScore > 21 ? -1 : playerScore;
				dealerScore = dealerScore > 21 ? -1 : dealerScore;

				var result = playerScore.CompareTo(dealerScore) switch
				{
					-1 => "Loose",
					0  => "Draw",
					1  => "Win",
					_  => throw new ArgumentOutOfRangeException(),
				};

				var playerScoreView = playerScore == -1 ? "Busted!" : playerScore.ToString();
				var dealerScoreView = dealerScore == -1 ? "Busted!" : dealerScore.ToString();

				Debug.Log($"{result}. Player: {playerScoreView}. Dealer: {dealerScoreView}");

				foreach (var side in _sides)
					side.Is<Stand>(false);
			}
		}
	}
}