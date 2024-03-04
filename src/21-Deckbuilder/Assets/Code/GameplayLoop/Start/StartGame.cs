using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class StartGame : IInitializeSystem
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;

		[Inject]
		public StartGame(Contexts contexts, HudMediator hud)
		{
			_contexts = contexts;
			_hud = hud;
		}

		public void Initialize()
		{
			_hud.HideDealEndScreen();
			_hud.PickCardOptionsVisibility = false;
			_contexts.Get<Game>().CreateEntity().Is<StartDeal>(true);
		}
	}
}