using Code.Component;
using Code.Scope;
using Entitas.Generic;
using Zenject;

namespace Code.System
{
	public class BoilerplateFeature : InjectableFeature
	{
		[Inject]
		public BoilerplateFeature(SystemsFactory factory)
			: base(nameof(BoilerplateFeature), factory)
		{
			Add<SelfEventSystem<Game, Position>>();
			Add<SelfEventSystem<Game, DeltaRotation>>();
			Add<SelfEventSystem<Game, VectorFromLight>>();

			Add<RemoveComponentsSystem<Game, Dropped>>();
		}
	}
}