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

			// "Adds 5 points to Player and Dealer"
			stringBuilder.Append(delta > 0 ? "Adds " : "Subtracts ");
			stringBuilder.Append(Mathf.Abs(delta));
			stringBuilder.Append(" points to ");
			stringBuilder.Append(string.Join(" and ", targets));
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
	}
}