using System.Text;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class UpdateStatus : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;

		private readonly StringBuilder _stringBuilder = new();

		public UpdateStatus(Contexts contexts, HudMediator hud)
		{
			_contexts = contexts;
			_hud = hud;
		}

		private Entity<Game> Player => _contexts.GetPlayer();
		private Entity<Game> Dealer => _contexts.GetDealer();
		private Entity<Game> Bank   => _contexts.Get<Game>().Unique.GetEntity<Bank>();
		private Entity<Game> Rules  => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		public void Execute()
		{
			if (Player is null || Dealer is null)
				return;

			_stringBuilder.Clear();

			_stringBuilder.AppendLine($"Player's money: {Player.GetMoney()}");
			_stringBuilder.AppendLine($"Dealer's money: {Dealer.GetMoney()}");
			_stringBuilder.AppendLine($"Bank: {Bank.Get<Money>().Value}");
			_stringBuilder.AppendLine($"Max Points Threshold: {Rules.Get<MaxPointsThreshold>().Value}");
			_stringBuilder.AppendLine($"Max Cards in Hand: {Rules.Get<MaxCardsInHand>().Value}");

			if (Rules.Is<FlipWinCondition>())
				_stringBuilder.AppendLine("Win Condition is Flipped");

			_hud.StatusText = _stringBuilder.ToString();
		}
	}
}