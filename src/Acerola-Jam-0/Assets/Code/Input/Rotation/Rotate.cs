using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public sealed class Rotate : IExecuteSystem
	{
		private readonly IInputService _inputService;
		private readonly GameConfig _gameConfig;
		private readonly IGroup<Entity<Game>> _entities;

		public Rotate(Contexts contexts, IInputService inputService, GameConfig gameConfig)
		{
			_inputService = inputService;
			_gameConfig = gameConfig;
			_entities = contexts.GetGroup(AllOf(Get<Pressed>(), Get<Rotatable>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var rotationSpeed = _gameConfig.Input.RotationSpeed;

				var isRotateLeft = _inputService.RotateLeft;
				var isRotateRight = _inputService.RotateRight;

				if (isRotateLeft)
					e.Replace<DeltaRotation, float>(rotationSpeed);

				if (isRotateRight)
					e.Replace<DeltaRotation, float>(-1 * rotationSpeed);

				if (isRotateRight == isRotateLeft)
					e.Replace<DeltaRotation, float>(0f);
			}
		}
	}
}