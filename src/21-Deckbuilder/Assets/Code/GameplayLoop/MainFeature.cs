using Code.System;
using Zenject;

namespace Code
{
	public sealed class MainFeature : InjectableFeature
	{
		[Inject]
		public MainFeature(SystemsFactory factory)
			: base(nameof(MainFeature), factory)
		{
			Add<StartGame>();
			Add<SpawnSides>();

			// On Start Deal
			Add<SpawnDeck>();
			Add<StartWithPlayerTurn>();
			Add<DealTwoCards>();

			Add<AiChooseAction>();

			Add<CalculateScore>();

			Add<SideHit>();
			Add<PassTurnToNext>();

			Add<EndDeal>();

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