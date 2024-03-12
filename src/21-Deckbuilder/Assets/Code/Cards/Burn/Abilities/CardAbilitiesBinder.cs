using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using static Code.CardFace;
using static Code.CardSuit;
using static Code.RelativeSide;

namespace Code
{
	public class CardAbilitiesBinder
	{
		private readonly Dictionary<CardId, Action<Entity<Game>>> _abilities = new()
		{
			[(Ace, Spades)] = (e) => e.Add<ChangePoints, int>(2).Target(You),
			[(Queen, Clubs)] = (e) => e.Add<ChangePoints, int>(1).Target(Opponent),
			[(Number5, Diamonds)] = (e) => e.Add<ChangePoints, int>(-2).Target(You, Opponent),
			[(King, Hearts)] = (e) => e.Add<DestroyAllSuit, CardSuit>(Diamonds),
			[(Jack, Spades)] = (e) => e.Add<ChangePointsThreshold, int>(-2),
			[(Number2, Diamonds)] = (e) => e.Add<ChangePointsThreshold, int>(2),
			[(Number10, Hearts)] = (e) => e.Add<ChangeMaxCardsInHand, int>(-2),
			[(Number7, Clubs)] = (e) => e.Is<InvokeFlipWinCondition>(true),
			[(Ace, Hearts)] = (e) => e.Is<CanNotBeBurn>(true),
			[(Number2, Clubs)] = (e) => e.Is<DestroyAllCardsInHand>(true).Target(You),
		};

		public void Bind(Entity<Game> target)
		{
			var face = target.Get<Face>().Value;

			if (_abilities.TryGetValue(face, out var ability))
				ability.Invoke(target);
		}
	}
}