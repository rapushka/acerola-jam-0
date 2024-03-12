using Code.Component;
using Entitas.Generic;

namespace Code
{
	public abstract class PlayerTurnButtonBase : ButtonBase
	{
		private void Update()
			=> Button.enabled = Contexts.Instance.GetPlayer().Is<CurrentTurn>();
	}
}