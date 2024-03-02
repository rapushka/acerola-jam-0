using UnityEngine;

namespace Code
{
	public class GameplaySceneInstaller : MonoInstallerBase<GameplaySceneInstaller>
	{
		[SerializeField] private HoldersProvider _holdersProvider;

		public override void InstallBindings()
		{
			base.InstallBindings();

			Container.Bind<MainFeature>().AsSingle();
			Container.Bind<MainFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			Container.BindInstance(_holdersProvider).AsSingle();

			Container.Bind<CardsFactory>().AsSingle();
		}
	}
}