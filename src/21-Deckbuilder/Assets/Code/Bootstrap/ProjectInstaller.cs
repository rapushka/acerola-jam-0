using Entitas.Generic;

namespace Code
{
	public class ProjectInstaller : MonoInstallerBase<ProjectInstaller>
	{
		public override void InstallBindings()
		{
			base.InstallBindings();

			Container.BindInstance(Contexts.Instance).AsSingle();
			Container.Bind<ContextsInitializer>().AsSingle().NonLazy();
		}
	}
}