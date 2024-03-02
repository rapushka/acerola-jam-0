using Code.Component;

namespace Code
{
	public class LensBehaviour : RotatableBehaviour
	{
		public override void Initialize()
		{
			base.Initialize();

			Entity
				.Add<DebugName, string>("Lens")
				.Is<Lens>(true)
				;
		}
	}
}