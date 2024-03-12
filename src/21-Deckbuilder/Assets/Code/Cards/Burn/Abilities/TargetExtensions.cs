using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class TargetExtensions
	{
		private static Entity<Game> CurrentTurn => Contexts.Instance.Get<Game>().Unique.GetEntity<CurrentTurn>();

		public static Entity<Game> NothingGonnaHappen(this Entity<Game> @this) => @this;

		public static Entity<Game> Bind<TComponent>(this Entity<Game> @this, int value)
			where TComponent : ValueComponent<int>, IInScope<Game>, new()
			=> @this.Add<TComponent, int>(value);

		public static Entity<Game> Bind<TComponent>(this Entity<Game> @this, CardSuit value)
			where TComponent : ValueComponent<CardSuit>, IInScope<Game>, new()
			=> @this.Add<TComponent, CardSuit>(value);

		public static Entity<Game> Bind<TComponent>(this Entity<Game> @this)
			where TComponent : FlagComponent, IInScope<Game>, new()
			=> @this.Is<TComponent>(true);

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