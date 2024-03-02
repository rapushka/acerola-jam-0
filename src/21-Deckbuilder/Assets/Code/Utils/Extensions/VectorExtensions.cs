using UnityEngine;

namespace Code
{
	public static class VectorExtensions
	{
		public static float DistanceTo(this Vector3 @this, Vector3 other)
			=> Vector3.Distance(@this, other);
	}
}