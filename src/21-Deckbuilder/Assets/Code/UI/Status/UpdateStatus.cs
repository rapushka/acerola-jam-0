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

		public void Execute()
		{
			_stringBuilder.Clear();

			_stringBuilder.AppendLine($"Player's money: {Player.Get<Money>().Value}");
			_stringBuilder.AppendLine($"Dealer's money: {Dealer.Get<Money>().Value}");
			_stringBuilder.AppendLine($"Bank: {Bank.Get<Money>().Value}");

			_hud.StatusText = _stringBuilder.ToString();
		}
	}
}