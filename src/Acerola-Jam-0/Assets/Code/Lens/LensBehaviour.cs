using Code.Component;

namespace Code
{
	public class LensBehaviour : DraggableBehaviour
	{
		public override void Initialize()
		{
			base.Initialize();

			Entity
				.Is<Lens>(true)
				;
		}
	}
}