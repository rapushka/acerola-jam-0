using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public class MoveToTarget : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly ViewConfig _viewConfig;
		private readonly ITimeService _timeService;
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public MoveToTarget(Contexts contexts, ViewConfig viewConfig, ITimeService timeService)
		{
			_entities = contexts.GetGroup(AllOf(Get<Position>(), Get<TargetPosition>()));
			_viewConfig = viewConfig;
			_timeService = timeService;
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var position = e.Get<Position>().Value;
				var destination = e.Get<TargetPosition>().Value;
				var speed = e.GetOrDefault<MovementSpeed>()?.Value ?? _viewConfig.CommonMovementSpeed;

				var direction = (destination - position).normalized;
				var distance = position.DistanceTo(destination);
				var moveDistance = speed * _timeService.DeltaTime;

				if (distance <= moveDistance)
				{
					e.Replace<Position, Vector3>(destination);
					e.Remove<TargetPosition>();

					if (e.Is<RemoveMovementSpeedOnDestination>())
					{
						e.Remove<MovementSpeed>();
						e.Remove<RemoveMovementSpeedOnDestination>();
					}

					continue;
				}

				e.Replace<Position, Vector3>(position + direction * moveDistance);
			}
		}
	}
}