using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class ProjectInstaller : MonoInstallerBase<ProjectInstaller>
	{
		[SerializeField] private DeckViewConfig _deckViewConfig;
		[SerializeField] private ResourceConfig _resourceConfig;

		public override void InstallBindings()
		{
			base.InstallBindings();

			Container.BindInstance(_deckViewConfig).AsSingle();

			Container.BindInstance(Contexts.Instance).AsSingle();
			Container.Bind<ContextsInitializer>().AsSingle().NonLazy();
			Container.Bind<IResourcesProvider>().FromInstance(_resourceConfig).AsSingle();

			Container.Inject(_resourceConfig);
		}
	}
}