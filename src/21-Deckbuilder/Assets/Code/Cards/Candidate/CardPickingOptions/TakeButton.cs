using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class TakeButton : ButtonBase
	{
		protected override void OnClick() => Contexts.Instance.Get<Game>().CreateEntity().Add<TakeCandidate>();
	}
}