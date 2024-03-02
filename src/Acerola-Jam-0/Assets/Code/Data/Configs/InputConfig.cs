using System;
using UnityEngine;

namespace Code
{
	[Serializable]
	public class InputConfig
	{
		[field: SerializeField] public float DistanceToDropDraggable { get; private set; }
		[field: SerializeField] public float RotationSpeed           { get; private set; }
	}
}