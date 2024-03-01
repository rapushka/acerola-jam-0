using Code.Component;

namespace Code
{
	public class LensBehaviour : DraggableBehaviourBase
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