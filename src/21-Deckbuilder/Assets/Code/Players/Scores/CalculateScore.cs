using System.Collections.Generic;
using System.Linq;
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

		private int          MaxPoints => Rules.Get<MaxPointsThreshold>().Value;
		private Entity<Game> Rules     => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<HeldBy>());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in _sides)
			{
				side.Replace<Score, int>(0);
				var cards = side.GetCards().Where((c) => !c.Is<Destroyed>()).ToList();
				var countOfAces = cards.Count(IsAce);
				var score = cards.Select((c) => c.Get<Points>().Value).Sum();

				while (IsTooMany(score) && countOfAces > 0)
				{
					// Ace can be valued both 11 and 1 points
					score -= 10;
					countOfAces--;
				}

				side.Replace<Score, int>(score);
			}
		}

		private bool IsTooMany(int score) => score > MaxPoints || Rules.Is<FlipWinCondition>();

		private bool IsAce(Entity<Game> c) => c.GetOrDefault<Face>()?.Value.Face is CardFace.Ace;
	}
}