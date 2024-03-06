using UnityEngine;

namespace Code.System
{
	/// <summary> NOT MACHINE LEARNING OK? </summary>
	[CreateAssetMenu(fileName = "Dealer Ai Config", menuName = "+375/AiConfig", order = 0)]
	public class AiConfig : ScriptableObject
	{
		private const string RandomTooltip = "on 1 - always right value\non 0 - always left value";

		[field: SerializeField] public float ThinkingDuration { get; private set; }

		[field: Header("Probabilities")]
		[field: Tooltip(RandomTooltip)]
		[field: SerializeField] public float HitVsStandProbability { get; private set; }

		[field: Tooltip(RandomTooltip)]
		[field: SerializeField] public float TakeVsBurnCandidateProbability { get; private set; }
	}
}