using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public class GameplaySceneInstaller : MonoInstallerBase<GameplaySceneInstaller>
	{
		[SerializeField] private HoldersProvider _holdersProvider;
		[SerializeField] private HudMediator _hud;
		[SerializeField] private BehavioursCollector _behavioursCollector;
		[SerializeField] private StandSign _opponentStandSign;

		public override void InstallBindings()
		{
			base.InstallBindings();

			Container.Bind<MainFeature>().AsSingle();
			Container.Bind<MainFeatureAdapter>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();

			Container.BindInstance(_behavioursCollector.Behaviours).AsSingle();
			Container.BindInstance(_holdersProvider).AsSingle();
			Container.BindInstance(_hud).AsSingle();
			Container.BindInstance(_opponentStandSign).AsSingle();

			Container.Bind<CardsFactory>().AsSingle();
			Container.Bind<SidesFactory>().AsSingle();

			Container.Bind<DeckProvider>().AsSingle().NonLazy();
			Container.Bind<ShadowCardsProvider>().AsSingle();
			Container.Bind<BetsFactory>().AsSingle();

			Container.Bind<CalculateScoreCommand>().AsSingle();
			Container.Bind<TurnActionDecisionMaker>().AsSingle();
		}
	}
}