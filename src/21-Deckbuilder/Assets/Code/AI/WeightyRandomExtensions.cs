using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code
{
	public static class WeightyRandomExtensions
	{
		public static Strategy PickRandom(this IEnumerable<Strategy> @this)
		{
			var list = @this.ToList();

			if (@this == null || !list.Any())
				throw new ArgumentException("Collection is empty or null.");

			var totalRaritySum = list.Sum(item => Mathf.Max(0, item.Benefit));
			var randomValue = UnityEngine.Random.value * totalRaritySum;

			foreach (var item in list)
			{
				randomValue -= item.Benefit;

				if (randomValue < 0)
					return item;
			}

			var benefits = string.Join(", ", list.Select((s) => s.Benefit));
			Debug.LogWarning($"No item found with matching rarity. benefits: {benefits}");

			return list.First();
		}
	}
}