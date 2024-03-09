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
			Add<RespawnDealer>();
			Add<HideWinAndLooseScreens>();
			Add<SidesKeepPlaying>();
			Add<ResetScore>();
			Add<SetupDefaultRules>();
			Add<DestroyOldDeck>();
			Add<SpawnDeck>();
			Add<BindAbilities>();
			Add<ResetMinBetInBank>();
			Add<StartWithPlayerTurn>();
			Add<MoveCameraToPlayerSitting>();
#if DEBUG
			Add<PutSomeCardOnTopOfTheDeck>();
#endif

			// Generic things
			Add<WaitingSystem>();
			Add<CalculateScore>();

			// Enemy's AI (not ML!!!!!)
			Add<AiTurnAction>();
			Add<AiCardPickingAction>();
			Add<AiBet>();

			// Card Actions
			Add<CancelHitOnMaxCardsInHand>();
			Add<SideHit>();
			Add<SideStand>();
			Add<CancelBurnOfUnBurnableCard>();
			Add<PickCandidate>(); // Both burn and take

			// Cards burning
			Add<BurnCard>();
			// ## OnBurn Abilities
			// Add<LogBurnedSystem>();
			Add<CastChangePoints>();
			Add<CastDestroyAllSuit>();
			Add<CastChangePointThreshold>();
			Add<CastChangeMaxCardsInHand>();
			Add<CastFlipWinCondition>();

			// Bets
			Add<DoneCardActions>();
			Add<DoBet>();
			Add<DoPass>();

			// End Turn
			Add<PassTurnToNext>();

			// End Deal
			Add<MoveCameraToCardsScoring>();
			Add<MoveCardsForScoring>();
			Add<EndDeal>();
			Add<ShowOnDealEnd>();
			// Add<FlipDealerCardsOnDealEnd>();
			Add<WinnersGetBank>();
			Add<CheckBankruptcy>();

			// ---
			// # View
			// ## UI
			Add<UpdatePlayerScoreView>();
			Add<UpdateHud>();
			Add<UpdateStatus>();
			Add<UpdateStandView>();
			Add<ShowCardDescription>();
			Add<HideCardDescription>();
			// ### Bets
			Add<UpdateBets>();
			Add<ShowPlaceBetWindow>();
			Add<HidePlaceBetWindow>();
			// ## Movement
			Add<MoveCandidate>();
			Add<MoveLensToCandidate>();
			Add<MoveCardAndLensForBurning>();
			Add<MoveHeldCardToSideHands>();
			Add<CenterAlignCardsInHands>();
			Add<MoveToTarget>();
			// ## Rotation
			Add<FlipRotation>();
			Add<RotateToTarget>();

			Add<BoilerplateFeature>();

			// Tear Down
			Add(new ClearReactivitySystem(this));
			Add<DestroyAll>();
		}
	}
}