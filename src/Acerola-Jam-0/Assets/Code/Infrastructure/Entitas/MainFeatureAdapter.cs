using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class MainFeatureAdapter : FeatureAdapterBase
	{
		private MainFeature _feature;

		[Inject] public void Construct(MainFeature feature) => _feature = feature;

		protected override Systems CreateSystems() => _feature;
	}

}