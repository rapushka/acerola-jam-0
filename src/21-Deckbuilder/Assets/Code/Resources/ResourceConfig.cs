using Code.Scope;
using Entitas.Generic;
using UnityEngine;

namespace Code
{
	public interface IResourcesProvider
	{
		EntityBehaviour<Game> SpawnCardView();
	}

	[CreateAssetMenu(fileName = "Resources", menuName = "+375/Resources", order = -99)]
	public class ResourceConfig : ScriptableObject, IResourcesProvider
	{
		[SerializeField] private EntityBehaviour<Game> _cardPrefab;

		public EntityBehaviour<Game> SpawnCardView() => Spawn(_cardPrefab);

		private static EntityBehaviour<Game> Spawn(EntityBehaviour<Game> prefab)
		{
			var behaviour = Instantiate(prefab);
			behaviour.Register(Contexts.Instance);
			return behaviour;
		}
	}
}