using UnityEngine;

namespace Code
{
	[CreateAssetMenu(fileName = "ViewConfig", menuName = "+375/ViewConfig", order = -98)]
	public class ViewConfig : ScriptableObject
	{
		[field: SerializeField] public float CommonMovementSpeed { get; private set; }
		[field: SerializeField] public float DistanceBetweenCards { get; private set; }
	}
}