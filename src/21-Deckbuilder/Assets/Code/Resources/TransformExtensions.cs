using UnityEngine;
using static System.Single;

namespace Code
{
	public static class TransformExtensions
	{
		public static void Set(this Transform @this, float x = NaN, float y = NaN, float z = NaN)
		{
			var newPosition = @this.position;

			if (x is not NaN)
				newPosition.x = x;

			if (y is not NaN)
				newPosition.y = y;

			if (z is not NaN)
				newPosition.z = z;

			@this.position = newPosition;
		}
	}
}