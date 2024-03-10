using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class ScoringExtensions
	{
		public static bool IsScoring(this Contexts @this) => @this.Get<Game>().Unique.Has<Scoring>();

		public static void StartScoring(this Contexts @this)
			=> @this.Get<Game>().CreateEntity().Is<Scoring>(true);

		public static void StopScoring(this Contexts @this)
		{
			var entity = @this.Get<Game>().Unique.GetEntityOrDefault<Scoring>();

			if (entity is null)
				return;

			entity.Is<Scoring>(false);
			entity.Is<Destroyed>(true);
		}
	}
}