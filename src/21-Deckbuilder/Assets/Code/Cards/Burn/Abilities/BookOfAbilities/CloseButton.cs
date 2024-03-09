using UnityEngine;
using UnityEngine.EventSystems;

namespace Code
{
	public class CloseButton : MonoBehaviour, IPointerClickHandler
	{
		[SerializeField] private GameObject _target;

		public void OnPointerClick(PointerEventData eventData) => _target.SetActive(false);
	}
}