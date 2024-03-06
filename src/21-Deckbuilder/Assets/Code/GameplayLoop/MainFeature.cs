using Code.Players;
using Code.System;
using Entitas.Generic;
using Zenject;
using ShowOnDealEnd = Code.System.ShowOnDealEnd;

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
			Add<SpawnBank>();
			Add<SpawnLens>();

			// On Start Deal
			Add<SidesKeepPlaying>();
			Add<ResetScore>();
			Add<DestroyOldDeck>();
			Add<SpawnDeck>();
			Add<StartWithPlayerTurn>();

			Add<UpdateHud>();
			Add<WaitingSystem>();
			Add<CalculateScore>();

			Add<AiTurnAction>();
			Add<AiCardPickingAction>();

			Add<SideHit>();
			Add<SideStand>();
			Add<MoveCandidate>();
			Add<MoveLensToCandidate>();
			// Add<ShowPickingCardOptions>();
			Add<PickCandidate>(); // Both burn and take
			Add<MoveCardAndLensForBurning>();

			// Cards burning
			Add<BurnCard>();
			Add<LogBurnedSystem>();

			Add<EndTurn>();
			Add<PassTurnToNext>();

			Add<EndDeal>();
			Add<ShowOnDealEnd>();

			// # View
			// ## UI
			Add<UpdatePlayerScoreView>();
			// ### Bets
			Add<UpdateCurrentBet>();
			// ## Movement
			Add<MoveHeldCardToSideHands>();
			Add<CenterAlignCardsInHands>();
			Add<MoveToTarget>();
			// ## Rotation
			Add<RotatePlayerCards>();
			Add<RotateToTarget>();

			Add<BoilerplateFeature>();

			// Tear Down
			Add(new ClearReactivitySystem(this));
			Add<DestroyAll>();
		}
	}
}