using UnityEngine;

namespace Code
{
	public static class MathExtensions
	{
		public static bool ApproximatelyEquals(this float @this, float other)
			=> Mathf.Approximately(@this, other);
	}
}