using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class MoveCameraToPlayerSitting : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public MoveCameraToPlayerSitting(Contexts contexts, HoldersProvider holders)
		{
			_contexts = contexts;
			_holders = holders;
			_entities = contexts.GetGroup(ScopeMatcher<Game>.Get<StartDeal>());
		}

		private Entity<Game> Camera => _contexts.Get<Game>().Unique.GetEntity<Camera>();

		public void Execute()
		{
			foreach (var _ in _entities)
				Camera.SetTargetTransform(_holders.Camera.PlayerSitting);
		}
	}
}