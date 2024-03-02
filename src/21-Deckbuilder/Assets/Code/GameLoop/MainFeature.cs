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
			Add<SpawnDeck>();
			Add<SpawnSides>();

			Add<DealTwoCardsOnStart>();

			// View
			Add<MoveHeldCardToSideHands>();
			Add<MoveToDestination>();

			Add<BoilerplateFeature>();
		}
	}
}