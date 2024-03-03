using UnityEngine;
using static System.Single;

namespace Code
{
	public static class VectorExtensions
	{
		public static float DistanceTo(this Vector3 @this, Vector3 other)
			=> Vector3.Distance(@this, other);

		public static Vector3 Set(this Vector3 @this, float x = NaN, float y = NaN, float z = NaN)
		{
			var newPosition = @this;

			if (x is not NaN)
				newPosition.x = x;

			if (y is not NaN)
				newPosition.y = y;

			if (z is not NaN)
				newPosition.z = z;

			return newPosition;
		}
	}
}