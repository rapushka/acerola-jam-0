using Entitas;

namespace Code.System
{
	public sealed class SpawnSides : IInitializeSystem
	{
		private readonly SidesFactory _sidesFactory;

		public SpawnSides(SidesFactory sidesFactory)
		{
			_sidesFactory = sidesFactory;
		}

		public void Initialize()
		{
			_sidesFactory.CreatePlayer();
			_sidesFactory.CreateDealer();
		}
	}
}