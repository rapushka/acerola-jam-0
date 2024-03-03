using System.Collections.Generic;
using Code.Component;
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

		public static Side Flip(this Side @this) => @this is Side.Player ? Side.Dealer : Side.Player;

		public static IEnumerable<Entity<Game>> GetCards(this Entity<Game> side)
			=> Contexts.Instance.Get<Game>().GetIndex<HeldBy, Side>().GetEntities(side.Get<Component.Side>().Value);

		public static Entity<Game> GetHolder(this Entity<Game> card)
			=> Contexts.Instance.Get<Game>().GetPrimaryIndex<Component.Side, Side>()
			           .GetEntity(card.Get<Component.Side>().Value);
	}
}