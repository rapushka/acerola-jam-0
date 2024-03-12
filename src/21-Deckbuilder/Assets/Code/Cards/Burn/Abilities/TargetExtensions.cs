using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class TargetExtensions
	{
		public static Entity<Game> Target(this Entity<Game> @this, params RelativeSide[] sides)
			=> @this.Add<AbilityTargets, RelativeSide[]>(sides);

		public static Entity<Game> GetEntity(this Contexts contexts, RelativeSide relativeSide)
		{
			var currentSide = contexts.Get<Game>().Unique.GetEntity<CurrentTurn>().Get<Component.Side>().Value;
			var side = currentSide;
			if (relativeSide is RelativeSide.Opponent)
				side = currentSide.Flip();

			return contexts.Get<Game>().GetPrimaryIndex<Component.Side, Side>().GetEntity(side);
		}
		
	}
}