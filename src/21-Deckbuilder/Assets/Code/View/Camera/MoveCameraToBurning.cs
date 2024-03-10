using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class MoveCameraToBurning : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly HoldersProvider _holders;

		[Inject]
		public MoveCameraToBurning(Contexts contexts, HoldersProvider holders)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_holders = holders;
		}

		private Entity<Game> Camera => _contexts.Get<Game>().Unique.GetEntity<Camera>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<ToBurn>().AddedOrRemoved());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
			{
				var holder = e.Is<ToBurn>() ? _holders.Camera.Burning : _holders.Camera.PlayerSitting;
				Camera.SetTargetTransform(holder);
			}
		}
	}
}