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
			// Clubs – Prekols
			[(Number2, Clubs)] = (e) => e.Bind<DestroyAllSuit>(Clubs),
			[(Number3, Clubs)] = (e) => e.NothingGonnaHappen(),
			[(Number4, Clubs)] = (e) => e.Bind<DestroyAllCardsInHand>().Target(You, Opponent).Bind<DraftCards>(2),
			[(Number5, Clubs)] = (e) => e.Bind<CanNotBeBurn>(),
			[(Number6, Clubs)] = (e) => e.Bind<ChangeMaxCardsInHand>(+15),
			[(Number7, Clubs)] = (e) => e.Bind<DestroyAllSuit>(Diamonds),
			[(Number8, Clubs)] = (e) => e.Bind<DestroyAllSuit>(Spades),
			[(Number9, Clubs)] = (e) => e.Bind<DestroyAllSuit>(Hearts),
			[(Number10, Clubs)] = (e) => e.Bind<InvokeFlipWinCondition>().Bind<ChangePoints>(-5).Target(Opponent),
			[(Jack, Clubs)] = (e) => e.Bind<DraftCards>(1).Target(You),
			[(Queen, Clubs)] = (e) => e.Bind<ChangePoints>(+10).Target(Opponent),
			[(King, Clubs)] = (e) => e.Bind<ChangePoints>(+10).Target(You),
			[(Ace, Clubs)] = (e) => e.Bind<CanNotBeBurn>(),

			// Diamonds – About collecting fewer point
			[(Number2, Diamonds)] = (e) => e.Bind<CanNotBeBurn>(),
			[(Number3, Diamonds)] = (e) => e.Bind<ChangePoints>(-20).Target(You, Opponent),
			[(Number4, Diamonds)] = (e) => e.Bind<DestroyAllCardsInHand>().Target(You),
			[(Number5, Diamonds)] = (e) => e.Bind<ChangeMaxCardsInHand>(-5),
			[(Number6, Diamonds)] = (e) => e.Bind<DraftCards>(3).Target(Opponent),
			[(Number7, Diamonds)] = (e) => e.Bind<ChangePointsThreshold>(-5),
			[(Number8, Diamonds)] = (e) => e.Bind<DestroyAllSuit>(Hearts),
			[(Number9, Diamonds)] = (e) => e.Bind<InvokeFlipWinCondition>(),
			[(Number10, Diamonds)] = (e) => e.NothingGonnaHappen(),
			[(Jack, Diamonds)] = (e) => e.Bind<DestroyAllCardsInHand>().Target(You, Opponent),
			[(Queen, Diamonds)] = (e) => e.Bind<ChangeMaxCardsInHand>(-1),
			[(King, Diamonds)] = (e) => e.Bind<ChangePoints>(-4).Target(Opponent),
			[(Ace, Diamonds)] = (e) => e.Bind<ChangePoints>(-2).Target(You, Opponent),

			// Hearts – About collecting more point
			[(Number2, Hearts)] = (e) => e.Bind<ChangePoints>(+21).Target(You, Opponent),
			[(Number3, Hearts)] = (e) => e.Bind<DraftCards>(1).Target(You),
			[(Number4, Hearts)] = (e) => e.Bind<DestroyAllCardsInHand>().Target(Opponent),
			[(Number5, Hearts)] = (e) => e.Bind<ChangePointsThreshold>(+6),
			[(Number6, Hearts)] = (e) => e.NothingGonnaHappen(),
			[(Number7, Hearts)] = (e) => e.Bind<DestroyAllSuit>(Diamonds),
			[(Number8, Hearts)] = (e) => e.Bind<ChangeMaxCardsInHand>(+10),
			[(Number9, Hearts)] = (e) => e.Bind<ChangeMaxCardsInHand>(+1),
			[(Number10, Hearts)] = (e) => e.Bind<ChangePointsThreshold>(+100),
			[(Jack, Hearts)] = (e) => e.Bind<ChangeMaxCardsInHand>(+3),
			[(Queen, Hearts)] = (e) => e.Bind<DraftCards>(1).Target(You),
			[(King, Hearts)] = (e) => e.Bind<DraftCards>(2).Target(You, Opponent),
			[(Ace, Hearts)] = (e) => e.Bind<CanNotBeBurn>(),

			// Spades – About harming opponent
			[(Number2, Spades)] = (e) => e.Bind<ChangePointsThreshold>(-1),
			[(Number3, Spades)] = (e) => e.Bind<ChangePoints>(-21).Target(Opponent),
			[(Number4, Spades)] = (e) => e.Bind<ChangePoints>(+21).Target(Opponent),
			[(Number5, Spades)] = (e) => e.Bind<InvokeFlipWinCondition>(),
			[(Number6, Spades)] = (e) => e.Bind<DraftCards>(1).Target(Opponent),
			[(Number7, Spades)] = (e) => e.Bind<ChangeMaxCardsInHand>(-10),
			[(Number8, Spades)] = (e) => e.Bind<CanNotBeBurn>(),
			[(Number9, Spades)] = (e) => e.Bind<DraftCards>(2).Target(You, Opponent),
			[(Number10, Spades)] = (e) => e.Bind<DestroyAllCardsInHand>().Target(Opponent),
			[(Jack, Spades)] = (e) => e.Bind<ChangeMaxCardsInHand>(-20).Bind<DestroyAllCardsInHand>().Target(You, Opponent),
			[(Queen, Spades)] = (e) => e.Bind<DestroyAllSuit>(Hearts),
			[(King, Spades)] = (e) => e.Bind<ChangePointsThreshold>(-5),
			[(Ace, Spades)] = (e) => e.Bind<DraftCards>(7).Target(Opponent).Bind<ChangeMaxCardsInHand>(+10),
		};

		public void Bind(Entity<Game> target)
		{
			var face = target.Get<Face>().Value;

			if (_abilities.TryGetValue(face, out var ability))
				ability.Invoke(target);
		}
	}
}