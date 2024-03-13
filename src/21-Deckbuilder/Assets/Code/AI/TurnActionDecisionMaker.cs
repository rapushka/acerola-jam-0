using System.Collections.Generic;
using System.Linq;
using Code.Component;
using Code.System;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class TurnActionDecisionMaker
	{
		private Dictionary<string, Strategy> _strategies;
		private readonly Contexts _contexts;

		private Strategy Hit   => _strategies.GetValueOrDefault(nameof(Hit));
		private Strategy Stand => _strategies.GetValueOrDefault(nameof(Stand));
		private Strategy Pass  => _strategies.GetValueOrDefault(nameof(Pass));

		[Inject]
		public TurnActionDecisionMaker(Contexts contexts)
		{
			_contexts = contexts;
			Reset();
		}

		public void Reset()
		{
			_strategies = new Dictionary<string, Strategy>
			{
				[nameof(Hit)] = new(() => _contexts.GetDealer().Is<Hit>(true)),
				[nameof(Stand)] = new(() => _contexts.GetDealer().Remark<Stand>()),
				[nameof(Pass)] = new(() => _contexts.GetDealer().Is<Pass>(true)),
			};
		}

		public void Influence(TurnActionInfluence influence)
		{
			AddBenefitSafely(Hit, influence.Hit);
			AddBenefitSafely(Stand, influence.Stand);
			AddBenefitSafely(Pass, influence.Pass);
		}

		public void Exclude(string strategyName)
		{
			_strategies.Remove(strategyName);
		}

		public void LogBenefits()
		{
			Debug.Log($"benefits: {string.Join(", ", _strategies.Select((p) => $"{p.Key} {p.Value.Benefit:F}"))}");
		}
		
		public void DoAction()
		{
			_strategies.Values.PickRandom().Action.Invoke();
		}

		private void AddBenefitSafely(Strategy strategy, float delta)
		{
			if (strategy is not null)
				strategy.Benefit += delta;
		}
	}
}