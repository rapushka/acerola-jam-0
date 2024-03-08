using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class SideStand : ReactiveSystem<Entity<Game>>
	{
		public SideStand(Contexts contexts) : base(contexts.Get<Game>()) { }

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<Stand>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Stand>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
				e.Is<CardActionDone>(true);
		}
	}
}