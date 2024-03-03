using Code.Component;
using Code.System;
using Entitas.Generic;

namespace Code
{
	public class HitButton : GameplayButtonBase
	{
		protected override void OnClick() => Contexts.Instance.GetPlayer().Is<Hit>(true);
	}
}