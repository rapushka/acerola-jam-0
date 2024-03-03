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
			_entities = contexts.GetGroup(AnyOf(Get<Hit>(), Get<Stand>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (!e.Is<CurrentTurn>())
					continue;

				e.Is<CurrentTurn>(false);

				var nextCurrentTurnSide = e.Get<Component.Side>().Value is Side.Player
					? _contexts.GetDealer()
					: _contexts.GetPlayer();

				if (!nextCurrentTurnSide.Is<Stand>())
				{
					nextCurrentTurnSide.Is<CurrentTurn>(true);
					continue;
				}

				if (!e.Is<Stand>())
				{
					e.Is<CurrentTurn>(true);
					continue;
				}

				_contexts.Get<Game>().CreateEntity().Is<Component.EndDeal>(true);
			}
		}
	}
}