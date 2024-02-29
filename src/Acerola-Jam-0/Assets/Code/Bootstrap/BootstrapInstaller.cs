using Entitas.Generic;
using Zenject;

namespace Code
{
	public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
	{
		public override void InstallBindings()
		{
			Container.BindInstance(Contexts.Instance).AsSingle();
			Container.Bind<ContextsInitializer>().AsSingle().NonLazy();
			Container.Bind<SystemsFactory>().AsSingle();
		}
	}
}