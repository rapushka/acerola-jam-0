using Code.Component;
using Code.Scope;
using Entitas.Generic;
using ModestTree;
using UnityEngine;

namespace Code
{
	public static class RotationExtensions
	{
		public static void SetXRotation(this Entity<Game> @this, float value)
		{
			var rotation = @this.GetOrDefault<TargetRotation>()?.Value
			               ?? @this.Get<Rotation>().Value;

			if (!rotation.eulerAngles.x.ApproximatelyEquals(value))
				@this.Replace<TargetRotation, Quaternion>(rotation.SetEuler(x: value));
		}
	}
}