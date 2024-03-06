using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class ChangeCurrentBetButton : ButtonBase
	{
		[SerializeField] private int _delta;

		protected override void OnClick()
		{
			var unique = Contexts.Instance.Get<Game>().Unique;
			var bank = unique.GetEntity<Bank>();
			var side = unique.GetEntity<CurrentTurn>();

			var newBet = bank.Get<CurrentBet>().Value + _delta;
			var minBet = bank.Get<MinBet>().Value;
			var allIn = side.Get<Money>().Value;
			newBet = Mathf.Clamp(newBet, minBet, allIn);

			bank.Replace<CurrentBet, int>(newBet);
		}
	}
}