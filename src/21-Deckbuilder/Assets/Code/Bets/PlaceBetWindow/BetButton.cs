using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class BetButton : ButtonBase
	{
		protected override void OnClick()
			=> Contexts.Instance.Get<Game>().Unique.GetEntity<CurrentTurn>().Is<Bet>(true);
	}
}