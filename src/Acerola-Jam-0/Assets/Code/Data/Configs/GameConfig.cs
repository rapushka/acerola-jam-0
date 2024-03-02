using UnityEngine;

namespace Code
{
	[CreateAssetMenu(menuName = "+375/GameConfig", fileName = "GameConfig", order = -100)]
	public class GameConfig : ScriptableObject
	{
		[field: SerializeField] public InputConfig   Input   { get; private set; }
		[field: SerializeField] public PhysicsConfig Physics { get; private set; }
	}
}