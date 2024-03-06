using Entitas;

namespace Code
{
	public class ClearReactivitySystem : ITearDownSystem
	{
		private readonly MainFeature _feature;

		public ClearReactivitySystem(MainFeature feature)
			=> _feature = feature;

		public void TearDown()
			=> _feature.DeactivateReactiveSystems();
	}
}