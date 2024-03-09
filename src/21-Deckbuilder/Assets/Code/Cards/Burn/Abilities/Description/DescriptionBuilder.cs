using System.Text;
using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class DescriptionBuilder
	{
		public string Build(Entity<Game> card)
		{
			var stringBuilder = new StringBuilder();

			BuildChangePoints(card, ref stringBuilder);
			BuildDestroyAllSuit(card, ref stringBuilder);
			BuildChangePointsThreshold(card, ref stringBuilder);
			BuildChangeMaxCardsInHand(card, ref stringBuilder);
			BuildInvokeFlipWinCondition(card, ref stringBuilder);
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

		private void BuildChangePoints(Entity<Game> card, ref StringBuilder stringBuilder)
		{
			if (!card.Has<ChangePoints>())
				return;

			var delta = card.Get<ChangePoints>().Value;
			var targets = card.Get<AbilityTargets>().Value;

			// "+5 points to Player and Dealer"
			stringBuilder.Append(delta > 0 ? "+" : "-");
			stringBuilder.Append(Mathf.Abs(delta));
			stringBuilder.Append(" points to ");
			stringBuilder.Append(string.Join(" and ", targets));
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
			stringBuilder.Append(suit);
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

			stringBuilder.Append("Flip Win Condition\n(One with Fewest points Wins)");
			stringBuilder.Append("\n\n");
		}

		private void BuildCanNotBeBurn(Entity<Game> card, ref StringBuilder stringBuilder)
		{
			if (!card.Has<CanNotBeBurn>())
				return;

			stringBuilder.Append("Can't be burn");
			stringBuilder.Append("\n\n");
		}
	}
}