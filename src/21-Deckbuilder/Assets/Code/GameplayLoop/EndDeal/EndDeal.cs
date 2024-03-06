using System;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class EndDeal : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;
		private readonly HudMediator _hud;

		public EndDeal(Contexts contexts, HudMediator hud)
		{
			_hud = hud;
			_contexts = contexts;

			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.EndDeal>());
			contexts.GetGroup(ScopeMatcher<Game>.Get<Component.Side>());
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var playerScore = _contexts.GetPlayer().Get<Score>().Value;
				var dealerScore = _contexts.GetDealer().Get<Score>().Value;

				playerScore = playerScore > 21 ? -1 : playerScore;
				dealerScore = dealerScore > 21 ? -1 : dealerScore;

				var result = playerScore.CompareTo(dealerScore) switch
				{
					-1 => "You Loose",
					0  => "Draw",
					1  => "You Win",
					_  => throw new ArgumentOutOfRangeException(),
				};

				var playerScoreView = playerScore == -1 ? "Busted!" : playerScore.ToString();
				var dealerScoreView = dealerScore == -1 ? "Busted!" : dealerScore.ToString();

				var message = $"{result}\nPlayer: {playerScoreView}\nDealer: {dealerScoreView}";
				_hud.ShowDealEndScreen(message);

				// foreach (var side in _sides)
				// 	side.Is<KeepPlaying>(false);

				e.Is<Destroyed>(true);
			}
		}
	}
}