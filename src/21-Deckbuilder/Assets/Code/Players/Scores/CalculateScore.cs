using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class CalculateScore : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _sides;

		public CalculateScore(Contexts contexts)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_sides = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.Side>());
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<HeldBy>());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in _sides)
				side.Replace<Score, int>(0);

			foreach (var card in entities)
			{
				var points = card.Get<Face>().Value.GetPoints();
				var side = _contexts.GetSide(card.Get<HeldBy>().Value);

				side.Replace<Score, int>(side.Get<Score>().Value + points);
			}
		}
	}
}