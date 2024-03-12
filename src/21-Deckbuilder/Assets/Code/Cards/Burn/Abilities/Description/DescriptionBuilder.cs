using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DescriptionBuilder
	{
		public string Build(Entity<Game> card, bool relatives = false)
		{
			var stringBuilder = new StringBuilder();

			BuildDestroyAllSuit(card, ref stringBuilder);
			BuildDestroyAllCardsInHand(card, ref stringBuilder, relatives);
			BuildChangePoints(card, ref stringBuilder, relatives);
			BuildChangePointsThreshold(card, ref stringBuilder);
			BuildChangeMaxCardsInHand(card, ref stringBuilder);
			BuildInvokeFlipWinCondition(card, ref stringBuilder);
			BuildDraftCards(card, ref stringBuilder, relatives);
			BuildCanNotBeBurn(card, ref stringBuilder);

			BuildEmptyDescription(ref stringBuilder);

			return stringBuilder.ToString().Trim();
		}

		private void BuildEmptyDescription(ref StringBuilder stringBuilder)
		{
			if (stringBuilder.Length > 0)
				return;

			stringBuilder.Append("nothing's gonna happen");
			stringBuilder.Append("\n\n");
		}

		private void BuildChangePoints(Entity<Game> card, ref StringBuilder stringBuilder, bool relatives)
		{
			if (!card.Has<ChangePoints>())
				return;

			var delta = card.Get<ChangePoints>().Value;
			var targets = card.Get<AbilityTargets>().Value;

			// "+5 points to You (Player) and Opponent (Dealer)"
			stringBuilder.Append(delta > 0 ? "+" : "-");
			stringBuilder.Append(Mathf.Abs(delta));
			stringBuilder.Append(" points to ");
			stringBuilder.Append(FormatTargets(targets, relatives));
			stringBuilder.Append("\n\n");
		}

		private void BuildChangePointsThreshold(Entity<Game> card, ref StringBuilder stringBuilder)
		{
			if (!card.Has<ChangePointsThreshold>())
				return;

			var delta = card.Get<ChangePointsThreshold>().Value;

			// "Max points threshold +2"
			stringBuilder.Append("Max points threshold ");
			stringBuilder.Append(delta > 0 ? "+" : "-");
			stringBuilder.Append(Mathf.Abs(delta));
			stringBuilder.Append("\n\n");
		}

		private void BuildDestroyAllSuit(Entity<Game> card, ref StringBuilder stringBuilder)
		{
			if (!card.Has<DestroyAllSuit>())
				return;

			var suit = card.Get<DestroyAllSuit>().Value;

			// "Destroys all cards of Spades"
			stringBuilder.Append("Destroys all cards of ");
			stringBuilder.Append(suit.Sign());
			stringBuilder.Append("\n\n");
		}

		private void BuildChangeMaxCardsInHand(Entity<Game> card, ref StringBuilder stringBuilder)
		{
			if (!card.Has<ChangeMaxCardsInHand>())
				return;

			var delta = card.Get<ChangeMaxCardsInHand>().Value;

			// "Max Cards In Hand Count -2"
			stringBuilder.Append("Max Cards In Hand Count ");
			stringBuilder.Append(delta > 0 ? "+" : "-");
			stringBuilder.Append(Mathf.Abs(delta));
			stringBuilder.Append("\n\n");
		}

		private void BuildInvokeFlipWinCondition(Entity<Game> card, ref StringBuilder stringBuilder)
		{
			if (!card.Has<InvokeFlipWinCondition>())
				return;

			stringBuilder.Append("Flip Win Condition\n(Fewest points Wins)");
			stringBuilder.Append("\n\n");
		}

		private void BuildCanNotBeBurn(Entity<Game> card, ref StringBuilder stringBuilder)
		{
			if (!card.Has<CanNotBeBurn>())
				return;

			stringBuilder.Append("Can't be burn");
			stringBuilder.Append("\n\n");
		}

		private void BuildDestroyAllCardsInHand(Entity<Game> card, ref StringBuilder stringBuilder, bool relatives)
		{
			if (!card.Has<DestroyAllCardsInHand>())
				return;

			var targets = card.Get<AbilityTargets>().Value;

			// "Destroys all your (Player) and opponent's (Dealer) cards"
			stringBuilder.Append("Destroys all ");
			stringBuilder.Append(Ownership(targets, relatives));
			stringBuilder.Append(" cards");
			stringBuilder.Append("\n\n");
		}

		private void BuildDraftCards(Entity<Game> card, ref StringBuilder stringBuilder, bool relatives)
		{
			if (!card.Has<DraftCards>())
				return;

			var targets = card.Get<AbilityTargets>().Value;
			var count = card.Get<DraftCards>().Value;

			// "Draws you (Player) and opponent (Dealer) 1 card"
			stringBuilder.Append("Draws ");
			stringBuilder.Append(FormatTargets(targets, relatives));
			stringBuilder.Append($" {count} ");
			stringBuilder.Append(count == 1 ? "card" : "cards");
			stringBuilder.Append("\n\n");
		}

		private string Ownership(RelativeSide[] targets, bool relatives)
			=> FormatTargets(targets, relatives)
			   .Replace("You", "Your")
			   .Replace("Opponent", "Opponent's");

		private string FormatTargets(RelativeSide[] targets, bool relatives)
			=> string.Join("\nand ", Relatives(targets, relatives));

		private IEnumerable<string> Relatives(IEnumerable<RelativeSide> relativeTargets, bool relatives)
			=> relatives
				? relativeTargets.Select((t) => $"{t} ({t.AbsoluteSide()})")
				: relativeTargets.Select((t) => t.ToString());
	}
}