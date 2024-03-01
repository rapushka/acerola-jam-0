using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class Drag : IExecuteSystem
	{
		private readonly IInputService _inputService;
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public Drag(Contexts contexts, IInputService inputService)
		{
			_inputService = inputService;
			_entities = contexts.GetGroup(AllOf(Get<Draggable>(), Get<Pressed>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
				e.Replace<Position, Vector2>(_inputService.CursorWorldPoint);
		}
	}
}