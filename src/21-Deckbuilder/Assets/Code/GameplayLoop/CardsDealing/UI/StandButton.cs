using Code.Component;
using Code.System;
using Entitas.Generic;

namespace Code
{
	public class StandButton : PlayerTurnButtonBase
	{
		protected override void OnClick() => Contexts.Instance.GetPlayer().Is<KeepPlaying>(false);
	}
}