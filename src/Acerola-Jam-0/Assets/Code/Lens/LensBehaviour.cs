using Code.Component;

namespace Code
{
	public class LensBehaviour : RotatableBehaviour
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