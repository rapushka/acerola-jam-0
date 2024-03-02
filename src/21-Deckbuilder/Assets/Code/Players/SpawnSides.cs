using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class SpawnSides : IInitializeSystem
	{
		private readonly Contexts _contexts;

		public SpawnSides(Contexts contexts)
		{
			_contexts = contexts;
		}

		public void Initialize()
		{
			SpawnPlayer();
			SpawnDealer();
		}

		private void SpawnPlayer()
		{
			var e = _contexts.Get<Game>().CreateEntity();
			e.Add<Component.Side, Side>(Side.Player);
		}

		private void SpawnDealer()
		{
			var e = _contexts.Get<Game>().CreateEntity();
			e.Add<Component.Side, Side>(Side.Dealer);
		}
	}
}