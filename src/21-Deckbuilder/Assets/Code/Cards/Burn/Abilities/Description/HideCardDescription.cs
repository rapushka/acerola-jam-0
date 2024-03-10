using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class HideCardDescription : ReactiveSystem<Entity<Game>>
	{
		private readonly HudMediator _hud;

		public HideCardDescription(Contexts contexts, HudMediator hud)
			: base(contexts.Get<Game>())
		{
			_hud = hud;
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(AnyOf(Get<Candidate>(), Get<ToBurn>()).Removed());

		protected override bool Filter(Entity<Game> entity) => !entity.Has<Candidate>() && !entity.Has<ToBurn>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var _ in entities)
				_hud.CardDescription.Hide();
		}
	}
}