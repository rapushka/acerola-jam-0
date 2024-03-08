using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using static Code.CardFace;
using static Code.CardSuit;
using static Code.Side;

namespace Code
{
	public class CardAbilitiesBinder
	{
		private readonly Dictionary<CardId, Action<Entity<Game>>> _abilities = new()
		{
			[(Ace, Spades)] = (e) => e.Add<ChangePoints, int>(2).Target(Player),
		};

		public void Bind(Entity<Game> target)
		{
			var face = target.Get<Face>().Value;

			if (_abilities.TryGetValue(face, out var ability))
				ability.Invoke(target);
		}
	}
}