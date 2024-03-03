using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class StartGame : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public StartGame(Contexts contexts) => _contexts = contexts;

		public void Initialize() => _contexts.Get<Game>().CreateEntity().Is<StartDeal>(true);
	}
}