using Code.Component;
using Code.Scope;
using Entitas.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class BookCardView : MonoBehaviour
	{
		[Inject] private readonly DeckViewConfig _deck;
		[Inject] private readonly DescriptionBuilder _descriptionBuilder;
		[Inject] private readonly CardAbilitiesBinder _cardAbilitiesBinder;

		[SerializeField] private Image _spriteRenderer;
		[SerializeField] private TMP_Text _descriptionTextMesh;

		public void SetData(CardId cardID)
		{
			_spriteRenderer.sprite = _deck[cardID.Face, cardID.Suit];
			_descriptionTextMesh.text = _descriptionBuilder.Build(GetCard(cardID));
		}

		private Entity<Game> GetCard(CardId cardID)
		{
			var context = Contexts.Instance.Get<Game>();
			var e = context.CreateEntity();
			e.Is<Destroyed>(true);
			e.Add<Face, CardId>(cardID);
			_cardAbilitiesBinder.Bind(e);

			return e;
		}
	}
}