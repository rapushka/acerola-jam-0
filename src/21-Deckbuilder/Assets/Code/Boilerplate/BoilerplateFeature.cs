using Code.Component;
using Code.Scope;
using Entitas.Generic;

namespace Code.System
{
	public class BoilerplateFeature : InjectableFeature
	{
		public BoilerplateFeature(SystemsFactory factory)
			: base(nameof(BoilerplateFeature), factory)
		{
			Add<SelfEventSystem<Game, Face>>();
			Add<SelfEventSystem<Game, Suit>>();
			Add<SelfEventSystem<Game, Position>>();
			Add<SelfEventSystem<Game, Rotation>>();
			Add<SelfEventSystem<Game, Visible>>();

			Add<RemoveComponentsSystem<Game, Hit>>();

			Add<DestroyEntitySystem<Game, StartDeal>>();
			Add<DestroyEntitySystem<Game, Component.EndDeal>>();
		}
	}
}