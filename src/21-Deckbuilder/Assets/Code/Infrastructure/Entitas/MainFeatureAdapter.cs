using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class MainFeatureAdapter : FeatureAdapterBase
	{
		private MainFeature _mainFeature;

		[Inject]
		public void Construct(MainFeature mainFeature)
			=> _mainFeature = mainFeature;

		protected override Systems CreateSystems() => _mainFeature;
	}
}