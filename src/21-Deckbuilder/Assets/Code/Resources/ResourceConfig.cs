using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public interface IResourcesProvider
	{
		EntityBehaviour<Game> SpawnCardView(Transform parent, float height);
	}

	[CreateAssetMenu(fileName = "Resources", menuName = "+375/Resources", order = -99)]
	public class ResourceConfig : ScriptableObject, IResourcesProvider
	{
		[Inject] private readonly DiContainer _diContainer;

		[SerializeField] private EntityBehaviour<Game> _cardPrefab;

		public EntityBehaviour<Game> SpawnCardView(Transform parent, float height)
		{
			var cardView = Spawn(_cardPrefab, parent);
			cardView.transform.Set(y: height);
			cardView.transform.LookAt(Vector3.down);
			return cardView;
		}

		private EntityBehaviour<Game> Spawn(EntityBehaviour<Game> prefab, Transform parent)
		{
			var gameObject = _diContainer.InstantiatePrefab(prefab, parent);
			var behaviour = gameObject.GetComponent<EntityBehaviour<Game>>();
			behaviour.Register(Contexts.Instance);
			return behaviour;
		}
	}
}