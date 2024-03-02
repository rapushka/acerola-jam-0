using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code
{
	public class BoilerplateFeature : InjectableFeature
	{
		public BoilerplateFeature(SystemsFactory factory)
			: base(nameof(BoilerplateFeature), factory)
		{
			Add<SelfEventSystem<Game, Face>>();
			Add<SelfEventSystem<Game, Suit>>();
		}
	}
}