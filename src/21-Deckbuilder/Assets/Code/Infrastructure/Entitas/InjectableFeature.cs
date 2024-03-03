using Entitas;
using Zenject;

namespace Code
{
	public abstract class InjectableFeature : Feature
	{
		private readonly SystemsFactory _factory;

		[Inject]
		protected InjectableFeature(string name, SystemsFactory factory)
			: base(name)
			=> _factory = factory;

		protected TSystem Add<TSystem>()
			where TSystem : ISystem
		{
			var system = _factory.Create<TSystem>();
			Add(system);
			return system;
		}
	}
}