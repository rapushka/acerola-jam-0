using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code.System
{
	public class MoveCandidate : IExecuteSystem
	{
		private readonly HoldersProvider _holders;
		private readonly IGroup<Entity<Game>> _candidates;

		[Inject]
		public MoveCandidate(Contexts contexts, HoldersProvider holdersProvider)
		{
			_holders = holdersProvider;
			_candidates = contexts.GetGroup(ScopeMatcher<Game>.Get<Candidate>());
		}

		public void Execute()
		{
			foreach (var candidate in _candidates)
			{
				var side = candidate.Get<Candidate>().Value;
				var candidateCardTransform = _holders[side].CandidateCard;

				candidate.Replace<TargetPosition, Vector3>(candidateCardTransform.position);
				candidate.Replace<TargetRotation, Quaternion>(candidateCardTransform.rotation);
			}
		}
	}
}