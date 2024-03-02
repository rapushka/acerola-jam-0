using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class PositionView : BaseListener<Game, Position>
	{
		public override void OnValueChanged(Entity<Game> entity, Position component) 
			=> transform.position = component.Value;
	}
}