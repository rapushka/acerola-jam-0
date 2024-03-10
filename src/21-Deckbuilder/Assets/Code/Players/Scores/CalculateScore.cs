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
		private readonly IGroup<Entity<Game>> _sides;
		private readonly EntityIndex<Game, HeldBy, Side> _cardsIndex;

		public CalculateScore(Contexts contexts)
			: base(contexts.Get<Game>())
		{
			_sides = contexts.GetGroup(ScopeMatcher<Game>.Get<Component.Side>());
			_cardsIndex = contexts.Get<Game>().GetIndex<HeldBy, Side>();
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<HeldBy>());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var side in _sides)
			{
				side.Replace<Score, int>(0);
				var cards = side.GetCards().Where((c) => !c.Is<Destroyed>());

				foreach (var points in cards.Select((c) => c.Get<Points>().Value))
					side.Replace<Score, int>(side.Get<Score>().Value + points);
			}
		}
	}
}