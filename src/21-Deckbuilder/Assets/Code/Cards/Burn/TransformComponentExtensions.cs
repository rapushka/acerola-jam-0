using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public static class TransformComponentExtensions
	{
		public static Entity<Game> SetTargetTransform(this Entity<Game> @this, Transform value)
		{
			@this.Replace<TargetPosition, Vector3>(value.position);
			@this.Replace<TargetRotation, Quaternion>(value.rotation);

			return @this;
		}

		/// <summary> Stands for Movement Speed </summary>
		public static Entity<Game> RemoveOnReach(this Entity<Game> @this)
		{
			@this.Is<RemoveMovementSpeedOnDestination>(true);
			return @this;
		}
	}
}