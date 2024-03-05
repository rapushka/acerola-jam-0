using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code
{
	public sealed class ShowPickingCardOptions : ReactiveSystem<Entity<Game>>
	{
		private readonly HudMediator _hud;

		public ShowPickingCardOptions(Contexts contexts, HudMediator hud)
			: base(contexts.Get<Game>())
		{
			_hud = hud;
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<Candidate>().AddedOrRemoved());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
			{
				var isOurCandidate = e.TryGet<Candidate, Side>(out var side) && side is Side.Player;
				
				_hud.PickCardOptionsVisibility = isOurCandidate;
				_hud.TurnActionsVisibility = !isOurCandidate;
			}
		}
	}
}