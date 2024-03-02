using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public interface IResourcesProvider
	{
		EntityBehaviour<Game> SpawnCardView();
	}

	[CreateAssetMenu(fileName = "Resources", menuName = "+375/Resources", order = -99)]
	public class ResourceConfig : ScriptableObject, IResourcesProvider
	{
		[Inject] private readonly DiContainer _diContainer;

		[SerializeField] private EntityBehaviour<Game> _cardPrefab;

		public EntityBehaviour<Game> SpawnCardView() => Spawn(_cardPrefab);

		private EntityBehaviour<Game> Spawn(EntityBehaviour<Game> prefab)
		{
			var gameObject = _diContainer.InstantiatePrefab(prefab);
			var behaviour = gameObject.GetComponent<EntityBehaviour<Game>>();
			behaviour.Register(Contexts.Instance);
			return behaviour;
		}
	}
}