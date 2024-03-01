using UnityEngine;

namespace Code
{
	[CreateAssetMenu(menuName = "_375/GameConfig", fileName = "GameConfig", order = -100)]
	public class GameConfig : ScriptableObject
	{
		[field: SerializeField] public InputConfig Input { get; private set; }
	}
}