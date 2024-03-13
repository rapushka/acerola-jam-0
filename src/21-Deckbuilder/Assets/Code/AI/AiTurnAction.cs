using System;
using System.Collections.Generic;
using Code.Component;
using Code.Scope;
using Entitas;
using Entitas.Generic;
using Zenject;
using static Entitas.Generic.ScopeMatcher<Code.Scope.Game>;

namespace Code.System
{
	public sealed class AiTurnAction : ReactiveSystem<Entity<Game>>
	{
		private readonly Contexts _contexts;
		private readonly AiConfig _config;
		private readonly CalculateScoreCommand _calculateScore;
		private readonly TurnActionDecisionMaker _decisionMaker;
		private readonly DeckProvider _deck;
		private readonly IGroup<Entity<Game>> _entities;

		[Inject]
		public AiTurnAction
		(
			Contexts contexts,
			AiConfig config,
			CalculateScoreCommand calculateScore,
			TurnActionDecisionMaker decisionMaker,
			DeckProvider deck
		)
			: base(contexts.Get<Game>())
		{
			_contexts = contexts;
			_config = config;
			_calculateScore = calculateScore;
			_decisionMaker = decisionMaker;
			_deck = deck;
		}

		private bool         HasCandidate => _contexts.Get<Game>().Unique.Has<Candidate>();
		private Entity<Game> Rules        => _contexts.Get<Game>().Unique.GetEntity<Rules>();

		private Entity<Game> Bank => _contexts.Get<Game>().Unique.GetEntity<Bank>();

		protected override ICollector<Entity<Game>> GetTrigger(IContext<Entity<Game>> context)
			=> context.CreateCollector(Get<CurrentTurn>().Added());

		protected override bool Filter(Entity<Game> entity)
			=> entity.Is<Ai>()
			   && entity.Is<CurrentTurn>()
			   && !HasCandidate;

		protected override void Execute(List<Entity<Game>> entities)
		{
			_calculateScore.Do();

			foreach (var dealer in entities)
				MakeTurnAction(dealer);
		}

		private void MakeTurnAction(Entity<Game> dealer)
		{
			dealer.Add<Waiting, float>(_config.TurnActionThinkingDuration);
			dealer.Add<Callback, Action>(Decide);
			return;

			void Decide()
			{
				_decisionMaker.Reset();
				_decisionMaker.Influence(_config.BaseTurnActionInfluence);

				var score = dealer.Get<Score>().Value;
				var maxScore = Rules.Get<MaxPointsThreshold>().Value;
				var deltaToMaxScore = maxScore - score;

				var cardsCount = dealer.GetCards().Count;
				var maxCardsCount = Rules.Get<MaxCardsInHand>().Value;
				var tooManyCards = cardsCount >= maxCardsCount;

				if (deltaToMaxScore >= _config.ThresholdDeltaToTryHit)
					_decisionMaker.Influence(_config.InfluenceOnSafeDrawRelative);

				if (deltaToMaxScore <= _config.CloseEnoughToMaxToStand)
					_decisionMaker.Influence(_config.InfluenceOnNiceScore);

				var currentBet = Bank.Get<CurrentBet>().Value;
				var ourMoney = dealer.GetMoney();
				var changeOnBet = ourMoney - currentBet;
				var percentsOfBet = (float)currentBet / ourMoney;

				if (changeOnBet <= 0)
					_decisionMaker.Influence(_config.InfluenceOnAllIn);
				else if (percentsOfBet >= _config.MajorityBetProportionThreshold)
					_decisionMaker.Influence(_config.InfluenceOnMajorityBet);
				else if (percentsOfBet >= _config.BigBetProportionThreshold)
					_decisionMaker.Influence(_config.InfluenceOnBigBet);

				if (score > maxScore && !tooManyCards && percentsOfBet < _config.SmallBetPercent)
					_decisionMaker.Influence(_config.InfluenceTryComeback);

				if (tooManyCards)
					_decisionMaker.Exclude("Hit");

				if (!_deck.HasCards)
					_decisionMaker.Exclude("Hit");

				_decisionMaker.LogBenefits();
				_decisionMaker.DoAction();
			}
		}
	}
}