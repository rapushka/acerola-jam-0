using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class RotationView : BaseListener<Game, Rotation>
	{
		public override void OnValueChanged(Entity<Game> entity, Rotation component)
			=> transform.rotation = component.Value;
	}
}