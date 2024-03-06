using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class EntitasMathExtensions
	{
		public static Entity<Game> SubtractValue<TComponent>(this Entity<Game> @this, int value)
			where TComponent : ValueComponent<int>, IInScope<Game>, new()
		{
			return @this.AddValue<TComponent>(-value);
		}

		public static Entity<Game> AddValue<TComponent>(this Entity<Game> @this, int value)
			where TComponent : ValueComponent<int>, IInScope<Game>, new()
		{
			@this.Replace<TComponent, int>(@this.Get<TComponent>().Value + value);
			return @this;
		}
	}
}