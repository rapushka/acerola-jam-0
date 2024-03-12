using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public static class SidesExtensions
	{
		public static Entity<Game> GetPlayer(this Contexts @this) => @this.GetSide(Side.Player);
		public static Entity<Game> GetDealer(this Contexts @this) => @this.GetSide(Side.Owneress);

		private static ScopeContext<Game> Context => Contexts.Instance.Get<Game>();

		public static Entity<Game> GetSide(this Contexts @this, Side side)
			=> @this.Get<Game>().GetPrimaryIndex<Component.Side, Side>().GetEntity(side);

		public static Side Flip(this Side @this) => @this is Side.Player ? Side.Owneress : Side.Player;

		public static HashSet<Entity<Game>> GetCards(this Entity<Game> side)
			=> Context.GetIndex<HeldBy, Side>().GetEntities(side.Get<Component.Side>().Value);

		public static Entity<Game> GetHolder(this Entity<Game> card)
			=> Context.GetPrimaryIndex<Component.Side, Side>()
			          .GetEntity(card.Get<Component.Side>().Value);

		public static bool IsPlayer(this Entity<Game> side) => side.Get<Component.Side>().Value is Side.Player;
		public static bool IsDealer(this Entity<Game> side) => side.Get<Component.Side>().Value is Side.Owneress;
	}
}