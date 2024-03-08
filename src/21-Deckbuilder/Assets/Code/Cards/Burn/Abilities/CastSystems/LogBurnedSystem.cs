using System.Collections.Generic;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.System
{
	public sealed class LogBurnedSystem : CastOnBurnAbilityBase
	{
		public LogBurnedSystem(Contexts contexts) : base(contexts) { }

		protected override void Cast(IEnumerable<Entity<Game>> burnedCards)
		{
			foreach (var e in burnedCards)
				Debug.Log($"{e} is Burned!");
		}
	}
}