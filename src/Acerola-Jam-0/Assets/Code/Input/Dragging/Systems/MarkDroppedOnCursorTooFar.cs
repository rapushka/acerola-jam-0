using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class MarkDroppedOnCursorTooFar : IExecuteSystem
	{
		private readonly IInputService _inputService;
		private readonly IGroup<Entity<Game>> _entities;
		private readonly GameConfig _gameConfig;

		[Inject]
		public MarkDroppedOnCursorTooFar(Contexts contexts, IInputService inputService, GameConfig gameConfig)
		{
			_gameConfig = gameConfig;
			_inputService = inputService;
			_entities = contexts.GetGroup(AllOf(Get<Draggable>(), Get<Pressed>()));
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var distance = _inputService.CursorWorldPoint.DistanceTo(e.Get<ActualPosition>().Value);

				if (distance >= _gameConfig.Input.DistanceToDropDraggable)
					e.Is<Dropped>(true);
			}
		}
	}
}