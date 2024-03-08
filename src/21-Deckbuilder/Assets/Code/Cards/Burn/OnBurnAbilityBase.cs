using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public abstract class OnBurnAbilityBase : ReactiveSystem<Entity<Game>>
	{
		public OnBurnAbilityBase(Contexts contexts) : base(contexts.Get<Game>()) { }

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<Burned>().Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Burned>();

		protected override void Execute(List<Entity<Game>> entities) => Cast(entities);

		protected abstract void Cast(IEnumerable<Entity<Game>> burnedCards);
	}
}