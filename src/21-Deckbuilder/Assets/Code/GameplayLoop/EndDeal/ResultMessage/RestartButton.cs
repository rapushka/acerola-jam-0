using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code.EndDeal
{
	public class RestartButton : ButtonBase
	{
		[SerializeField] private EntityBehaviour<Game> _behaviour;

		protected override void OnClick()
		{
			Contexts.Instance.Get<Game>().CreateEntity().Is<StartDeal>(true);
			_behaviour.Entity.Replace<Visible, bool>(false);
		}
	}
}