using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;

namespace Code.System
{
	public sealed class MoveLensToCandidate : ReactiveSystem<Entity<Game>>
	{
		private readonly HoldersProvider _holders;
		private readonly ViewConfig _viewConfig;
		private readonly IGroup<Entity<Game>> _lenses;

		public MoveLensToCandidate(Contexts contexts, HoldersProvider holders, ViewConfig viewConfig)
			: base(contexts.Get<Game>())
		{
			_holders = holders;
			_viewConfig = viewConfig;
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
				var hasCandidate = e.TryGet<Candidate>(out var candidate);
				var transform = hasCandidate ? _holders[candidate.Value].CandidateLense : _holders.DefaultLens;

				if (!hasCandidate)
				{
					SendLens();
					continue;
				}

				lens.Add<Waiting, float>(_viewConfig.LensMoveToCandidateDelay);
				lens.Add<Callback, Action>(SendLens);

				continue;

				void SendLens()
				{
					lens.Replace<MovementSpeed, float>(_viewConfig.MagnifyingGlassSpecificSpeed).RemoveOnReach();
					lens.SetTargetTransform(transform);
				}
			}
		}
	}
}