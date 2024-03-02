using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> @this)
			=> @this.OrderBy((_) => Random.value);
	}
}