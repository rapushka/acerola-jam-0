using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code
{
	public sealed class DestroyArrivedBet : ReactiveSystem<Entity<Game>>
	{
		public DestroyArrivedBet(Contexts contexts) : base(contexts.Get<Game>()) { }

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<TargetPosition>().Removed());

		protected override bool Filter(Entity<Game> entity)
			=> !entity.Has<TargetPosition>() && entity.Is<Transaction>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
				e.Is<Destroyed>(true);
		}
	}
}