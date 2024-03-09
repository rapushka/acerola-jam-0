using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class MoveCameraToCardsScoring : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public MoveCameraToCardsScoring(Contexts contexts, HoldersProvider holders)
		{
			_contexts = contexts;
			_holders = holders;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<EndDeal>());
		}

		private Entity<Game> Camera => _contexts.Get<Game>().Unique.GetEntity<Camera>();

		public void Execute()
		{
			foreach (var _ in _entities)
				Camera.SetTargetTransform(_holders.Camera.CardsScoring);
		}
	}
}