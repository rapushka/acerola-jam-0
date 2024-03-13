using UnityEngine;

namespace Code.System
{
	/// <summary> NOT MACHINE LEARNING OK? </summary>
	[CreateAssetMenu(fileName = "Dealer Ai Config", menuName = "+375/AiConfig", order = 0)]
	public class AiConfig : ScriptableObject
	{
		private const string RandomTooltip = "on 0 - always left value\non 1 - always right value";

		[field: SerializeField] public float TurnActionThinkingDuration        { get; private set; }
		[field: SerializeField] public float CardPickingActionThinkingDuration { get; private set; }

		[field: Header("Probabilities")]
		[field: Tooltip(RandomTooltip)]
		[field: SerializeField] public float TakeVsBurnCandidateProbability { get; private set; }

		[field: Tooltip(RandomTooltip)] [field: SerializeField] public float BetChance      { get; private set; }
		[field: Tooltip(RandomTooltip)] [field: SerializeField] public float RaiseBetChance { get; private set; }
		[field: Tooltip(RandomTooltip)] [field: SerializeField] public int   RaiseBetStep   { get; private set; }

		[field: Header("Turn Action Influences")]
		[field: SerializeField] public TurnActionInfluence BaseTurnActionInfluence { get; private set; }

		[field: Space]
		[field: Tooltip("MaxScore - CurrentDealerScore > ThresholdDeltaToTryHit")]
		[field: SerializeField] public float ThresholdDeltaToTryHit { get; private set; }

		[field: Tooltip("If we can take a card without risks af overdraw.\nWill be multiplied by delta to max score")]
		[field: SerializeField] public TurnActionInfluence InfluenceOnSafeDrawRelative { get; private set; }

		[field: Space]
		[field: SerializeField] public float CloseEnoughToMaxToStand { get; private set; }

		[field: SerializeField] public TurnActionInfluence InfluenceOnNiceScore { get; private set; }

		[field: Space]
		[field: Range(0f, 1f)]
		[field: SerializeField] public float BigBetProportionThreshold { get; private set; }

		[field: SerializeField] public TurnActionInfluence InfluenceOnBigBet { get; private set; }

		[field: Range(0f, 1f)]
		[field: SerializeField] public float MajorityBetProportionThreshold { get; private set; }

		[field: SerializeField] public TurnActionInfluence InfluenceOnMajorityBet { get; private set; }

		[field: Space]
		[field: SerializeField] public TurnActionInfluence InfluenceOnAllIn { get; private set; }

		[field: Space]
		[field: Range(0f, 1f)]
		[field: SerializeField] public float SmallBetPercent { get; private set; }

		[field: SerializeField] public TurnActionInfluence InfluenceTryComeback { get; private set; }
	}
}