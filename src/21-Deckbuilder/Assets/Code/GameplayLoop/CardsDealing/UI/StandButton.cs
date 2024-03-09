using Code.Component;
using Entitas.Generic;

namespace Code
{
	public class StandButton : PlayerTurnButtonBase
	{
		protected override void OnClick()
		{
			var player = Contexts.Instance.GetPlayer();
			player.Is<Stand>(false);
			player.Is<Stand>(true);
		}
	}
}