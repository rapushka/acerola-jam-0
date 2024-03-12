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

				var playerHasBlackJack = playerScore == Constants.BlackJack && player.GetCards().Count == 2;
				var dealerHasBlackJack = dealerScore == Constants.BlackJack && dealer.GetCards().Count == 2;

				var playerWinPoints = condition.Invoke(playerScore, dealerScore);
				var dealerWinPoints = condition.Invoke(dealerScore, playerScore);

				if (playerScore == dealerScore)
				{
					if (dealerHasBlackJack)
						playerWinPoints = false;

					if (playerHasBlackJack)
						dealerWinPoints = false;
				}

				var isPlayerWin = playerWinPoints || isDealerPass || isDealerBusted;
				var isDealerWin = dealerWinPoints || isPlayerPass || isPlayerBusted;

				if (isPlayerBusted || isPlayerPass)
					isPlayerWin = false;

				if (isDealerBusted || isDealerPass)
					isDealerWin = false;

				player.Is<Winner>(isPlayerWin);
				dealer.Is<Winner>(isDealerWin);

				var result
					= isPlayerWin && isDealerWin ? "Draw\n\nYou split the winnings in two"
					: isPlayerWin                ? "You Win!\n\nYou take the whole Bank"
					: isDealerWin                ? "You Loose:(\n\nThe Owneress takes the whole Bank"
					                               : "Nobody Won\n\nThe casino takes your winnings";

				var playerScoreView
					= isPlayerPass       ? "Pass"
					: isPlayerBusted     ? "Busted!"
					: playerHasBlackJack ? "Black Jack"
					                       : playerScore.ToString();
				var dealerScoreView
					= isDealerPass       ? "Pass"
					: isDealerBusted     ? "Busted!"
					: dealerHasBlackJack ? "Black Jack"
					                       : dealerScore.ToString();

				var message = $"{result}\nPlayer\t{playerScoreView}\nOwneress\t{dealerScoreView}";
				_hud.ShowDealEndScreen(message);

				e.Is<Destroyed>(true);
			}
		}

		private bool WinsMorePoints(int ourPoints, int opponentScore) => ourPoints >= opponentScore;

		private bool WinsFewerPoints(int ourScore, int opponentScore) => ourScore <= opponentScore;
	}
}