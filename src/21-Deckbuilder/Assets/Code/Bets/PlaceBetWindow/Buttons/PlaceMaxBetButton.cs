using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class PlaceMaxBetButton : ButtonBase
	{
		protected override void OnClick()
		{
			var unique = Contexts.Instance.Get<Game>().Unique;
			var bank = unique.GetEntity<Bank>();
			var side = unique.GetEntity<CurrentTurn>();

			var allIn = side.Get<Money>().Value;

			bank.Replace<CurrentBet, int>(allIn);
		}
	}
}