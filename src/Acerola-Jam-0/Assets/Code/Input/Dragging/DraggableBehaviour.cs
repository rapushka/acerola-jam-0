using Code.Component;

namespace Code
{
	public class DraggableBehaviour : PositionedBehaviour
	{
		public override void Initialize()
		{
			base.Initialize();

			Entity
				.Is<Draggable>(true)
				;
		}
	}
}