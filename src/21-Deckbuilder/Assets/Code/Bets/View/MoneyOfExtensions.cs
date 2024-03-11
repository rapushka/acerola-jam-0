using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class MoneyOfExtensions
	{
		public static int GetMoney(this Entity<Game> @this)
		{
			return @this.GetMoneyHeap().Get<Money>().Value;
		}

		public static void SubtractMoneyValue(this Entity<Game> @this, int value)
			=> @this.AddMoneyValue(-value);

		public static void AddMoneyValue(this Entity<Game> @this, int value)
			=> @this.GetMoneyHeap().AddValue<Money>(value);

		public static void ReplaceMoney(this Entity<Game> @this, int value)
			=> @this.GetMoneyHeap().Replace<Money, int>(value);

		public static Entity<Game> GetMoneyHeap(this Entity<Game> @this)
		{
			var side = @this.Get<Component.Side>().Value;
			return Contexts.Instance.Get<Game>().GetPrimaryIndex<MoneyOf, Side>().GetEntity(side);
		}
	}
}