using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class PhysicsConfig
	{
		[field: SerializeField] public float LensPrincipleFocus { get; private set; }
	}
}