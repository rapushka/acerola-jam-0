using Entitas;
using Zenject;

namespace Code
{
	public class SystemsFactory
	{
		private readonly DiContainer _diContainer;

		[Inject] public SystemsFactory(DiContainer diContainer) => _diContainer = diContainer;

		public TSystem Create<TSystem>()
			where TSystem : ISystem
			=> _diContainer.Instantiate<TSystem>();
	}
}