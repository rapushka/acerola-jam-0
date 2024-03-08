using TMPro;
using UnityEngine;

namespace Code
{
	public class CardDescription : MonoBehaviour
	{
		[SerializeField] private TMP_Text _descriptionTextMesh;
		[SerializeField] private float _bordersHeight;

		private RectTransform RectTransform => (RectTransform)transform;

		public void Show(string description)
		{
			_descriptionTextMesh.text = description;
			UpdateHeight();

			gameObject.SetActive(true);
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		private void UpdateHeight()
		{
			var textHeight = _descriptionTextMesh.rectTransform.rect.height;
			var height = textHeight + _bordersHeight;
			RectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
		}
	}
}