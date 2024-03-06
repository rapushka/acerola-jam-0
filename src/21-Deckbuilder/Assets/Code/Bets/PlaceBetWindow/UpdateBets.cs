using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class UpdateBets : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;

		public UpdateBets(Contexts contexts, HudMediator hud)
		{
			_contexts = contexts;
			_hud = hud;
		}

		private Entity<Game> Bank => _contexts.Get<Game>().Unique.GetEntity<Bank>();

		public void Execute()
		{
			_hud.CurrentBet = Bank.Get<CurrentBet>().Value;
			_hud.MinBet = Bank.Get<MinBet>().Value;
		}
	}
}