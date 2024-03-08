using Code.Component;
using Code.Scope;
using Entitas.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public interface IResourcesProvider
	{
		EntityBehaviour<Game> SpawnCardView(Transform parent, float height = 0);
		EntityBehaviour<Game> SpawnShadowCardView(Transform parent);
		EntityBehaviour<Game> SpawnLoupe(Transform parent);
	}

	[CreateAssetMenu(fileName = "Resources", menuName = "+375/Resources", order = -99)]
	public class ResourceConfig : ScriptableObject, IResourcesProvider
	{
		[Inject] private readonly DiContainer _diContainer;

		[SerializeField] private EntityBehaviour<Game> _cardPrefab;
		[SerializeField] private EntityBehaviour<Game> _shadowCardPrefab;
		[SerializeField] private EntityBehaviour<Game> _loupePrefab;

		public EntityBehaviour<Game> SpawnCardView(Transform parent, float height)
		{
			var cardView = Spawn(_cardPrefab, parent);
			cardView.transform.Set(y: height);
			cardView.transform.LookAt(cardView.transform.position + Vector3.down);
			return cardView;
		}

		public EntityBehaviour<Game> SpawnShadowCardView(Transform parent)
			=> Spawn(_shadowCardPrefab, parent);

		public EntityBehaviour<Game> SpawnLoupe(Transform parent)
		{
			var loupeView = Spawn(_loupePrefab, parent);
			loupeView.Entity.Is<Lens>(true);
			loupeView.transform.LookAt(loupeView.transform.position + Vector3.down);
			return loupeView;
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