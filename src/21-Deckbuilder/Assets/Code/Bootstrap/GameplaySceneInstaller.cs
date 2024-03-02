using UnityEngine;

namespace Code
{
	public class GameplaySceneInstaller : MonoInstallerBase<GameplaySceneInstaller>
	{
		[SerializeField] private HoldersProvider _holdersProvider;
		[SerializeField] private HudMediator _hud;

		public override void InstallBindings()
		{
			base.InstallBindings();

			Container.Bind<MainFeature>().AsSingle();
			Container.Bind<MainFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			Container.BindInstance(_holdersProvider).AsSingle();
			Container.BindInstance(_hud).AsSingle();

			Container.Bind<CardsFactory>().AsSingle();
		}
	}
}