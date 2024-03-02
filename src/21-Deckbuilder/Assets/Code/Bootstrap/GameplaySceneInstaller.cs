namespace Code
{
	public class GameplaySceneInstaller : MonoInstallerBase<GameplaySceneInstaller>
	{
		public override void InstallBindings()
		{
			base.InstallBindings();

			Container.Bind<MainFeature>().AsSingle();
			Container.Bind<MainFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
		}
	}
}