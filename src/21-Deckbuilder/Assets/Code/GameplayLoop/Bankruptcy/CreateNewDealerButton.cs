using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class CreateNewDealerButton : ButtonBase
	{
		protected override void OnClick() => Contexts.Instance.Get<Game>().CreateEntity().Is<CreateNewDealer>(true);
	}
}