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

				var lastSide = e.Get<Component.Side>().Value;
				var nextSide = _contexts.GetSide(lastSide.Flip());

				e.Is<CardActionDone>(false);
				nextSide.Is<CardActionDone>(false);

				if (e.Is<Stand>() && nextSide.Is<Stand>())
				{
					EndDeal();
					continue;
				}

				if (TryPassTurn(nextSide))
					continue;

				if (TryPassTurn(e))
					continue;

				EndDeal();
			}
		}

		private static bool TryPassTurn(Entity<Game> e)
		{
			if (!e.Is<Pass>() && !e.Is<AllIn>())
			{
				e.Is<CurrentTurn>(true);
				e.Is<Stand>(false);

				return true;
			}

			return false;
		}

		private void EndDeal() => _contexts.Get<Game>().CreateEntity().Is<Component.EndDeal>(true);
	}
}