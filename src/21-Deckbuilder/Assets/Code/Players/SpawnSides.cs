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
			Spawn(Side.Player);
			Spawn(Side.Dealer);
		}

		private void Spawn(Side side)
		{
			var e = _contexts.Get<Game>().CreateEntity();
			e.Add<Component.Side, Side>(side);
			e.Add<Score, int>(0);
			e.Is<KeepPlaying>(true);
		}
	}
}