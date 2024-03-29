using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;
using Random = UnityEngine.Random;

namespace Code.System
{
	public sealed class AiCardPickingAction : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly AiConfig _config;

		public AiCardPickingAction(Contexts contexts, AiConfig config)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_config = config;
		}

		private Entity<Game> Candidate => _contexts.Get<Game>().Unique.GetEntity<Candidate>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<Hit>().Added());

		private Entity<Game> Rules => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		protected override bool Filter(Entity<Game> entity) => entity.Is<Ai>() && entity.Is<Hit>();

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var dealer in entities)
			{
				dealer.Add<Waiting, float>(_config.CardPickingActionThinkingDuration);
				dealer.Add<Callback, Action>(Decide);
				return;

				void Decide()
				{
					var max = Rules.Get<MaxPointsThreshold>().Value;
					var tooBigCard = dealer.Get<Score>().Value + Candidate.Get<Points>().Value > max;
					var value = Random.value;

					if (tooBigCard)
						value += _config.RelustanceToOverdraw;

					if (value < _config.TakeVsBurnCandidateProbability
					    || Candidate.Has<CanNotBeBurn>())
					{
						_contexts.Get<Game>().CreateEntity().Is<TakeCandidate>(true);
					}
					else
						_contexts.Get<Game>().CreateEntity().Is<BurnCandidate>(true);
				}
			}
		}
	}
}