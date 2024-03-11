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
		BookCardView          SpawnBookCardView(Transform parent, CardId id);

		EntityBehaviour<Game> SpawnMoneyHeapView(Transform parent);
		EntityBehaviour<Game> SpawnBetView(Transform parent);
	}

	[CreateAssetMenu(fileName = "Resources", menuName = "+375/Resources", order = -99)]
	public class ResourceConfig : ScriptableObject, IResourcesProvider
	{
		[Inject] private readonly DiContainer _diContainer;

		[SerializeField] private EntityBehaviour<Game> _cardPrefab;
		[SerializeField] private EntityBehaviour<Game> _shadowCardPrefab;
		[SerializeField] private EntityBehaviour<Game> _loupePrefab;
		[SerializeField] private BookCardView _bookCardPrefab;
		[SerializeField] private EntityBehaviour<Game> _betPrefab;
		[SerializeField] private EntityBehaviour<Game> _moneyHeapPrefab;

		public EntityBehaviour<Game> SpawnCardView(Transform parent, float height)
		{
			var cardView = SpawnBehaviour(_cardPrefab, parent);
			cardView.transform.Set(y: height);
			cardView.transform.LookAt(cardView.transform.position + Vector3.down);
			return cardView;
		}

		public EntityBehaviour<Game> SpawnShadowCardView(Transform parent)
			=> SpawnBehaviour(_shadowCardPrefab, parent);

		public EntityBehaviour<Game> SpawnLoupe(Transform parent)
		{
			var loupeView = SpawnBehaviour(_loupePrefab, parent);
			loupeView.Entity.Is<Lens>(true);
			return loupeView;
		}

		public BookCardView SpawnBookCardView(Transform parent, CardId id)
		{
			var gameObject = _diContainer.InstantiatePrefab(_bookCardPrefab, parent);
			var view = gameObject.GetComponent<BookCardView>();
			view.SetData(id);

			return view;
		}

		public EntityBehaviour<Game> SpawnMoneyHeapView(Transform parent)
			=> SpawnBehaviour(_moneyHeapPrefab, parent);

		public EntityBehaviour<Game> SpawnBetView(Transform parent)
			=> SpawnBehaviour(_betPrefab, parent);

		private EntityBehaviour<Game> SpawnBehaviour(EntityBehaviour<Game> prefab, Transform parent)
		{
			var gameObject = _diContainer.InstantiatePrefab(prefab, parent);
			var behaviour = gameObject.GetComponent<EntityBehaviour<Game>>();
			behaviour.Register(Contexts.Instance);
			return behaviour;
		}
	}
}