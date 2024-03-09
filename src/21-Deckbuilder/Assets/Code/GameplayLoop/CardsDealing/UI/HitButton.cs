using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class HitButton : PlayerTurnButtonBase
	{
		protected override void OnClick() => Contexts.Instance.GetPlayer().Is<Hit>(true);
	}
}