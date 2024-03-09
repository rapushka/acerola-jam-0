using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public static class FlipExtensions
	{
		public static void FlipCard(this Entity<Game> @this)
		{
			@this.Add<FlipRotationAxis, Vector3>(Vector3.up);
		}
	}
}