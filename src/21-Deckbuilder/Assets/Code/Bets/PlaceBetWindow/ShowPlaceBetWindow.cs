using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class ShowPlaceBetWindow : ReactiveSystem<Entity<Game>>
	{
		private readonly HudMediator _hud;

		public ShowPlaceBetWindow(Contexts contexts, HudMediator hud)
			: base(contexts.Get<Game>())
			=> _hud = hud;

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<CardActionDone>().Added());

		protected override bool Filter(Entity<Game> entity)
			=> entity.Is<CardActionDone>() && entity.IsPlayer();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var _ in entities)
				_hud.IsPlaceBetWindowVisible = true;
		}
	}
}