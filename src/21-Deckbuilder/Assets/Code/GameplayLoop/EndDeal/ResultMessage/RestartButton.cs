using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.EndDeal
{
	public class RestartButton : ButtonBase
	{
		[SerializeField] private HudMediator _hud;

		protected override void OnClick()
		{
			Contexts.Instance.Get<Game>().CreateEntity().Is<StartDeal>(true);
			_hud.HideDealEndScreen();
		}
	}
}