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

		private Entity<Game> Rules => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var player = _contexts.GetPlayer();
				var dealer = _contexts.GetDealer();

				var playerScore = player.Get<Score>().Value;
				var dealerScore = dealer.Get<Score>().Value;

				var maxPoints = Rules.Get<MaxPointsThreshold>().Value;
				var flipWinCondition = Rules.Is<FlipWinCondition>();

				var isPlayerPass = player.Is<Pass>();
				var isDealerPass = dealer.Is<Pass>();

				var isPlayerBusted = playerScore > maxPoints;
				var isDealerBusted = dealerScore > maxPoints;

				Func<int, int, bool> condition = flipWinCondition ? WinsFewerPoints : WinsMorePoints;

				var playerWinPoints = condition.Invoke(playerScore, dealerScore);
				var dealerWinPoints = condition.Invoke(dealerScore, playerScore);

				var isPlayerWin = playerWinPoints || isDealerPass || isDealerBusted;
				var isDealerWin = dealerWinPoints || isPlayerPass || isPlayerBusted;

				if (isPlayerBusted || isPlayerPass)
					isPlayerWin = false;

				if (isDealerBusted || isDealerPass)
					isDealerWin = false;

				player.Is<Winner>(isPlayerWin);
				dealer.Is<Winner>(isDealerWin);

				var result
					= isPlayerWin && isDealerWin ? "Draw! You split the winnings in two"
					: isPlayerWin                ? "You Win! And take the whole Bank"
					: isDealerWin                ? "You Loose:( And the Dealer takes the whole Bank"
					                               : "Nobody Won! The casino takes your winnings";

				var playerScoreView
					= isPlayerPass   ? "Pass"
					: isPlayerBusted ? "Busted!"
					                   : playerScore.ToString();
				var dealerScoreView
					= isDealerPass   ? "Pass"
					: isDealerBusted ? "Busted!"
					                   : dealerScore.ToString();

				var message = $"{result}\nPlayer: {playerScoreView}\nDealer: {dealerScoreView}";
				_hud.ShowDealEndScreen(message);

				e.Is<Destroyed>(true);
			}
		}

		private bool WinsMorePoints(int ourPoints, int opponentScore) => ourPoints >= opponentScore;

		private bool WinsFewerPoints(int ourScore, int opponentScore) => ourScore <= opponentScore;
	}
}