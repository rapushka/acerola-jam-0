using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public class StartWithPlayerTurn : IExecuteSystem

	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _startDeal;

		public StartWithPlayerTurn(Contexts contexts)
		{
			_contexts = contexts;
			_startDeal = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		public void Execute()
		{
			foreach (var _ in _startDeal)
			{
				_contexts.GetDealer().Is<CurrentTurn>(false);
				_contexts.GetPlayer().Is<CurrentTurn>(true);
			}
		}
	}
}