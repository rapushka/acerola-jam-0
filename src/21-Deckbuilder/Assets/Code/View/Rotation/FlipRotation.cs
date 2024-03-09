using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public sealed class FlipRotation : IExecuteSystem
	{
		private readonly IGroup<Entity<Game>> _entities;

		public FlipRotation(Contexts contexts)
		{
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<FlipRotationAxis>());
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				var rotation = e.Get<Rotation>().Value;
				var reverseAxis = e.Get<FlipRotationAxis>().Value;

				var delta = Quaternion.Euler(reverseAxis * 180f);
				var reversedRotation = rotation * delta;

				e.Add<TargetRotation, Quaternion>(reversedRotation);
			}
		}
	}
}