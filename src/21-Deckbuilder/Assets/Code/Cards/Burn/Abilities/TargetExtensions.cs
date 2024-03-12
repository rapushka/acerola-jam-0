using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class TargetExtensions
	{
		private static Entity<Game> CurrentTurn => Contexts.Instance.Get<Game>().Unique.GetEntity<CurrentTurn>();

		public static Entity<Game> Target(this Entity<Game> @this, params RelativeSide[] sides)
			=> @this.Add<AbilityTargets, RelativeSide[]>(sides);

		public static Entity<Game> GetEntity(this Contexts contexts, RelativeSide relativeSide)
			=> contexts.Get<Game>().GetPrimaryIndex<Component.Side, Side>().GetEntity(relativeSide.AbsoluteSide());

		public static Side AbsoluteSide(this RelativeSide relativeSide)
		{
			var currentSide = CurrentTurn.Get<Component.Side>().Value;
			var side = currentSide;
			if (relativeSide is RelativeSide.Opponent)
				side = currentSide.Flip();

			return side;
		}
	}
}