using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class CreateNewDealerButton : ButtonBase
	{
		protected override void OnClick()
		{
			var context = Contexts.Instance.Get<Game>();
			context.CreateEntity().Is<CreateNewDealer>(true);
			context.CreateEntity().Is<StartDeal>(true);
		}
	}
}