using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Random = UnityEngine.Random;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class AiTurnAction : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly AiConfig _config;
		private readonly IGroup<Entity<Game>> _entities;

		public AiTurnAction(Contexts contexts, AiConfig config)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_config = config;
		}

		private bool HasCandidate => _contexts.Get<Game>().Unique.Has<Candidate>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<CurrentTurn>().Added());

		protected override bool Filter(Entity<Game> entity)
			=> entity.Is<Ai>()
			   && entity.Is<CurrentTurn>()
			   && !HasCandidate;

		protected override void Execute(List<Entity<Game>> entities)
		{
			foreach (var dealer in entities)
			{
				// if !dealer.Has<Waiting>()
				dealer.Add<Waiting, float>(_config.TurnActionThinkingDuration);
				dealer.Add<Callback, Action>(Decide);
				return;

				void Decide()
				{
					if (Random.value <= _config.PassProbability)
					{
						dealer.Is<Pass>(true);
						return;
					}

					if (Random.value >= _config.HitVsStandProbability)
					{
						dealer.Is<Hit>(true);
					}
					else
					{
						dealer.Is<Stand>(false);
						dealer.Is<Stand>(true);
					}
				}
			}
		}
	}
}