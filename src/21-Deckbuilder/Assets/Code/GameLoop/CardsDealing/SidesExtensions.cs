using Code.Scope;
using Entitas.Generic;

namespace Code.System
{
	public static class SidesExtensions
	{
		public static Entity<Game> GetPlayer(this Contexts @this) => @this.GetSide(Side.Player);
		public static Entity<Game> GetDealer(this Contexts @this) => @this.GetSide(Side.Dealer);

		public static Entity<Game> GetSide(this Contexts @this, Side side)
			=> @this.Get<Game>().GetPrimaryIndex<Component.Side, Side>().GetEntity(side);
	}
}