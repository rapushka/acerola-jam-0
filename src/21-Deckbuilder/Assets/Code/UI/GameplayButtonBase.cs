using Code.Component;
using Code.System;
using Entitas.Generic;

namespace Code
{
	public abstract class GameplayButtonBase : ButtonBase
	{
		private void Update()
			=> Button.enabled = Contexts.Instance.GetPlayer().Is<CurrentTurn>();
	}
}