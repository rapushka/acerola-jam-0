using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class PlaceMinBetButton : ButtonBase
	{
		protected override void OnClick()
		{
			var bank = Contexts.Instance.Get<Game>().Unique.GetEntity<Bank>();
			var minBet = bank.Get<MinBet>().Value;

			bank.Replace<CurrentBet, int>(minBet);
		}
	}
}