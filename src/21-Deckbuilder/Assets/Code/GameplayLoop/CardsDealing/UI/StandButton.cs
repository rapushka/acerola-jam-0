using Code.Component;
using Code.System;
using Entitas.Generic;

namespace Code
{
	public class StandButton : GameplayButtonBase
	{
		protected override void OnClick() => Contexts.Instance.GetPlayer().Is<Stand>(true);
	}
}