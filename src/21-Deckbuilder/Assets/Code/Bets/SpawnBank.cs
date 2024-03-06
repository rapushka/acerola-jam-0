using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class SpawnBank : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly BalanceConfig _balance;

		public SpawnBank(Contexts contexts, BalanceConfig balance)
		{
			_contexts = contexts;
			_balance = balance;
		}

		public void Initialize()
		{
			var bank = _contexts.Get<Game>().CreateEntity();
			bank.Add<DebugName, string>("bank");
			bank.Is<Bank>(true);
			bank.Add<MinBet, int>(_balance.MinBetOnStart);
			bank.Add<CurrentBet, int>(_balance.MinBetOnStart);
			bank.Add<Money, int>(0);
		}
	}
}