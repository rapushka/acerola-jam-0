using Code.Scope;
using Entitas.Generic;

namespace Code.System
{
	public static class EnemyAiExtensions
	{
		public static Entity<Game> Remark<TComponent>(this Entity<Game> @this)
			where TComponent : FlagComponent, IInScope<Game>, new()
			=> @this.Is<TComponent>(false).Is<TComponent>(true);
	}
}