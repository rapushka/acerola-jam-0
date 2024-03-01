using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class GameplaySceneInstaller : MonoInstaller<GameplaySceneInstaller>
	{
		[SerializeField] private BehavioursCollector _behavioursCollector;

		public override void InstallBindings()
		{
			Container.BindInstance(_behavioursCollector.Behaviours).AsSingle();

			Container.Rebind<SystemsFactory>().AsSingle();

			Container.Bind<MainFeature>().AsSingle();
			Container.Bind<MainFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
		}
	}
}