using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class UpdatePlayerScoreView : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly HudMediator _hud;

		public UpdatePlayerScoreView(Contexts contexts, HudMediator hud)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_hud = hud;
		}

		private Entity<Game> Rules => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<Score>());

		protected override bool Filter(Entity<Game> entity)
			=> entity.IsPlayer();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
			{
				var maxPoints = Rules.Get<MaxPointsThreshold>().Value;
				var currentPoints = e.Get<Score>().Value;
				var isBusted = currentPoints > maxPoints;

				_hud.PlayerScore.UpdateValue(currentPoints, isBusted);
			}
		}
	}
}