using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class ProjectInstaller : MonoInstallerBase<ProjectInstaller>
	{
		[SerializeField] private DeckViewConfig _deckViewConfig;

		public override void InstallBindings()
		{
			base.InstallBindings();

			Container.BindInstance(Contexts.Instance).AsSingle();
			Container.Bind<ContextsInitializer>().AsSingle().NonLazy();
		}
	}
}