using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code
{
	public class BookOfAbilities : MonoBehaviour
	{
		[Inject] private readonly IResourcesProvider _resources;

		[SerializeField] private GameObject _pageClubs;
		[SerializeField] private GameObject _pageDiamonds;
		[SerializeField] private GameObject _pageHearts;
		[SerializeField] private GameObject _pageSpades;

		private Dictionary<CardSuit, GameObject> _pages;

		private void Start()
		{
			_pages = new Dictionary<CardSuit, GameObject>
			{
				[CardSuit.Clubs] = _pageClubs,
				[CardSuit.Diamonds] = _pageDiamonds,
				[CardSuit.Hearts] = _pageHearts,
				[CardSuit.Spades] = _pageSpades,
			};

			foreach (var suit in CardUtils.Suits())
			{
				var parent = _pages[suit].transform;

				foreach (var face in CardUtils.Faces())
					_resources.SpawnBookCardView(parent, new CardId(face, suit));
			}
		}
	}
}