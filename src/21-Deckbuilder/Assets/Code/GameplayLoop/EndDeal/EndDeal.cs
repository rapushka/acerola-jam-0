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
				var player = _contexts.GetPlayer();
				var dealer = _contexts.GetDealer();

				var playerScore = player.Get<Score>().Value;
				var dealerScore = dealer.Get<Score>().Value;

				var rules = _contexts.Get<Game>().Unique.GetEntity<Rules>();
				var maxPoints = rules.Get<MaxPointsThreshold>().Value;

				var isPlayerPass = player.Is<Pass>();
				var isDealerPass = dealer.Is<Pass>();

				var isPlayerBusted = playerScore > maxPoints;
				var isDealerBusted = dealerScore > maxPoints;

				var isPlayerWin = playerScore >= dealerScore || isDealerPass || isDealerBusted;
				var isDealerWin = dealerScore >= playerScore || isPlayerPass || isPlayerBusted;

				player.Is<Winner>(isPlayerWin);
				dealer.Is<Winner>(isDealerWin);

				var result
					= isPlayerWin && isDealerWin ? "Draw! You split the winnings in two"
					: isPlayerWin                ? "You Win! And take the whole Bank"
					: isDealerWin                ? "You Loose:( And the Dealer takes the whole Bank"
					                               : "Nobody Win! The casino takes your winnings";

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
	}
}