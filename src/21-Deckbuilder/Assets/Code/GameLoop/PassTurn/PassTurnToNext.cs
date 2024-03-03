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
				e.Is<CurrentTurn>(false);

				var nextCurrentTurnSide = e.Get<Component.Side>().Value is Side.Player
					? _contexts.GetDealer()
					: _contexts.GetPlayer();

				nextCurrentTurnSide.Is<CurrentTurn>(true);
			}
		}
	}
}