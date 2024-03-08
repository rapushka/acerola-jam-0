using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class RespawnDealer : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly SidesFactory _sidesFactory;

		public RespawnDealer(Contexts contexts, SidesFactory sidesFactory)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_sidesFactory = sidesFactory;
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<CreateNewDealer>());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
			{
				_contexts.GetDealer().Destroy();
				_sidesFactory.CreateDealer();

				e.Is<Destroyed>(true);
			}
		}
	}
}