using Code.Players;
using Code.System;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class MainFeature : InjectableFeature
	{
		[Inject]
		public MainFeature(SystemsFactory factory)
			: base(nameof(MainFeature), factory)
		{
			Add<RegisterBehavioursSystem>();

			Add<StartGame>();
			Add<SpawnSides>();

			// On Start Deal
			Add<ResetScore>();
			Add<DestroyOldDeck>();
			Add<SpawnDeck>();
			Add<StartWithPlayerTurn>();

			Add<AiChooseAction>();

			Add<CalculateScore>();

			Add<SideHit>();
			Add<MoveCandidate>();
			Add<MoveLensToCandidate>();
			Add<PassTurnToNext>();

			Add<System.EndDeal>();
			Add<ShowOnDealEnd>();

			// # View
			// ## UI
			Add<UpdatePlayerScoreView>();
			// ## Movement
			Add<MoveHeldCardToSideHands>();
			Add<CenterAlignCardsInHands>();
			Add<MoveToDestination>();
			// ## Rotation
			Add<RotatePlayerCards>();
			Add<RotateToTarget>();

			Add<BoilerplateFeature>();
		}
	}
}