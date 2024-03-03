using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class VisibleView : BaseListener<Game, Visible>
	{
		public override void OnValueChanged(Entity<Game> entity, Visible component)
			=> gameObject.SetActive(component.Value);
	}
}