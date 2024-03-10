using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class SetupDefaultRules : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly BalanceConfig _balance;
		private readonly IGroup<Entity<Game>> _startDeal;

		public SetupDefaultRules(Contexts contexts, BalanceConfig balance)
		{
			_contexts = contexts;
			_balance = balance;
			_startDeal = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		private UniqueComponentsContainer<Game> Unique => _contexts.Get<Game>().Unique;

		public void Execute()
		{
			foreach (var _ in _startDeal)
			{
				DestroyOldRules();

				var e = _contexts.Get<Game>().CreateEntity();
				e.Is<Rules>(true);
				e.Add<DebugName, string>("rules");
				e.Add<MaxPointsThreshold, int>(_balance.DefaultMaxPointThreshold);
				e.Add<MaxCardsInHand, int>(_balance.DefaultMaxCardsInHand);
			}
		}

		private void DestroyOldRules()
		{
			if (Unique.Has<Rules>())
			{
				var rules = Unique.GetEntity<Rules>();
				rules.Is<Rules>(false);
				rules.Is<Destroyed>(true);
			}
		}
	}
}