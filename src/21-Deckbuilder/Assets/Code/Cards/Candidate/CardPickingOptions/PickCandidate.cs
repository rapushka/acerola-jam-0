using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class PickCandidate : IExecuteSystem
	{
		private readonly Contexts _contexts;
		private readonly IGroup<Entity<Game>> _entities;

		public PickCandidate(Contexts contexts)
		{
			_contexts = contexts;
			_entities = contexts.GetGroup(AnyOf(Get<BurnCandidate>(), Get<TakeCandidate>()));
		}

		public void Execute()
		{
			foreach (var e in _entities)
			{
				if (e.Is<TakeCandidate>())
					TakeCandidate();

				if (e.Is<BurnCandidate>())
					BurnCandidate();
			}
		}

		private void TakeCandidate()
		{
			var candidateCard = _contexts.Get<Game>().Unique.GetEntity<Candidate>();
			var side = candidateCard.Get<Candidate>().Value;

			candidateCard.Remove<Candidate>();
			candidateCard.Add<HeldBy, Side>(side);
		}

		private void BurnCandidate()
		{
			var candidateCard = _contexts.Get<Game>().Unique.GetEntity<Candidate>();
			candidateCard.Remove<Candidate>();

			candidateCard.Is<ToBurn>(true);
		}
	}
}