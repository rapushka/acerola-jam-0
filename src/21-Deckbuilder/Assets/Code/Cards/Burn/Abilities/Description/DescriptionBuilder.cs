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

			BuildChangePoints(card, ref stringBuilder, relatives);
			BuildDestroyAllSuit(card, ref stringBuilder);
			BuildChangePointsThreshold(card, ref stringBuilder);
			BuildChangeMaxCardsInHand(card, ref stringBuilder);
			BuildInvokeFlipWinCondition(card, ref stringBuilder);
			BuildCanNotBeBurn(card, ref stringBuilder);
			BuildDestroyAllCardsInHand(card, ref stringBuilder, relatives);

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
			stringBuilder.Append(string.Join("\nand ", Relatives(targets, relatives)));
			stringBuilder.Append("\n\n");
			return;
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

			// "Destroys all cards of you (Player) and opponent (Dealer)"
			stringBuilder.Append("Destroys all cards of ");
			stringBuilder.Append(string.Join("\nand ", Relatives(targets, relatives)));
			stringBuilder.Append("\n\n");
		}

		private IEnumerable<string> Relatives(IEnumerable<RelativeSide> relativeTargets, bool relatives)
			=> relatives
				? relativeTargets.Select((t) => $"{t} ({t.AbsoluteSide()})")
				: relativeTargets.Select((t) => t.ToString());
	}
}