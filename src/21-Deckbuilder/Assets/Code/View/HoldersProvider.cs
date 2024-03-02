using UnityEngine;

namespace Code
{
	public class HoldersProvider : MonoBehaviour
	{
		[field: SerializeField] public Transform Deck       { get; private set; }
		[field: SerializeField] public Transform PlayerHand { get; private set; }
		[field: SerializeField] public Transform DealerHand { get; private set; }
	}
}