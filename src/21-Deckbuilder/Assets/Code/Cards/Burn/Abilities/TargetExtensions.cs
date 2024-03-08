using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class TargetExtensions
	{
		public static Entity<Game> Target(this Entity<Game> @this, params Side[] sides)
			=> @this.Add<AbilityTargets, Side[]>(sides);
	}
}