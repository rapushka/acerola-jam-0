using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
	{
		[SerializeField] private GameConfig _gameConfig;

		public override void InstallBindings()
		{
			Container.BindInstance(Contexts.Instance).AsSingle();
			Container.Bind<ContextsInitializer>().AsSingle().NonLazy();
			Container.Bind<SystemsFactory>().AsSingle();

			Container.BindInstance(_gameConfig).AsSingle();
		}
	}
}