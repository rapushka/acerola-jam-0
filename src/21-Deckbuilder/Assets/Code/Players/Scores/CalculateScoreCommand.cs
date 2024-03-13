using System.Linq;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;

namespace Code
{
	public class CalculateScoreCommand
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _sides;

		[Inject]
		public CalculateScoreCommand(Contexts contexts)
		{
			_contexts = contexts;
			_sides = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.Side>());
		}

		private int MaxPoints => Rules.Get<MaxPointsThreshold>().Value;

		private Entity<Game> Rules => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		public void Do()
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