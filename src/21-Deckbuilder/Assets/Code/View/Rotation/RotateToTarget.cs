using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public class RotateToTarget : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;
		private readonly ITimeService _timeService;
		private readonly ViewConfig _viewConfig;

		[Inject]
		public RotateToTarget(Contexts contexts, ITimeService timeService, ViewConfig viewConfig)
		{
			_entities = contexts.GetGroup(AllOf(Get<Rotation>(), Get<TargetRotation>()));
			_timeService = timeService;
			_viewConfig = viewConfig;
		}

		public void Execute()
		{
			foreach (var e in _entities.GetEntities())
			{
				var current = e.Get<Rotation>().Value;
				var destination = e.Get<TargetRotation>().Value;
				var speed = e.GetOrDefault<RotationSpeed>()?.Value ?? _viewConfig.CommonRotationSpeed;
				var scaledSpeed = speed * _timeService.DeltaTime;

				if (current.AngleTo(destination) <= scaledSpeed)
				{
					e.Replace<Rotation, Quaternion>(destination);
					e.Remove<TargetRotation>();

					continue;
				}

				var nextRotation = Quaternion.Lerp(current, destination, scaledSpeed);
				e.Replace<Rotation, Quaternion>(nextRotation);
			}
		}
	}
}