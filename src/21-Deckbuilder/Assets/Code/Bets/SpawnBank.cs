using Entitas;
using Zenject;

namespace Code.System
{
	public sealed class SpawnBank : IInitializeSystem
	{
		private readonly BetsFactory _factory;

		[Inject]
		public SpawnBank(BetsFactory factory) => _factory = factory;

		public void Initialize() => _factory.CreateBank();
	}
}