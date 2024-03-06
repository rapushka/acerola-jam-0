using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class HidePlaceBetWindow : ReactiveSystem<Entity<Game>>
	{
		private readonly HudMediator _hud;

		public HidePlaceBetWindow(Contexts contexts, HudMediator hud)
			: base(contexts.Get<Game>())
			=> _hud = hud;

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(AnyOf(Get<Bet>(), Get<Pass>()).Added());

		protected override bool Filter(Entity<Game> entity) => entity.Is<Bet>() || entity.Is<Pass>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var _ in entities)
				_hud.IsPlaceBetWindowVisible = false;
		}
	}
}