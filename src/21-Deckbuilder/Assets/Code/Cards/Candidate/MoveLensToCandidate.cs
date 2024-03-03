using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public sealed class MoveLensToCandidate : ReactiveSystem<Entity<Game>>
	{
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _lenses;

		public MoveLensToCandidate(Contexts contexts, HoldersProvider holders)
			: base(contexts.Get<Game>())
		{
			_holders = holders;
			_lenses = contexts.GetGroup(ScopeMatcher<Game>.Get<Lens>());
		}

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(ScopeMatcher<Game>.Get<Candidate>().AddedOrRemoved());

		protected override bool Filter(Entity<Game> entity) => true;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var e in entities)
			foreach (var lens in _lenses)
			{
				var transform = e.TryGet<Candidate>(out var candidate)
					? _holders[candidate.Value].CandidateLense
					: _holders.DefaultLens;

				lens.Replace<TargetPosition, Vector3>(transform.position);
				lens.Replace<TargetRotation, Quaternion>(transform.rotation);
			}
		}
	}
}