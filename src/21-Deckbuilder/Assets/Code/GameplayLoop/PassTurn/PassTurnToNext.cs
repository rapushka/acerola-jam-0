using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public class PassTurnToNext : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public PassTurnToNext(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(AnyOf(Get<TurnEnded>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (!e.Is<CurrentTurn>())
					continue;

				e.Is<CurrentTurn>(false);
				e.Is<CardActionDone>(false);

				var lastSide = e.Get<Component.Side>().Value;
				var nextSide = _contexts.GetSide(lastSide.Flip());

				if (e.Is<Stand>() && nextSide.Is<Stand>())
				{
					EndDeal();
					continue;
				}

				if (!nextSide.Is<Pass>() && !nextSide.Is<AllIn>())
				{
					nextSide.Is<CurrentTurn>(true);
					continue;
				}

				if (e.Is<Pass>() && !e.Is<AllIn>())
				{
					e.Is<CurrentTurn>(true);
					continue;
				}

				EndDeal();
			}
		}

		private void EndDeal() => _contexts.Get<Game>().CreateEntity().Is<Component.EndDeal>(true);
	}
}