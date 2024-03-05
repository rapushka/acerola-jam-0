using UnityEngine;

namespace Code.System
{
	/// <summary> NOT MACHINE LEARNING OK? </summary>
	[CreateAssetMenu(fileName = "Dealer Ai Config", menuName = "+375/AiConfig", order = 0)]
	public class AiConfig : ScriptableObject
	{
		[field: SerializeField] public float TurnActionThinkingDuration { get; private set; }
	}
}