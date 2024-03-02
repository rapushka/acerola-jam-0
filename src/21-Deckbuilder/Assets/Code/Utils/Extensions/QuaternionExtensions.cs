using UnityEngine;
using static System.Single;

namespace Code
{
	public static class QuaternionExtensions
	{
		public static float AngleTo(this Quaternion @this, Quaternion other)
			=> Quaternion.Angle(@this, other);

		public static Quaternion SetEuler(this Quaternion @this, float x = NaN, float y = NaN, float z = NaN)
			=> @this.eulerAngles.Set(x: x, y: y, z: z).AsEuler();

		public static Quaternion AsEuler(this Vector3 @this)
			=> Quaternion.Euler(@this);
	}
}