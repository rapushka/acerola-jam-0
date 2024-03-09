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
		[field: SerializeField] public float PassProbability { get; private set; }

		[field: Tooltip(RandomTooltip)]
		[field: SerializeField] public float HitVsStandProbability { get; private set; }

		[field: Tooltip(RandomTooltip)]
		[field: SerializeField] public float TakeVsBurnCandidateProbability { get; private set; }

		[field: Tooltip(RandomTooltip)] [field: SerializeField] public float BetChance      { get; private set; }
		[field: Tooltip(RandomTooltip)] [field: SerializeField] public float RaiseBetChance { get; private set; }
		[field: Tooltip(RandomTooltip)] [field: SerializeField] public int   RaiseBetStep   { get; private set; }
	}
}