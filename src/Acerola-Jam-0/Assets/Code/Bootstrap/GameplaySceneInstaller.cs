using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class GameplaySceneInstaller : MonoInstaller<GameplaySceneInstaller>
	{
		[SerializeField] private BehavioursCollector _behavioursCollector;
		[SerializeField] private Camera _camera;

		public override void InstallBindings()
		{
			Container.BindInstance(_behavioursCollector.Behaviours).AsSingle();
			Container.BindInstance(_camera).AsSingle();

			Container.Rebind<SystemsFactory>().AsSingle();

			Container.Bind<MainFeature>().AsSingle();
			Container.Bind<MainFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			InstallServices();
		}

		private void InstallServices()
		{
			Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
		}
	}
}