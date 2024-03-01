using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class DropDraggableOnMouseTooFar : IExecuteSystem
	{
		private readonly IInputService _inputService;
		private readonly IGroup<Entity<Game>> _entities;
		private readonly GameConfig _gameConfig;

		[Inject]
		public DropDraggableOnMouseTooFar(Contexts contexts, IInputService inputService, GameConfig gameConfig)
		{
			_gameConfig = gameConfig;
			_inputService = inputService;
			_entities = contexts.GetGroup(AllOf(Get<Draggable>(), Get<Pressed>()));
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var distance = _inputService.CursorWorldPoint.DistanceTo(e.Get<Position>().Value);

				if (distance >= _gameConfig.Input.DistanceToDropDraggable)
				{
					e.Is<Pressed>(false);
					e.Replace<Position, Vector2>(e.Get<ActualPosition>().Value);
				}
			}
		}
	}
}