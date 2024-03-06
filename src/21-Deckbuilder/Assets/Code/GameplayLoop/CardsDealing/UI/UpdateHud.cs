using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public sealed class UpdateHud : ReactiveSystem<Entity<Game>>
	{
		private readonly HudMediator _hud;

		[Inject]
		public UpdateHud(Contexts contexts, HudMediator hud)
			: base(contexts.Get<Game>())
			=> _hud = hud;

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<CurrentTurn>().AddedOrRemoved());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in entities)
				_hud.TurnActionsVisibility = side.Get<Component.Side>().Value is Side.Player;
		}
	}
}