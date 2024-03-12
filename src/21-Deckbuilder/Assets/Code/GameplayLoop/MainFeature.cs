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
			// Add<EndScoringOnStartDeal>();
#if DEBUG
			Add<PutSomeCardOnTopOfTheDeck>();
#endif

			Add<WaitingSystem>();

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
			Add<MoveCameraToBurning>();
			Add<BurnCard>();
			// ## OnBurn Abilities
			// Add<LogBurnedSystem>();
			Add<CastDestroyAllSuit>();
			Add<CastDestroyAllCardsInHand>();
			Add<CastChangePoints>();
			Add<CastChangePointThreshold>();
			Add<CastChangeMaxCardsInHand>();
			Add<CastFlipWinCondition>();
			Add<CastDraftCards>();
			Add<DestroyBurnedCard>();

			// Bets
			Add<DoneCardActions>();
			Add<DoBet>();
			Add<DoPass>();
			Add<SendBet>();

			// End Turn
			Add<PassTurnToNext>();

			// Scoring
			// Add<StartScoring>();
			Add<MoveCameraToCardsScoring>();
			Add<MoveCardsForScoring>();
			Add<EndScoring>();

			// End Deal
			Add<EndDeal>();
			Add<ShowOnDealEnd>();
			// Add<FlipDealerCardsOnDealEnd>();
			Add<WinnersGetBank>();
			Add<CheckBankruptcy>();

			Add<CalculateScore>();

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
			Add<CenterAlignCards>();
			Add<MoveToTarget>();
			Add<DestroyArrivedBet>();
			// ## Rotation
			Add<FlipRotation>();
			Add<RotateLamp>();
			Add<RotateToTarget>();

			Add<BoilerplateFeature>();

			// Tear Down
			Add(new ClearReactivitySystem(this));
			Add<DestroyAll>();
		}
	}
}