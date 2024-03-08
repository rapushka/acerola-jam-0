using UnityEngine;

namespace Code
{
	[CreateAssetMenu(fileName = "Balance Config", menuName = "+375/Balance Config")]
	public class BalanceConfig : ScriptableObject
	{
		[field: SerializeField] public int SideMoneyOnStart { get; private set; }
		[field: SerializeField] public int MinBetOnStart { get; private set; }
	}
}