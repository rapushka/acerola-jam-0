using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.Players
{
	public sealed class ResetMinBetInBank : IExecuteSystem
	{
		private readonly BalanceConfig _balance;
		private readonly IGroup<Entity<Game>> _entities;
		private readonly IGroup<Entity<Game>> _banks;

		public ResetMinBetInBank(Contexts contexts, BalanceConfig balance)
		{
			_balance = balance;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
			_banks = contexts.GetGroup(ScopeMatcher<Game>.Get<Bank>());
		}

		public void Execute()
		{
			foreach (var _ in _entities)
			foreach (var e in _banks)
			{
				e.Replace<Money, int>(0);
				e.Replace<MinBet, int>(_balance.MinBetOnStart);
			}
		}
	}
}