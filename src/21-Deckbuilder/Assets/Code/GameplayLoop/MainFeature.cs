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
			Add<ResetMinBetInBank>();
			Add<StartWithPlayerTurn>();

			// Generic things
			Add<WaitingSystem>();
			Add<CalculateScore>();

			// Enemy's AI (not ML!!!!!)
			Add<AiTurnAction>();
			Add<AiCardPickingAction>();
			Add<AiBet>();

			// Card Actions
			Add<SideHit>();
			Add<SideStand>();
			Add<PickCandidate>(); // Both burn and take

			// Cards burning
			Add<BurnCard>();
			Add<LogBurnedSystem>();

			// Bets
			Add<DoneCardActions>();
			Add<DoBet>();
			Add<DoPass>();

			// End Turn
			Add<PassTurnToNext>();

			// End Deal
			Add<EndDeal>();
			Add<ShowOnDealEnd>();
			Add<WinnersGetBank>();
			Add<CheckBankruptcy>();

			// ---
			// # View
			// ## UI
			Add<UpdatePlayerScoreView>();
			Add<UpdateHud>();
			Add<UpdateStatus>();
			Add<UpdateStandView>();
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
			Add<RotatePlayerCards>();
			Add<RotateToTarget>();

			Add<BoilerplateFeature>();

			// Tear Down
			Add(new ClearReactivitySystem(this));
			Add<DestroyAll>();
		}
	}
}