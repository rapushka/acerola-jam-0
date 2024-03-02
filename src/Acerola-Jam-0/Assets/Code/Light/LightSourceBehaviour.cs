using Code.Component;

namespace Code
{
	public class LightSourceBehaviour : PositionedBehaviour
	{
		public override void Initialize()
		{
			base.Initialize();

			Entity
				.Add<DebugName, string>("Light source")
				.Is<LightSource>(true)
				;
		}
	}
}