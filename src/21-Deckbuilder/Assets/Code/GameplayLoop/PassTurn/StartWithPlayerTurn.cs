using Code.Component;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public class StartWithPlayerTurn : IInitializeSystem

	{
		private readonly Contexts _contexts;

		public StartWithPlayerTurn(Contexts contexts) => _contexts = contexts;

		public void Initialize() => _contexts.GetPlayer().Is<CurrentTurn>(true);
	}
}