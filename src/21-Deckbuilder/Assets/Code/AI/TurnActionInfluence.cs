using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public struct TurnActionInfluence
	{
		[field: SerializeField] public float Hit   { get; set; }
		[field: SerializeField] public float Stand { get; set; }
		[field: SerializeField] public float Pass  { get; set; }

		public static TurnActionInfluence operator *(TurnActionInfluence @this, float multiplier)
			=> new()
			{
				Hit = @this.Hit * multiplier,
				Stand = @this.Stand * multiplier,
				Pass = @this.Pass * multiplier,
			};
	}
}